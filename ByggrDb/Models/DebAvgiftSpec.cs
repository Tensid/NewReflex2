namespace ByggrDb
{
    public partial class DebAvgiftSpec
    {
        public int DebId { get; set; }
        public int AvgLopNr { get; set; }
        public int SpecLopNr { get; set; }
        public int AvgiftTypId { get; set; }
        public int DelAvgLopNr { get; set; }
        public string? AvgiftBen { get; set; }
        public string? AvgiftSpec { get; set; }
        public decimal? BeloppNetto { get; set; }
        public decimal? ViktFaktor { get; set; }
    }
}