namespace ByggrDb
{
    public partial class GemPersOrgAttention
    {
        public GemPersOrgAttention()
        {
            ArkArendePersOrgVersions = new HashSet<ArkArendePersOrgVersion>();
            ArkHandelsePersOrgVersions = new HashSet<ArkHandelsePersOrgVersion>();
            GemPersOrgKommunikations = new HashSet<GemPersOrgKommunikation>();
        }

        public int PersOrgAttentionId { get; set; }
        public int PersOrgId { get; set; }
        public string Attention { get; set; } = null!;
        public string? Referens { get; set; }
        public bool ArAktiv { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDat { get; set; }
        public string? Persnr { get; set; }

        public virtual GemPersOrg PersOrg { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ICollection<ArkArendePersOrgVersion> ArkArendePersOrgVersions { get; set; }
        public virtual ICollection<ArkHandelsePersOrgVersion> ArkHandelsePersOrgVersions { get; set; }
        public virtual ICollection<GemPersOrgKommunikation> GemPersOrgKommunikations { get; set; }
    }
}