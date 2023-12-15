namespace ByggrDb
{
    public partial class GemPersOrgVersion
    {
        public GemPersOrgVersion()
        {
            ArkArendePersOrgVersions = new HashSet<ArkArendePersOrgVersion>();
            ArkHandelsePersOrgVersions = new HashSet<ArkHandelsePersOrgVersion>();
        }

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

        public virtual GemPersOrg PersOrg { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ICollection<ArkArendePersOrgVersion> ArkArendePersOrgVersions { get; set; }
        public virtual ICollection<ArkHandelsePersOrgVersion> ArkHandelsePersOrgVersions { get; set; }
    }
}