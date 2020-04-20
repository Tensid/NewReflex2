using System;

namespace VisaRService.Contracts
{
    public class Case
    {
        public string CaseId { get; set; }
        public string Dnr { get; set; }
        public string Title { get; set; }
        public string CaseSource { get; set; }
        public DateTime Date { get; set; }
        public bool UnavailableDueToSecrecy { get; set; }
        public string Status { get; set; }
        public string Arendegrupp { get; set; }
        public string Arendetyp { get; set; }
        public string Arendeslag { get; set; }
        public string Fastighetsbeteckning { get; set; }
        public string Kommun { get; set; }
        public string Beskrivning { get; set; }
        public string HandlaggareEfternamn { get; set; }
        public string HandlaggareFornamn { get; set; }
        public string HandlaggareSignatur { get; set; }
    }
}
