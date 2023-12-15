namespace ByggrDb
{
    public partial class DebAvgift
    {
        public int DebId { get; set; }
        public int AvgLopNr { get; set; }
        public int AvgiftTypId { get; set; }
        public string? AvgiftKod { get; set; }
        public string? AvgiftBen { get; set; }
        public string? AvgiftSpec { get; set; }
        public string? ArtikelKod { get; set; }
        public string? ArtikelBen { get; set; }
        public decimal? DebPeriodFrom { get; set; }
        public decimal? DebPeriodTom { get; set; }
        public decimal BeloppNetto { get; set; }
        public string? MomsKod { get; set; }
        public decimal? Antal { get; set; }
        public decimal? Apris { get; set; }
        public decimal? ObjektFaktor { get; set; }
        public int? Area { get; set; }
        public decimal? ViktFaktor { get; set; }
        public int? SortOrdning { get; set; }
        public string? KontoDel1 { get; set; }
        public string? KontoDel2 { get; set; }
        public string? KontoDel3 { get; set; }
        public string? KontoDel4 { get; set; }
        public string? KontoDel5 { get; set; }
        public string? KontoDel6 { get; set; }
        public string? KontoDel7 { get; set; }
    }
}