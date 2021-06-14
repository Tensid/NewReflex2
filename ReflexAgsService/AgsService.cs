using System;
using System.Linq;
using System.Threading.Tasks;
using Reflex.Data;
using Reflex.Data.Models;
using ReflexAgsService.Ags;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexAgsService
{
    public class AgsServiceFactory
    {
        private readonly AgsSettings _settings;
        private readonly ApplicationDbContext _context;

        public AgsServiceFactory(ApplicationDbContext context)
        {
            _settings = context.AgsSettings.FirstOrDefault();
            _context = context;
        }

        public AgsService Create(Guid id)
        {
            var agsConfig = _context.AgsConfigs.FirstOrDefault(x => x.Id == id);
            return new AgsService(_settings, agsConfig);
        }
    }

    public class AgsService : IVisaRService
    {
        private readonly AgsSettings _settings;
        private readonly AgsConfig _config;

        public AgsService(AgsSettings settings, AgsConfig agsConfig)
        {
            _settings = settings;
            _config = agsConfig;
        }

        private AgsProvider GetProvider()
        {
            return new AgsProvider(_settings, _config.Username, _config.Password);
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            return await GetProvider().GetCasesByEstate(estateId, _config.CasePattern, _config.DateField, _config.Instance, _config.Department, _config.SearchWay);
        }

        public Task<Preview> GetPreviewByCase(string caseId)
        {
            return null;
        }

        public Task<CasePerson[]> GetPersonsByCase(string caseId)
        {
            return null;
        }

        public Task<Occurence[]> GetOccurencesByCase(string caseId)
        {
            return null;
        }

        public async Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId)
        {
            return await GetProvider().GetDocumentsByCase(caseId, _config.DocumentPattern, _config.Instance, _config.Department, _config.SearchWay);
        }

        public async Task<PhysicalDocument> GetDocument(string documentId)
        {
            return await GetProvider().GetPhysicalDocument(documentId, _config.Instance, _config.Department);
        }

        public async Task<Case> GetCase(string caseId)
        {
            return await GetProvider().GetCase(caseId, _config.Instance, _config.Department, _config.DocumentPattern, _config.DateField, _config.SearchWay);
        }
    }
}
