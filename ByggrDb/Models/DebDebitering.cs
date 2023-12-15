namespace ByggrDb
{
    public partial class DebDebitering
    {
        public int DebId { get; set; }
        public int SystemId { get; set; }
        public string KomKod { get; set; } = null!;
        public decimal? GrundBelopp { get; set; }
        public string? ObjektIdent { get; set; }
        public decimal? AviPeriod { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime RegDatum { get; set; }
    }
}