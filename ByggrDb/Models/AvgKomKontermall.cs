namespace ByggrDb
{
    public partial class AvgKomKontermall
    {
        public int KonterMallId { get; set; }
        public string KomKod { get; set; } = null!;
        public string? KontoDel1 { get; set; }
        public string? KontoDel2 { get; set; }
        public string? KontoDel3 { get; set; }
        public string? KontoDel4 { get; set; }
        public string? KontoDel5 { get; set; }
        public string? KontoDel6 { get; set; }
        public string? KontoDel7 { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime RegDatum { get; set; }
    }
}