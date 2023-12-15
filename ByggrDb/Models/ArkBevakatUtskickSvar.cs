namespace ByggrDb
{
    public partial class ArkBevakatUtskickSvar
    {
        public int ArendeId { get; set; }
        public int HandelseIdUtskick { get; set; }
        public int UtskickId { get; set; }
        public int HandelseIdSvar { get; set; }
        public int HandelsePersOrgVersionId { get; set; }
        public int? Rollid { get; set; }
        public bool Erinran { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }

        public virtual ArkBevakatUtskick ArkBevakatUtskick { get; set; } = null!;
        public virtual ArkHandelsePersOrgVersionRoll? ArkHandelsePersOrgVersionRoll { get; set; }
        public virtual ArkHandelse HandelseIdSvarNavigation { get; set; } = null!;
        public virtual ArkHandelsePersOrgVersion HandelsePersOrgVersion { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
    }
}