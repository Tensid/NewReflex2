namespace ByggrDb
{
    public partial class ArkGenerellHandlingGenerellHandlingKategori
    {
        public int GenerellHandlingGenerellHandlingKategoriId { get; set; }
        public int GenerellHandlingId { get; set; }
        public int GenerellHandlingKategoriId { get; set; }

        public virtual ArkGenerellHandling GenerellHandling { get; set; } = null!;
        public virtual ArkGenerellHandlingKategori GenerellHandlingKategori { get; set; } = null!;
    }
}