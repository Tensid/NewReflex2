using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Reflex.Data;
using Reflex.Data.Models;
using ReflexEcos2Service.Ecos2ReflexService;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexEcos2Service
{
    public class EcosServiceFactory
    {
        private readonly EcosSettings _settings;
        private readonly ApplicationDbContext _context;

        public EcosServiceFactory(ApplicationDbContext context)
        {
            _settings = context.EcosSettings.FirstOrDefault();
            _context = context;
        }

        public ReflexEcosSvc Create(Guid id)
        {
            var ecosConfig = _context.EcosConfigs.FirstOrDefault(x => x.Id == id);
            return new ReflexEcosSvc(_settings);
        }
    }

    public class ReflexEcosSvc : IVisaRService
    {
        private readonly EcosSettings _settings;

        public ReflexEcosSvc(EcosSettings settings)
        {
            _settings = settings;
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
                        _settings.ServiceUrl.StartsWith("https:")
                            ? BasicHttpSecurityMode.Transport
                            : BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = {ClientCredentialType = HttpClientCredentialType.Ntlm}
                }
            };
            var client = new ReflexServiceClient(binding, new EndpointAddress(_settings.ServiceUrl));
            if (string.IsNullOrEmpty(_settings.Username) || string.IsNullOrEmpty(_settings.Password))
            {
                return client;
            }
            client.ClientCredentials.Windows.ClientCredential.UserName =_settings.Username;
            client.ClientCredentials.Windows.ClientCredential.Password = _settings.Password;

            return client;
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            var fnr = int.Parse(estateId);
            var client = GetClient();
            var result = await client.GetEstateCasesAsync(fnr);
            return result.AsParallel().Select(c => new Case
            {
                CaseSource = "Ecos",
                CaseId = c.CaseId.ToString(),
                Dnr = c.Dnr,
                Title = c.CaseTitle + (c.RelatedObjects?.Length > 0 ? (" - " + string.Join(", ", c.RelatedObjects)) : ""),
                Date = c.StartDate
            }).ToArray();
        }

        public async Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            var client = GetClient();
            var result = await client.GetCaseOccurencesAsync(Guid.Parse(caseId));
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

        public async Task<PhysicalDocument> GetDocument(string documentId)
        {
            var client = GetClient();
            var file = await client.GetDocumentFileAsync(Guid.Parse(documentId));

            return new PhysicalDocument
            {
                Data = file.Data,
                Filename = file.Filename
            };
        }

        public Task<Preview> GetPreviewByCase(string caseId)
        {
            return null;
        }

        public Task<CasePerson[]> GetPersonsByCase(string caseId)
        {
            return null;
        }

        public Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            return null;
        }

        public Task<Case> GetCase(string caseId)
        {
            throw new NotImplementedException();
        }
    }
}
