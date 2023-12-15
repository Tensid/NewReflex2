namespace ByggrDb
{
    public partial class GemPersOrgBehorighet
    {
        public int PersOrgBehorighetId { get; set; }
        public int PersOrgId { get; set; }
        public int Rollid { get; set; }
        public int? PersOrgBehorighetNivaId { get; set; }
        public string? GodkandAv { get; set; }
        public DateTime? GodkandTillDatum { get; set; }
        public string? BehorighetsNr { get; set; }
        public string? Anteckning { get; set; }
        public bool Riksbehorighet { get; set; }
        public DateTime? IntygsDatum { get; set; }
        public DateTime RegDatum { get; set; }

        public virtual GemPersOrg PersOrg { get; set; } = null!;
        public virtual GemPersOrgBehorighetNiva? PersOrgBehorighetNiva { get; set; }
        public virtual GemPersOrgRoll Roll { get; set; } = null!;
    }
}