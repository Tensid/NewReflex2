namespace ByggrDb
{
    public partial class ArkBevakatUtskick
    {
        public ArkBevakatUtskick()
        {
            ArkBevakatUtskickPams = new HashSet<ArkBevakatUtskickPam>();
            ArkBevakatUtskickSvars = new HashSet<ArkBevakatUtskickSvar>();
        }

        public int ArendeId { get; set; }
        public int HandelseIdUtskick { get; set; }
        public int UtskickId { get; set; }
        public int HandelsePersOrgVersionId { get; set; }
        public int? Rollid { get; set; }
        public int? ObjektId { get; set; }
        public string? Fastighet { get; set; }
        public string? UtskickText { get; set; }
        public bool Erfodras { get; set; }
        public DateTime? SenastSvarDatum { get; set; }
        public string? Anteckning { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }

        public virtual ArkBevakatUtskickOmg ArkBevakatUtskickOmg { get; set; } = null!;
        public virtual ArkHandelsePersOrgVersionRoll? ArkHandelsePersOrgVersionRoll { get; set; }
        public virtual ArkHandelsePersOrgVersion HandelsePersOrgVersion { get; set; } = null!;
        public virtual GemObjekt? Objekt { get; set; }
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ICollection<ArkBevakatUtskickPam> ArkBevakatUtskickPams { get; set; }
        public virtual ICollection<ArkBevakatUtskickSvar> ArkBevakatUtskickSvars { get; set; }
    }
}