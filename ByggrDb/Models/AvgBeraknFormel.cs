namespace ByggrDb
{
    public partial class AvgBeraknFormel
    {
        public int FormelId { get; set; }
        public string FormelBen { get; set; } = null!;
        public string BeraknFormel { get; set; } = null!;
        public bool ArFast { get; set; }
    }
}