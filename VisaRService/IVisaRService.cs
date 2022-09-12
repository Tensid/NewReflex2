using System.Collections.Generic;
using System.Threading.Tasks;
using VisaRService.Contracts;

namespace VisaRService
{
    public interface IVisaRService
    {
        Task<Case[]> GetCasesByEstate(string estateId);
        Task<Preview> GetPreviewByCase(string caseId);
        Task<CasePerson[]> GetPersonsByCase(string caseId);
        Task<Occurence[]> GetOccurencesByCase(string caseId);
        Task<ArchivedDocument[]> GetArchivedDocumentsByCase(string caseId);
        Task<Case> GetCase(string caseId);
        Task<PhysicalDocument> GetDocument(string documentId);
        Task<Case> SearchCase(string caseId);
        Task<List<Task<Case[]>>> SearchCases(string caseId);
    }
}
