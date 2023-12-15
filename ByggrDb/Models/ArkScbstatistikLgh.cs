namespace ByggrDb
{
    public partial class ArkScbstatistikLgh
    {
        public int ScbstatistikId { get; set; }
        public int ScbstatistikLghId { get; set; }
        public bool ArEfterAtgard { get; set; }
        public decimal? AntalRum { get; set; }
        public int? Area { get; set; }
        public decimal? Antal { get; set; }
        public int ScblagenhetTypId { get; set; }
        public int ScbkokTypId { get; set; }

        public virtual ArkScbstatistik Scbstatistik { get; set; } = null!;
    }
}