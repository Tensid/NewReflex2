using ReflexAgsService.Ags;
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

        public Case[] GetCasesByEstate(string estateId)
        {
            return GetProvider(_config.AgsConfig).GetCasesByEstate(estateId, _config.AgsConfig.CasePattern, _config.AgsConfig.DateField, _config.AgsConfig.Instance, _config.AgsConfig.Department, _config.AgsConfig.SearchWay);
        }

        public string GetPreviewByCase(string caseId)
        {
            return null;
        }

        public CasePerson[] GetPersonsByCase(string caseId)
        {
            return new CasePerson[0];
        }

        public Occurence[] GetOccurencesByCase(string caseId)
        {
            return null;
        }

        public ArchivedDocument[] GetArchivedDocumentsByCase(string caseId)
        {
            return GetProvider(_config.AgsConfig).GetDocumentsByCase(caseId, _config.AgsConfig.DocumentPattern, _config.AgsConfig.Instance, _config.AgsConfig.Department, _config.AgsConfig.SearchWay);
        }

        public PhysicalDocument GetPhysicalDocument(string documentId)
        {
            return GetProvider(_config.AgsConfig).GetPhysicalDocument(documentId, _config.AgsConfig.Instance, _config.AgsConfig.Department);
        }

        public Estate[] GetEstatesByCase(string caseId)
        {
            return GetProvider(_config.AgsConfig).GetEstatesByCase(caseId, _config.AgsConfig.Instance, _config.AgsConfig.Department);
        }
    }
}
