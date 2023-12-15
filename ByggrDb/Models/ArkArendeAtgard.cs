namespace ByggrDb
{
    public partial class ArkArendeAtgard
    {
        public int ArendeId { get; set; }
        public int AtgardId { get; set; }
        public short Kategori { get; set; }
        public int? ArendeSlagId { get; set; }
        public int? ArendeKlassId { get; set; }

        public virtual ArkArende Arende { get; set; } = null!;
        public virtual ArkArendeKlass? ArendeKlass { get; set; }
        public virtual ArkArendeSlag? ArendeSlag { get; set; }
        public virtual BabAtgard BabAtgard { get; set; } = null!;
    }
}