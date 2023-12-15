namespace ByggrDb
{
    public partial class ArkarendeGeofirV1
    {
        public int? RadId { get; set; }
        public int Arendeid { get; set; }
        public string Dnr { get; set; } = null!;
        public int Enhetid { get; set; }
        public string Enhet { get; set; } = null!;
        public int Namndid { get; set; }
        public string Namnd { get; set; } = null!;
        public int Diarieid { get; set; }
        public int Arendegruppid { get; set; }
        public string Arendegrupp { get; set; } = null!;
        public int Arendetypid { get; set; }
        public string Arendetyp { get; set; } = null!;
        public int? Arendeslagid { get; set; }
        public string? Arendeslag { get; set; }
        public int? Arendeklassid { get; set; }
        public string? Arendeklass { get; set; }
        public string Arendemening { get; set; } = null!;
        public decimal Arendestatusid { get; set; }
        public string Arendestatus { get; set; } = null!;
        public DateTime Startdatum { get; set; }
        public DateTime? Slutdatum { get; set; }
        public DateTime? Hbeslutdatum { get; set; }
        public string? Hbeslutnr { get; set; }
        public string? Hbeslututfall { get; set; }
        public DateTime? Hbeslutgiltigtilldatum { get; set; }
        public string Objekt { get; set; } = null!;
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
    }
}