namespace ByggrDb
{
    public partial class AvgKontoDef
    {
        public decimal KontoDelNr { get; set; }
        public string LedText { get; set; } = null!;
        public decimal KontoDelLen { get; set; }
        public bool ArAktiv { get; set; }
        public string KomKod { get; set; } = null!;
    }
}