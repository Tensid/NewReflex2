namespace ByggrDb
{
    public partial class ArkArendeScbstatistik
    {
        public int ArendeId { get; set; }
        public int ScbstatistikId { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? SenastSandDatum { get; set; }
        public string? SenastSandMd5checksum { get; set; }

        public virtual ArkArende Arende { get; set; } = null!;
        public virtual ArkScbstatistik Scbstatistik { get; set; } = null!;
    }
}