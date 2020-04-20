using VisaRService.Contracts;

namespace VisaRService
{
    public interface IVisaRService
    {
        Case[] GetCasesByEstate(string estateId);
        string GetPreviewByCase(string caseId);
        CasePerson[] GetPersonsByCase(string caseId);
        Occurence[] GetOccurencesByCase(string caseId);
        ArchivedDocument[] GetArchivedDocumentsByCase(string caseId);
        Estate[] GetEstatesByCase(string caseId);
    }
}
