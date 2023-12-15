namespace ByggrDb
{
    public partial class DebSystemParam
    {
        public int SystemId { get; set; }
        public int EkSystemId { get; set; }
        public string KomKod { get; set; } = null!;
        public string? FtgId { get; set; }
        public string? RutinKod { get; set; }
        public string? BestallKod { get; set; }
        public string? FaktGrp { get; set; }
        public string? KundNr { get; set; }
        public string? AvsRutinKod { get; set; }
        public string? FilPrefix { get; set; }
        public string? BearbetnTyp { get; set; }
        public string? UserName { get; set; }
        public DateTime? RegDatum { get; set; }
    }
}