namespace ByggrDb
{
    public partial class GemIndividInventarie
    {
        public GemIndividInventarie()
        {
            BabArtikelLokations = new HashSet<BabArtikelLokation>();
        }

        public int IndividInventarieId { get; set; }
        public short Kategori { get; set; }
        public int ArtikelId { get; set; }
        public string? Beteckning { get; set; }

        public virtual BabArtikel Artikel { get; set; } = null!;
        public virtual GemHiss GemHiss { get; set; } = null!;
        public virtual ICollection<BabArtikelLokation> BabArtikelLokations { get; set; }
    }
}