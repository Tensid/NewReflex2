namespace ByggrDb
{
    public partial class GemCounter
    {
        public string Module { get; set; } = null!;
        public string Counter { get; set; } = null!;
        public int ValOfCount { get; set; }
        public string? Counterprefix { get; set; }
        public string? Countersuffix { get; set; }
        public int? Counterlength { get; set; }
    }
}