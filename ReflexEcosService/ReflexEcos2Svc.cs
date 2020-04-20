using System;
using System.Linq;
using System.ServiceModel;
using ReflexEcos2Service.Ecos2ReflexService;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexEcos2Service
{
    public class ReflexEcos2Svc : IVisaRService
    {
        private readonly string _url;
        private readonly ConfigItem _config;

        public ReflexEcos2Svc(ConfigItem config)
        {
            _url = config.EcosConfig.ServiceUrl;
            _config = config;
        }

        private ReflexServiceClient GetClient()
        {
            var binding = new BasicHttpBinding
            {
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                Security =
                {
                    Mode =
                        _url.StartsWith("https:")
                            ? BasicHttpSecurityMode.Transport
                            : BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = {ClientCredentialType = HttpClientCredentialType.Ntlm}
                }
            };
            var client = new ReflexServiceClient(binding, new EndpointAddress(_url));
            if (string.IsNullOrEmpty(_config.EcosConfig.Username) || string.IsNullOrEmpty(_config.EcosConfig.Password))
            {
                return client;
            }
            client.ClientCredentials.Windows.ClientCredential.UserName = _config.EcosConfig.Username;
            client.ClientCredentials.Windows.ClientCredential.Password = _config.EcosConfig.Password;

            return client;
        }

        public Case[] GetCasesByEstate(string estateId)
        {
            var fnr = int.Parse(estateId);
            var client = GetClient();
            var result = client.GetEstateCases(fnr);
            return result.AsParallel().Select(c => new Case
            {
                CaseSource = "Ecos",
                CaseId = c.CaseId.ToString(),
                Dnr = c.Dnr,
                Title = c.CaseTitle + (c.RelatedObjects?.Length > 0 ? (" - " + string.Join(", ", c.RelatedObjects)) : ""),
                Date = c.StartDate
            }).ToArray();
        }

        public Occurence[] GetOccurencesByCase(string caseId)
        {
            var client = GetClient();
            var result = client.GetCaseOccurences(Guid.Parse(caseId));
            return result.Select(o => new Occurence
            {
                Title = o.OccurenceTitle,
                Arrival = o.OccurenceDate,
                IsSecret = o.HasSensitiveDocuments,
                Documents = o.Documents.Select(d => new Document
                {
                    Title = d.DocumentTitle,
                    DocLinkId = d.HasFile ? d.DocumentId.ToString() : null
                }).ToArray()
            }).ToArray();
        }

        public string GetPreviewByCase(string caseId)
        {
            return null;
        }

        public CasePerson[] GetPersonsByCase(string caseId)
        {
            return new CasePerson[0];
        }

        public ArchivedDocument[] GetArchivedDocumentsByCase(string caseId)
        {
            return new ArchivedDocument[0];
        }

        public PhysicalDocument GetDocument(string documentId)
        {
            var client = GetClient();
            var file = client.GetDocumentFile(Guid.Parse(documentId));

            return new PhysicalDocument
            {
                Data = file.Data,
                Filename = file.Filename
            };
        }

        public Estate[] GetEstatesByCase(string caseId)
        {
            return new Estate[] { };
        }
    }
}
