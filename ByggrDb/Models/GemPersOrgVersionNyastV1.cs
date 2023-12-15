namespace ByggrDb
{
    public partial class GemPersOrgVersionNyastV1
    {
        public int PersOrgVersionId { get; set; }
        public int PersOrgId { get; set; }
        public int PersOrgVersion { get; set; }
        public string Namn { get; set; } = null!;
        public string? ForNamn { get; set; }
        public string? EfterNamn { get; set; }
        public string? GatuAdress { get; set; }
        public string? CoAdress { get; set; }
        public string? PostNr { get; set; }
        public string? PostOrt { get; set; }
        public string? Land { get; set; }
        public string? BesokAdress { get; set; }
        public DateTime UpdDatum { get; set; }
        public int UpdSignId { get; set; }
        public int? RefPersOrgId { get; set; }
        public int PersOrgTypId { get; set; }
        public string? PersOrgNr { get; set; }
        public bool ArForetag { get; set; }
        public bool ArInternKund { get; set; }
        public string? Referensnr { get; set; }
        public bool ArRemissInstans { get; set; }
        public string? FsKundnr { get; set; }
        public int? Pid { get; set; }
        public string? Anteckning { get; set; }
        public int? PersOrgBehorighetId { get; set; }
        public int? Rollid { get; set; }
        public int? PersOrgBehorighetNivaId { get; set; }
        public string? GodkandAv { get; set; }
        public DateTime? GodkandTillDatum { get; set; }
        public string? BehorighetsNr { get; set; }
        public string? PersOrgBehAnteckning { get; set; }
        public bool? Riksbehorighet { get; set; }
        public DateTime? IntygsDatum { get; set; }
        public DateTime? RegDatum { get; set; }
    }
}