namespace ByggrDb
{
    public partial class ArkGenerellHandlingKategori
    {
        public ArkGenerellHandlingKategori()
        {
            ArkGenerellHandlingGenerellHandlingKategoris = new HashSet<ArkGenerellHandlingGenerellHandlingKategori>();
        }

        public int GenerellHandlingKategoriId { get; set; }
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<ArkGenerellHandlingGenerellHandlingKategori> ArkGenerellHandlingGenerellHandlingKategoris { get; set; }
    }
}