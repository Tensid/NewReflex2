namespace ByggrDb
{
    public partial class BabArtikel
    {
        public BabArtikel()
        {
            BabArtikelLokations = new HashSet<BabArtikelLokation>();
            BabMappadArtikels = new HashSet<BabMappadArtikel>();
            GemIndividInventaries = new HashSet<GemIndividInventarie>();
        }

        public int ArtikelId { get; set; }
        public short Kategori { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool Aterbrukbar { get; set; }
        public bool Aterstallbar { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ICollection<BabArtikelLokation> BabArtikelLokations { get; set; }
        public virtual ICollection<BabMappadArtikel> BabMappadArtikels { get; set; }
        public virtual ICollection<GemIndividInventarie> GemIndividInventaries { get; set; }
    }
}