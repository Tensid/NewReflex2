using ReflexAgsService.Ags;
using System;
using System.Threading.Tasks;
using VisaRService;
using VisaRService.Contracts;

namespace ReflexAgsService
{
    public class AgsService : IVisaRService
    {
        private readonly ConfigItem _config;

        public AgsService(ConfigItem config)
        {
            _config = config;
        }

        private AgsProvider GetProvider(AgsConfig config)
        {
            return new AgsProvider(_config);
        }

        public async Task<Case[]> GetCasesByEstate(string estateId)
        {
            return await GetProvider(_config.AgsConfig).GetCasesByEstate(estateId, _config.AgsConfig.CasePattern, _config.AgsConfig.DateField, _config.AgsConfig.Instance, _config.AgsConfig.Department, _config.AgsConfig.SearchWay);
        }

        public Task<string> GetPreviewByCase(string caseId)
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
            return await GetProvider(_config.AgsConfig).GetDocumentsByCase(caseId, _config.AgsConfig.DocumentPattern, _config.AgsConfig.Instance, _config.AgsConfig.Department, _config.AgsConfig.SearchWay);
        }

        public async Task<PhysicalDocument> GetPhysicalDocument(string documentId)
        {
            return await GetProvider(_config.AgsConfig).GetPhysicalDocument(documentId, _config.AgsConfig.Instance, _config.AgsConfig.Department);
        }

        public async Task<Estate[]> GetEstatesByCase(string caseId)
        {
            return await GetProvider(_config.AgsConfig).GetEstatesByCase(caseId, _config.AgsConfig.Instance, _config.AgsConfig.Department);
        }
    }
}
