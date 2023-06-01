using AgsProSystemWebService;
using Reflex.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using VisaRService.Contracts;

namespace ReflexAgsService.Ags
{
    public class AgsProvider
    {
        private readonly string _url;
        private readonly string _username;
        private readonly string _password;

        public AgsProvider(AgsSettings agsSettings, string username, string password)
        {
            _url = agsSettings.ServiceUrl;
            _username = username;
            _password = password;
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

        public async Task<Case[]> GetCasesByEstate(string estateId, string displayPattern, string dateColumn, string instanceId, string departmentId, string searchWay)
        {
            var svc = GetClient();
            var searchResultXml = (await svc.Client.ags_SearchWayGetResultAsync(svc.ValidationKey, instanceId, departmentId, searchWay, estateId, "GROUP", "", "False", "1", "0", "1")).Body.ags_SearchWayGetResultResult;

            var displayColumns = GetPatternColumns(displayPattern);

            string display = displayPattern;
            for (int i = 0; i < displayColumns.Length; i++)
            {
                display = display.Replace("{" + displayColumns[i] + "}", "{" + i + "}");
            }

            var searchResultDoc = new XmlDocument();
            searchResultDoc.LoadXml(searchResultXml);
            var groups = searchResultDoc.GetElementsByTagName("ags_Groups")[0];

            var searchResult = groups.ChildNodes.Cast<XmlNode>().Select(groupNode => new Case
            {
                CaseSource = "AGS",
                Date = string.IsNullOrEmpty(dateColumn) ? DateTime.Today : DateTime.Parse(groupNode.Attributes.Cast<XmlAttribute>().SingleOrDefault(attr => attr.Name == dateColumn)?.Value ?? DateTime.Today.ToShortDateString()),
                CaseId = groupNode.Attributes["AGS_GROUPID"].Value,
                Dnr = groupNode.Attributes["AGS_GROUPID"].Value,
                Title = string.Format(display, displayColumns.Select(dp => GetTitle(groupNode.Attributes["AGS_GROUPID"].Value).Result[dp] ?? "-").ToArray())
            }).ToArray();

            return searchResult;

            async Task<Dictionary<string, string>> GetTitle(string groupId)
            {
                var title = new Dictionary<string, string>();
                var groupData = (await svc.Client.ags_GroupGetDataFromIdAsync(svc.ValidationKey, instanceId, departmentId, groupId, "true")).Body.ags_GroupGetDataFromIdResult;
                var searchResultDocGroupData = new XmlDocument();
                searchResultDocGroupData.LoadXml(groupData);
                var agsGroupAliasAndColumnName = searchResultDocGroupData.GetElementsByTagName("ags_GroupAliasAndColumnName");
                foreach (var alias in displayColumns)
                {
                    title.Add(alias, agsGroupAliasAndColumnName.Cast<XmlNode>().FirstOrDefault(
                                   groupNode => groupNode.Attributes?["ALIAS"].Value == alias)?.Attributes?["COLUMN_VALUE"]?.Value?.Trim() ?? "-");
                }

                return title;
            }
        }

        public async Task<ArchivedDocument[]> GetDocumentsByCase(string caseId, string displayPattern, string instanceId, string departmentId, string searchWay)
        {
            var svc = GetClient();
            var searchResultMetadata = (await svc.Client.ags_SearchWayGetResultFromGroupIdAsync(svc.ValidationKey, instanceId, departmentId, searchWay, caseId, "DOC", "", "False", "0", "0", "0")).Body.ags_SearchWayGetResultFromGroupIdResult;

            var displayColumns = GetPatternColumns(displayPattern);

            string display = displayPattern;
            for (int i = 0; i < displayColumns.Length; i++)
            {
                display = display.Replace("{" + displayColumns[i] + "}", "{" + i + "}");
            }

            var documentsDoc = new XmlDocument();
            documentsDoc.LoadXml(searchResultMetadata);

            var documentNodes = documentsDoc.GetElementsByTagName("ags_Documents")[0];

            var archivedDocument = new ArchivedDocument
            {
                Docs = documentNodes.ChildNodes.Cast<XmlNode>().Select(docNode => new Doc
                {
                    Title = string.Format(display,
                        displayColumns.Select(
                            dp => docNode.Attributes.Cast<XmlAttribute>()
                            .FirstOrDefault(attr => attr.Name == dp)?.Value ?? "-").ToArray()),
                    Files = new[] { new File
                    {
                        Title = string.Format(display,
                            displayColumns.Select(
                                dp => docNode.Attributes.Cast<XmlAttribute>()
                                .FirstOrDefault(attr => attr.Name == dp)?.Value ?? "-").ToArray()),
                        PhysicalDocumentId = docNode.Attributes["AGS_DOCUMENTID"].Value ?? "-1",
                    }}
                })
            };

            return new[] { archivedDocument };
        }

        public async Task<PhysicalDocument> GetPhysicalDocument(string documentId, string instanceId, string departmentId)
        {
            var svc = GetClient();
            var physicalDocumentRet = (await svc.Client.ags_DocumentGetFromIdAsync(svc.ValidationKey, instanceId, departmentId, documentId)).Body.ags_DocumentGetFromIdResult;
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

        public async Task<Case> GetCase(string groupid, string instanceId, string departmentId, string documentPattern, string dateField, string searchWay)
        {
            var svc = GetClient();
            try
            {
                var groupData = (await svc.Client.ags_GroupGetDataFromIdAsync(svc.ValidationKey, instanceId, departmentId, groupid, "true")).Body.ags_GroupGetDataFromIdResult;
                var searchResultDocGroupData = new XmlDocument();
                searchResultDocGroupData.LoadXml(groupData);
                var agsGroupAliasAndColumnName = searchResultDocGroupData.GetElementsByTagName("ags_GroupAliasAndColumnName");
                var estateName = agsGroupAliasAndColumnName[8]?.Attributes?["COLUMN_VALUE"]?.Value.Trim();

                if (!string.IsNullOrEmpty(estateName))
                {
                    return (await GetCasesByEstate(estateName, documentPattern, dateField, instanceId,
                               departmentId, searchWay)).First() ?? null;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
