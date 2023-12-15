namespace ByggrDb
{
    public partial class GemPersOrgKommunikation
    {
        public GemPersOrgKommunikation()
        {
            ArkHandelsePersOrgVersions = new HashSet<ArkHandelsePersOrgVersion>();
        }

        public int PersorgKomunikationTypId { get; set; }
        public int PersOrgId { get; set; }
        public int? PersOrgAttentionId { get; set; }
        public int KomTypId { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual GemKommunikationTyp KomTyp { get; set; } = null!;
        public virtual GemPersOrg PersOrg { get; set; } = null!;
        public virtual GemPersOrgAttention? PersOrgAttention { get; set; }
        public virtual ICollection<ArkHandelsePersOrgVersion> ArkHandelsePersOrgVersions { get; set; }
    }
}