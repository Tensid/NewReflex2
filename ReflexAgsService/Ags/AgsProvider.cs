using AgsProSystemWebService;
using FbService.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Xml;
using VisaRService.Contracts;
using Estate = VisaRService.Contracts.Estate;

namespace ReflexAgsService.Ags
{
    public class AgsProvider
    {
        private readonly string _url;
        private readonly string _username;
        private readonly string _password;
        private readonly ConfigItem _config;

        public AgsProvider(ConfigItem config)
        {
            _url = config.AgsConfig.ServiceUrl;
            _username = config.AgsConfig.Username;
            _password = config.AgsConfig.Password;
            _config = config;
        }

        private AgsClient GetClient()
        {
            var binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = int.MaxValue,
                ReaderQuotas =
                {
                    MaxArrayLength = int.MaxValue,
                    MaxStringContentLength = int.MaxValue,
                    MaxBytesPerRead = int.MaxValue
                }
            };
            if (_url.StartsWith("https://"))
            {
                binding.Security.Mode = BasicHttpSecurityMode.Transport;
            }
            var client = new AGSProfessionalSystemWebServiceBusinesslogicSoapClient(binding, new EndpointAddress(_url));
            var loginResult = client.ags_Login(_username, _password);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(loginResult);
            var validationKey = xmlDoc.GetElementsByTagName("ags_ValidationKey")[0].InnerText;

            return new AgsClient
            {
                Client = client,
                ValidationKey = validationKey
            };
        }

        private struct AgsClient
        {
            public AGSProfessionalSystemWebServiceBusinesslogicSoapClient Client;
            public string ValidationKey;
        }

        private string[] GetPatternColumns(string pattern)
        {
            var matches = Regex.Matches(pattern, "\\{(.*?)\\}");
            return matches.Cast<Match>().Select(x => x.Groups[1].Value).Distinct().ToArray();
        }

        public Case[] GetCasesByEstate(string estateId, string displayPattern, string dateColumn, string instanceId, string departmentId, string searchWay)
        {
            var svc = GetClient();
            var searchResultXml = svc.Client.ags_SearchWayGetResult(svc.ValidationKey, instanceId, departmentId, searchWay, estateId, "GROUP", "", "False", "1", "0", "1");

            var displayColumns = GetPatternColumns(displayPattern);

            string display = displayPattern;
            for (int i = 0; i < displayColumns.Length; i++)
            {
                display = display.Replace("{" + displayColumns[i] + "}", "{" + i + "}");
            }

            var searchResultDoc = new XmlDocument();
            searchResultDoc.LoadXml(searchResultXml);
            var groups = searchResultDoc.GetElementsByTagName("ags_Groups")[0];

            var title = new Dictionary<string, string>();
            var groupId = groups.ChildNodes.Cast<XmlNode>().FirstOrDefault()?.Attributes?["AGS_GROUPID"].Value;
            var groupData = svc.Client.ags_GroupGetDataFromId(svc.ValidationKey, instanceId, departmentId, groupId, "true");
            var searchResultDocGroupData = new XmlDocument();
            searchResultDocGroupData.LoadXml(groupData);
            var agsGroupAliasAndColumnName = searchResultDocGroupData.GetElementsByTagName("ags_GroupAliasAndColumnName");
            foreach (var alias in displayColumns)
            {
                title.Add(alias, agsGroupAliasAndColumnName.Cast<XmlNode>().FirstOrDefault(
                               groupNode => groupNode.Attributes?["ALIAS"].Value == alias)?.Attributes?["COLUMN_VALUE"]?.Value?.Trim() ?? "-");
            }

            var searchResult = groups.ChildNodes.Cast<XmlNode>().Select(groupNode => new Case
            {
                CaseSource = "AGS",
                Date = String.IsNullOrEmpty(dateColumn) ? DateTime.Today : DateTime.Parse(groupNode.Attributes.Cast<XmlAttribute>().SingleOrDefault(attr => attr.Name == dateColumn)?.Value ?? DateTime.Today.ToShortDateString()),
                CaseId = groupNode.Attributes["AGS_GROUPID"].Value,
                Dnr = groupNode.Attributes["AGS_GROUPID"].Value,
                Title = string.Format(display, displayColumns.Select(dp => title[dp] ?? "-").ToArray())
            }).ToArray();

            return searchResult;
        }

        public ArchivedDocument[] GetDocumentsByCase(string caseId, string displayPattern, string instanceId, string departmentId, string searchWay)
        {
            var svc = GetClient();
            var searchResultMetadata = svc.Client.ags_SearchWayGetResultFromGroupId(svc.ValidationKey, instanceId, departmentId, searchWay, caseId, "DOC", "", "False", "0", "0", "0");

            var displayColumns = GetPatternColumns(displayPattern);

            string display = displayPattern;
            for (int i = 0; i < displayColumns.Length; i++)
            {
                display = display.Replace("{" + displayColumns[i] + "}", "{" + i + "}");
            }

            var documentsDoc = new XmlDocument();
            documentsDoc.LoadXml(searchResultMetadata);

            var documentNodes = documentsDoc.GetElementsByTagName("ags_Documents")[0];

            var ret = documentNodes.ChildNodes.Cast<XmlNode>().Select(docNode => new ArchivedDocument
            {
                PhysicalDocumentId = docNode.Attributes["AGS_DOCUMENTID"].Value,
                Title = string.Format(display,
                        displayColumns.Select(
                            dp =>
                                docNode.Attributes.Cast<XmlAttribute>()
                                    .FirstOrDefault(attr => attr.Name == dp)?
                                    .Value ?? "-").ToArray())
            }).ToArray();

            return ret;
        }

        public PhysicalDocument GetPhysicalDocument(string documentId, string instanceId, string departmentId)
        {
            var svc = GetClient();
            var physicalDocumentRet = svc.Client.ags_DocumentGetFromId(svc.ValidationKey, instanceId, departmentId, documentId);
            var physicalDocumentDoc = new XmlDocument();
            physicalDocumentDoc.LoadXml(physicalDocumentRet);
            var fileName = physicalDocumentDoc.GetElementsByTagName("ags_DocumentName")[0].InnerText;
            var fileDataB64 = physicalDocumentDoc.GetElementsByTagName("ags_DocumentData")[0].InnerText;
            var binaryData = Convert.FromBase64String(fileDataB64);

            return new PhysicalDocument
            {
                Data = binaryData,
                Filename = fileName,
                Id = documentId,
                Extension = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal) + 1)
            };
        }

        public Estate[] GetEstatesByCase(string groupid, string instanceId, string departmentId)
        {
            var svc = GetClient();
            var groupData = svc.Client.ags_GroupGetDataFromId(svc.ValidationKey, instanceId, departmentId, groupid, "true");
            var searchResultDocGroupData = new XmlDocument();
            searchResultDocGroupData.LoadXml(groupData);
            var agsGroupAliasAndColumnName = searchResultDocGroupData.GetElementsByTagName("ags_GroupAliasAndColumnName");
            var estateName = agsGroupAliasAndColumnName[8]?.Attributes?["COLUMN_VALUE"]?.Value.Trim();

            var estate = new FbProvider(_config).SearchEstates(estateName).Result;

            if (estate == null)
                return new Estate[] { };

            return estate.Select(e => new Estate
            {
                EstateId = e.EstateId,
                EstateName = e.EstateName
            }).ToArray();
        }
    }
}
