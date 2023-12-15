namespace ByggrDb
{
    public partial class ArkScbstatistik
    {
        public ArkScbstatistik()
        {
            ArkArendeScbstatistiks = new HashSet<ArkArendeScbstatistik>();
            ArkScbstatistikLghs = new HashSet<ArkScbstatistikLgh>();
        }

        public int ScbstatistikId { get; set; }
        public decimal ScblovTypId { get; set; }
        public int ScbbyggnadTypId { get; set; }
        public string? ByggnadTypSpec { get; set; }
        public int ScbatgardTypId { get; set; }
        public int? ScbupplatelseFormId { get; set; }
        public DateTime? BeviljatDatum { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? SlutDatum { get; set; }
        public decimal? BruttoArea { get; set; }
        public decimal? ByggnadsAr { get; set; }
        public decimal? BostadsAreaFore { get; set; }
        public decimal? BostadsAreaEfter { get; set; }
        public decimal? AntalLghFore { get; set; }
        public decimal? AntalLghEfter { get; set; }
        public string AktuellMd5checksum { get; set; } = null!;

        public virtual ICollection<ArkArendeScbstatistik> ArkArendeScbstatistiks { get; set; }
        public virtual ICollection<ArkScbstatistikLgh> ArkScbstatistikLghs { get; set; }
    }
}