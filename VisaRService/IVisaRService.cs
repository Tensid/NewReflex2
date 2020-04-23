using System.Threading.Tasks;
using VisaRService.Contracts;

namespace VisaRService
{
    public interface IVisaRService
    {
        Task<Case[]> GetCasesByEstate(string estateId);
        Task<string> GetPreviewByCase(string caseId);
        Task<CasePerson[]> GetPersonsByCase(string caseId);
        Task<Occurence[]> GetOccurencesByCase(string caseId);
        Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId);
        Task<Estate[]> GetEstatesByCase(string caseId);
    }
}
