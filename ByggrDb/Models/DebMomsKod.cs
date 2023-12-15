namespace ByggrDb
{
    public partial class DebMomsKod
    {
        public string MomsKod { get; set; } = null!;
        public int EkSystemId { get; set; }
        public string? ExtMomsKod { get; set; }
        public string? MomsKonto { get; set; }
        public string KomKod { get; set; } = null!;
    }
}