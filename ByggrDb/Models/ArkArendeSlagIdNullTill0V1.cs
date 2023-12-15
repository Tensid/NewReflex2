namespace ByggrDb
{
    public partial class ArkArendeSlagIdNullTill0V1
    {
        public int ArendeId { get; set; }
        public string Dnr { get; set; } = null!;
        public int ArendeGruppId { get; set; }
        public int ArendeTypId { get; set; }
        public int? ArendeSlagId { get; set; }
        public string ArendeMening { get; set; } = null!;
        public string? ExtDnr { get; set; }
        public DateTime AnkomstDatum { get; set; }
        public DateTime? SlutDatum { get; set; }
        public DateTime? FasStartDatum { get; set; }
        public decimal StatusId { get; set; }
        public DateTime? VilandeDatum { get; set; }
        public DateTime? MakDatum { get; set; }
        public DateTime? GallringsDatum { get; set; }
        public decimal? GallringsAr { get; set; }
        public string? Anteckning { get; set; }
        public int? RegSignId { get; set; }
        public DateTime RegDatum { get; set; }
        public DateTime UpdDatum { get; set; }
        public int UpdSignId { get; set; }
        public string KomKod { get; set; } = null!;
        public int NamndId { get; set; }
        public int EnhetId { get; set; }
        public int DiarieId { get; set; }
        public string? XmlForhandsGranska { get; set; }
        public int? ArendeKlassId { get; set; }
        public int? ProcessId { get; set; }
        public int? ProcessFasId { get; set; }
        public DateTime? XmlUpdDatum { get; set; }
        public decimal Kalla { get; set; }
        public string? Uuid { get; set; }
        public bool? InomPlan { get; set; }
        public string? ProjektNr { get; set; }
        public int? ArendeSlagIdNullTillNoll { get; set; }
        public int? ArendeKlassIdNullTillNoll { get; set; }
    }
}