namespace ByggrDb
{
    public partial class BabArtikelLokation
    {
        public int ArtikelLokationId { get; set; }
        public short Kategori { get; set; }
        public int? ArtikelId { get; set; }
        public int? IndividInventarieId { get; set; }
        public int LokationId { get; set; }
        public int Antal { get; set; }
        public string? Anteckning { get; set; }

        public virtual BabArtikel? Artikel { get; set; }
        public virtual GemIndividInventarie? IndividInventarie { get; set; }
        public virtual BabLokation Lokation { get; set; } = null!;
        public virtual BabBostadsAnpassning BabBostadsAnpassning { get; set; } = null!;
        public virtual BabLagringsPlat BabLagringsPlat { get; set; } = null!;
    }
}