namespace ByggrDb
{
    public partial class ArkArendePersOrgVersion
    {
        public ArkArendePersOrgVersion()
        {
            ArkArendePersOrgVersionRolls = new HashSet<ArkArendePersOrgVersionRoll>();
        }

        public int ArendePersOrgVersionId { get; set; }
        public int ArendeId { get; set; }
        public int PersOrgVersionId { get; set; }
        public int? PersOrgAttentionId { get; set; }
        public DateTime? UpdDatum { get; set; }

        public virtual ArkArende Arende { get; set; } = null!;
        public virtual GemPersOrgAttention? PersOrgAttention { get; set; }
        public virtual GemPersOrgVersion PersOrgVersion { get; set; } = null!;
        public virtual ICollection<ArkArendePersOrgVersionRoll> ArkArendePersOrgVersionRolls { get; set; }
    }
}