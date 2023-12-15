namespace ByggrDb
{
    public partial class ArkBevakatUtskickPamOmg
    {
        public ArkBevakatUtskickPamOmg()
        {
            ArkBevakatUtskickPams = new HashSet<ArkBevakatUtskickPam>();
        }

        public int ArendeId { get; set; }
        public int HandelseIdUtskick { get; set; }
        public int HandelseIdPaminn { get; set; }
        public string? MeddelandeMall { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }

        public virtual ArkBevakatUtskickOmg ArkBevakatUtskickOmg { get; set; } = null!;
        public virtual ArkHandelse HandelseIdPaminnNavigation { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ICollection<ArkBevakatUtskickPam> ArkBevakatUtskickPams { get; set; }
    }
}