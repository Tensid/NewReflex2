namespace ByggrDb
{
    public partial class AvgAvgiftTyp
    {
        public int AvgiftTypId { get; set; }
        public int AvgiftGruppId { get; set; }
        public bool ArLopande { get; set; }
        public int BeloppTypId { get; set; }
        public string AvgiftKod { get; set; } = null!;
        public string AvgiftBen { get; set; } = null!;
        public string? AvgiftSpec { get; set; }
        public string? ArtikelKod { get; set; }
        public string? ArtikelBen { get; set; }
        public string MomsKod { get; set; } = null!;
        public int? FormelId { get; set; }
        public int? OftabellId { get; set; }
        public decimal? ViktFaktor { get; set; }
        public int KonterMallId { get; set; }
        public int? IndexBeraknId { get; set; }
        public decimal? BasAr { get; set; }
        public decimal? IndexFaktor { get; set; }
        public decimal? PeriodLangd { get; set; }
        public bool VisaDelAvgifter { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime RegDatum { get; set; }
        public bool ArAktiv { get; set; }
    }
}