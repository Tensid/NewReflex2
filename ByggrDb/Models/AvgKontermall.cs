namespace ByggrDb
{
    public partial class AvgKontermall
    {
        public int KonterMallId { get; set; }
        public string KonterMallBen { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime RegDatum { get; set; }
    }
}