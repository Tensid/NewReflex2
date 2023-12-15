namespace ByggrDb
{
    public partial class ArkProdukt
    {
        public ArkProdukt()
        {
            ArkEnhets = new HashSet<ArkEnhet>();
        }

        public int ProduktId { get; set; }
        public string Produkt { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<ArkEnhet> ArkEnhets { get; set; }
    }
}