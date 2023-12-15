namespace ByggrDb
{
    public partial class ArkHandelseUtfall
    {
        public ArkHandelseUtfall()
        {
            ArkHandelseFordefinierads = new HashSet<ArkHandelseFordefinierad>();
            ArkHandelseHandelseUtfalls = new HashSet<ArkHandelse>();
            ArkHandelseHandelses = new HashSet<ArkHandelse>();
        }

        public int HandelseUtfallsId { get; set; }
        public string HandelseUtfall { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int Resultat { get; set; }
        public int HandelseSlagId { get; set; }
        public string? Rubrik { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ArkHandelseSlag HandelseSlag { get; set; } = null!;
        public virtual ICollection<ArkHandelseFordefinierad> ArkHandelseFordefinierads { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseHandelseUtfalls { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseHandelses { get; set; }
    }
}