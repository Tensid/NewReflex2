namespace ByggrDb
{
    public partial class DebFaktura
    {
        public int FakturaId { get; set; }
        public int SystemId { get; set; }
        public int DebId { get; set; }
        public string? FakturaText { get; set; }
        public DateTime RegDatum { get; set; }
        public DateTime? FakturaDatum { get; set; }
        public DateTime? ForfallDatum { get; set; }
        public DateTime? BetalDatum { get; set; }
        public bool ArSlutBetald { get; set; }
        public DateTime? MakulerDatum { get; set; }
        public decimal BeloppNetto { get; set; }
        public decimal Moms { get; set; }
        public bool InternKund { get; set; }
        public string? KundNr { get; set; }
        public string? PersOrgNr { get; set; }
        public string KundNamn { get; set; } = null!;
        public string? KundRef { get; set; }
        public string? GatuAdress { get; set; }
        public string? CoAdress { get; set; }
        public string? PostNr { get; set; }
        public string? PostOrt { get; set; }
        public string? Land { get; set; }
        public string? FaktRef { get; set; }
        public string? OrderIdent { get; set; }
        public string? FakturaIdent { get; set; }
        public string? BestallarIdent { get; set; }
        public int? AvisId { get; set; }
        public string UserName { get; set; } = null!;
        public bool ArAviseringsSparrad { get; set; }
        public bool? ArForetag { get; set; }
        public string? KundRefBestallarIdent { get; set; }
        public string? Motpart { get; set; }
    }
}