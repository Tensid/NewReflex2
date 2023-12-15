namespace ByggrDb
{
    public partial class ArkBevakatUtskickOmg
    {
        public ArkBevakatUtskickOmg()
        {
            ArkBevakatUtskickPamOmgs = new HashSet<ArkBevakatUtskickPamOmg>();
            ArkBevakatUtskicks = new HashSet<ArkBevakatUtskick>();
        }

        public int ArendeId { get; set; }
        public int HandelseIdUtskick { get; set; }
        public short UtskickTyp { get; set; }
        public short Omgang { get; set; }
        public string? MeddelandeMall { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }

        public virtual ArkArende Arende { get; set; } = null!;
        public virtual ArkHandelse HandelseIdUtskickNavigation { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ICollection<ArkBevakatUtskickPamOmg> ArkBevakatUtskickPamOmgs { get; set; }
        public virtual ICollection<ArkBevakatUtskick> ArkBevakatUtskicks { get; set; }
    }
}