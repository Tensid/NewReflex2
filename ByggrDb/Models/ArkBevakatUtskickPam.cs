namespace ByggrDb
{
    public partial class ArkBevakatUtskickPam
    {
        public int ArendeId { get; set; }
        public int HandelseIdUtskick { get; set; }
        public int UtskickId { get; set; }
        public int HandelseIdPaminn { get; set; }
        public int HandelsePersOrgVersionId { get; set; }
        public string? UtskickText { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }

        public virtual ArkBevakatUtskick ArkBevakatUtskick { get; set; } = null!;
        public virtual ArkBevakatUtskickPamOmg ArkBevakatUtskickPamOmg { get; set; } = null!;
        public virtual ArkHandelsePersOrgVersion HandelsePersOrgVersion { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
    }
}