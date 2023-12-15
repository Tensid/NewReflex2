namespace ByggrDb
{
    public partial class ArkHandelsePersOrgVersion
    {
        public ArkHandelsePersOrgVersion()
        {
            ArkBevakatUtskickPams = new HashSet<ArkBevakatUtskickPam>();
            ArkBevakatUtskickSvars = new HashSet<ArkBevakatUtskickSvar>();
            ArkBevakatUtskicks = new HashSet<ArkBevakatUtskick>();
            ArkHandelsePersOrgVersionRolls = new HashSet<ArkHandelsePersOrgVersionRoll>();
        }

        public int HandelsePersOrgVersionId { get; set; }
        public int HandelseId { get; set; }
        public int PersOrgVersionId { get; set; }
        public int? PersOrgAttentionId { get; set; }
        public DateTime? UpdDatum { get; set; }
        public int? PersorgKomunikationTypId { get; set; }
        public byte? SendChannel { get; set; }
        public bool? ArSand { get; set; }

        public virtual ArkHandelse Handelse { get; set; } = null!;
        public virtual GemPersOrgAttention? PersOrgAttention { get; set; }
        public virtual GemPersOrgVersion PersOrgVersion { get; set; } = null!;
        public virtual GemPersOrgKommunikation? PersorgKomunikationTyp { get; set; }
        public virtual ICollection<ArkBevakatUtskickPam> ArkBevakatUtskickPams { get; set; }
        public virtual ICollection<ArkBevakatUtskickSvar> ArkBevakatUtskickSvars { get; set; }
        public virtual ICollection<ArkBevakatUtskick> ArkBevakatUtskicks { get; set; }
        public virtual ICollection<ArkHandelsePersOrgVersionRoll> ArkHandelsePersOrgVersionRolls { get; set; }
    }
}