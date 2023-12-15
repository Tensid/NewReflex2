namespace ByggrDb
{
    public partial class ArkNotifiering
    {
        public int NotifieringId { get; set; }
        public int NotifieringKlassId { get; set; }
        public DateTime NotifieringDatum { get; set; }
        public DateTime? KvitteradDatum { get; set; }
        public int HandlaggareId { get; set; }
        public int? KvitteradAvHandlaggareId { get; set; }
        public int? ArendeId { get; set; }
        public int? HandelseId { get; set; }
        public int? BevakatUtskickOmgang { get; set; }
        public int? InkorgId { get; set; }
        public DateTime UpdDatum { get; set; }
        public DateTime RegDatum { get; set; }
        public int RegSignId { get; set; }

        public virtual ArkArende? Arende { get; set; }
        public virtual ArkHandelse? Handelse { get; set; }
        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;
        public virtual ArkInkorg? Inkorg { get; set; }
        public virtual ArkHandlaggare? KvitteradAvHandlaggare { get; set; }
        public virtual ArkNotifieringKlass NotifieringKlass { get; set; } = null!;
        public virtual ArkHandlaggare RegSign { get; set; } = null!;
    }
}