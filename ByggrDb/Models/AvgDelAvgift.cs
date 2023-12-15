namespace ByggrDb
{
    public partial class AvgDelAvgift
    {
        public int AvgiftTypId { get; set; }
        public int DelAvgLopNr { get; set; }
        public string? AvgiftBen { get; set; }
        public string? AvgiftSpec { get; set; }
        public decimal? ViktFaktor { get; set; }
        public decimal? SortOrdning { get; set; }
        public int FormelId { get; set; }
        public bool ArAktiv { get; set; }
    }
}