namespace ByggrDb
{
    public partial class GdRbFriHandelsGeofirYtaV1
    {
        public int? RadId { get; set; }
        public int Handelseid { get; set; }
        public DateTime Handelsedatum { get; set; }
        public string Handelserubrik { get; set; } = null!;
        public int Handelsetypid { get; set; }
        public string Handelsetypkod { get; set; } = null!;
        public string Handelsetyp { get; set; } = null!;
        public int? Handelsetyprutinid { get; set; }
        public int? Handelsetyprutinkodid { get; set; }
        public int? Handelseslagid { get; set; }
        public string? Handelseslagkod { get; set; }
        public string? Handelseslag { get; set; }
        public int? Handelseslagrutinid { get; set; }
        public int? Handelseslagrutinkodid { get; set; }
        public int? Handelseutfallsid { get; set; }
        public string? Handelseutfallkod { get; set; }
        public string? Handelseutfall { get; set; }
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