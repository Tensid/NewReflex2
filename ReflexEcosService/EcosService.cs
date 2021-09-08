using EcosService;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;
using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexEcosService
{
    public class EcosServiceFactory
    {
        private readonly EcosSettings _settings;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EcosServiceFactory> _logger;

        public EcosServiceFactory(ApplicationDbContext context, ILogger<EcosServiceFactory> logger)
        {
            _settings = context.EcosSettings.FirstOrDefault();
            _context = context;
            _logger = logger;
        }

        public ReflexEcosSvc Create(Guid id)
        {
            var ecosConfig = _context.EcosConfigs.FirstOrDefault(x => x.Id == id);
            return new ReflexEcosSvc(_settings, ecosConfig, _logger);
        }
    }

    public class ReflexEcosSvc : IVisaRService
    {
        private readonly EcosSettings _settings;
        private readonly EcosConfig _config;
        private readonly ILogger _logger;

        public ReflexEcosSvc(EcosSettings settings, EcosConfig ecosConfig, ILogger logger)
        {
            _settings = settings;
            _config = ecosConfig;
            _logger = logger;
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
            client.ClientCredentials.Windows.ClientCredential.UserName = _settings.Username;
            client.ClientCredentials.Windows.ClientCredential.Password = _settings.Password;

            return client;
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            var client = GetClient();

            var searchResult = (await client.SearchCaseAsync(new ReflexSearchCase
            {
                Filters = new Filter[] { new FnrFilter { Fnr = int.Parse(estateId) } }
            })).ToList();

            return searchResult.Where(c => !(_config.HideCasesWithSecretOccurences && HasSensitiveDocuments(c.CaseId)))
                .Select(c => new Case
                {
                    CaseId = c.CaseId.ToString(),
                    Dnr = c.CaseNumber,
                    Title = c.CaseSubtitleFree,
                    CaseSource = "Ecos",
                    CaseSourceId = _config.Id
                }).ToArray();
        }

        private bool HasSensitiveDocuments(Guid? caseId)
        {
            if (caseId == null)
                return false;
            var client = GetClient();
            var result = client.GetCaseOccurencesAsync((Guid)caseId).Result;
            return result.Any(o => o.HasSensitiveDocuments);
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

        public async Task<Case> GetCase(string caseId)
        {
            try
            {
                var client = GetClient();
                var searchResult = (await client.SearchCaseAsync(new ReflexSearchCase
                {
                    Filters = new Filter[] { new CaseNumberFilter { CaseNumber = caseId } }
                }))
                .FirstOrDefault(c => !(_config.HideCasesWithSecretOccurences && HasSensitiveDocuments(c.CaseId)));
                if (searchResult == null)
                    return null;

                return new Case
                {
                    Beskrivning = searchResult.CaseSubtitleFree,
                    CaseId = searchResult.CaseId.ToString(),
                    Dnr = searchResult.CaseNumber,
                    Fastighetsbeteckning = searchResult.EstateDesignation,
                    Title = searchResult.CaseSubtitleFree,
                    CaseSource = "Ecos",
                    CaseSourceId = _config.Id,
                    UnavailableDueToSecrecy = _config.HideCasesWithSecretOccurences && HasSensitiveDocuments(searchResult.CaseId)
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<Case> SearchCase(string caseNumber)
        {
            try
            {
                var client = GetClient();
                var searchResult = (await client.SearchCaseAsync(new ReflexSearchCase
                {
                    Filters = new Filter[] { new CaseNumberFilter { CaseNumber = caseNumber } }
                })).FirstOrDefault();
                if (searchResult == null)
                    return null;

                return new Case
                {
                    Beskrivning = searchResult.CaseSubtitleFree,
                    CaseId = searchResult.CaseNumber,
                    Dnr = searchResult.CaseNumber,
                    Fastighetsbeteckning = searchResult?.EstateDesignation,
                    Title = searchResult.CaseSubtitleFree,
                    CaseSource = "Ecos",
                    CaseSourceId = _config.Id
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }
    }
}
