namespace VisaRService.Contracts
{
    public class Handelse : Occurence
    {
        public string Anteckning { get; set; }
        public string BeslutsText { get; set; }
        public string BeslutNr { get; set; }
        public string Handelsetyp { get; set; }
    }

    public class Preview
    {
        public string CaseId { get; set; }
        public string Dnr { get; set; }
        public CasePerson[] Persons { get; set; }
        public Handelse[] Handelser { get; set; }
        public string Status { get; set; }
        public string Arendegrupp { get; set; }
        public string Arendetyp { get; set; }
        public string Arendeslag { get; set; }
        public string Fastighetsbeteckning { get; set; }
        public string HandlaggareEfternamn { get; set; }
        public string HandlaggareFornamn { get; set; }
        public string HandlaggareSignatur { get; set; }
    }
}
