namespace ByggrDb
{
    public partial class GemPersOrgAdress
    {
        public int PersOrgId { get; set; }
        public string? Attention { get; set; }
        public string? GatuAdress { get; set; }
        public string? CoAdress { get; set; }
        public string? PostNr { get; set; }
        public string? PostOrt { get; set; }
        public string? Land { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDat { get; set; }

        public virtual GemPersOrg PersOrg { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
    }
}