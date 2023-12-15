namespace ByggrDb
{
    public partial class GdRbArendeGeofirYtaV1
    {
        public int? RadId { get; set; }
        public int Arendeid { get; set; }
        public string Dnr { get; set; } = null!;
        public string Enhetkod { get; set; } = null!;
        public string Enhet { get; set; } = null!;
        public string Namndkod { get; set; } = null!;
        public string Namnd { get; set; } = null!;
        public int Diarieid { get; set; }
        public string? Diarieprefix { get; set; }
        public string Diarie { get; set; } = null!;
        public int Arendegruppid { get; set; }
        public string Arendegruppkod { get; set; } = null!;
        public string Arendegrupp { get; set; } = null!;
        public int Arendetypid { get; set; }
        public string Arendetypkod { get; set; } = null!;
        public string Arendetyp { get; set; } = null!;
        public int? Arendeslagid { get; set; }
        public string? Arendeslagkod { get; set; }
        public string? Arendeslag { get; set; }
        public int? Arendeklassid { get; set; }
        public string? Arendeklasskod { get; set; }
        public string? Arendeklass { get; set; }
        public string Arendemening { get; set; } = null!;
        public string Arendestatuskod { get; set; } = null!;
        public string Arendestatus { get; set; } = null!;
        public decimal Arendekalla { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime? Slutdatum { get; set; }
        public int? Alder { get; set; }
        public bool? Arinomplan { get; set; }
        public bool? Arsammanhbebygg { get; set; }
        public int Fnr { get; set; }
        public string? Cfdfnr { get; set; }
        public string? Komkod { get; set; }
        public string? Fastighet { get; set; }
        public string? Trakt { get; set; }
        public string? Fbetnr { get; set; }
        public int? Omr { get; set; }
        public string? Punkttyp { get; set; }
        public double? Xkoord { get; set; }
        public double? Ykoord { get; set; }
        public string? OmrMapid { get; set; }
    }
}