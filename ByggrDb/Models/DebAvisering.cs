namespace ByggrDb
{
    public partial class DebAvisering
    {
        public int AvisId { get; set; }
        public int? SystemId { get; set; }
        public DateTime RegDatum { get; set; }
        public int? EkSystemId { get; set; }
        public string StartTid { get; set; } = null!;
        public string SlutTid { get; set; } = null!;
        public int AntalFakt { get; set; }
        public int AntalFaktRader { get; set; }
        public decimal BeloppNetto { get; set; }
        public string Status { get; set; } = null!;
        public int? OmkornAvisId { get; set; }
        public int AntalFiler { get; set; }
        public string FilNamn { get; set; } = null!;
        public int? AntalExtFakt { get; set; }
        public int? AntalExtFaktRader { get; set; }
        public decimal? BeloppNettoExt { get; set; }
        public int? AntalIntFakt { get; set; }
        public int? AntalIntFaktRader { get; set; }
        public decimal? BeloppNettoInt { get; set; }
        public string UserName { get; set; } = null!;
        public string KomKod { get; set; } = null!;
    }
}