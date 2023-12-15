namespace ByggrDb
{
    public partial class BabMappadArtikel
    {
        public int MappadArtikelId { get; set; }
        public int ArendeSlagId { get; set; }
        public int? ArendeKlassId { get; set; }
        public int ArtikelId { get; set; }

        public virtual ArkArendeKlass? ArendeKlass { get; set; }
        public virtual ArkArendeSlag ArendeSlag { get; set; } = null!;
        public virtual BabArtikel Artikel { get; set; } = null!;
    }
}