namespace ByggrDb
{
    public partial class ArkHandelsePersOrgVersionRoll
    {
        public ArkHandelsePersOrgVersionRoll()
        {
            ArkBevakatUtskickSvars = new HashSet<ArkBevakatUtskickSvar>();
            ArkBevakatUtskicks = new HashSet<ArkBevakatUtskick>();
        }

        public int Rollid { get; set; }
        public int HandelsePersOrgVersionId { get; set; }
        public DateTime? RollDatum { get; set; }

        public virtual ArkHandelsePersOrgVersion HandelsePersOrgVersion { get; set; } = null!;
        public virtual GemPersOrgRoll Roll { get; set; } = null!;
        public virtual ICollection<ArkBevakatUtskickSvar> ArkBevakatUtskickSvars { get; set; }
        public virtual ICollection<ArkBevakatUtskick> ArkBevakatUtskicks { get; set; }
    }
}