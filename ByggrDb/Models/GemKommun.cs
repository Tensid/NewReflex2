namespace ByggrDb
{
    public partial class GemKommun
    {
        public GemKommun()
        {
            ArkArendes = new HashSet<ArkArende>();
            GemObjekts = new HashSet<GemObjekt>();
            Namnds = new HashSet<ArkNamnd>();
        }

        public string KomKod { get; set; } = null!;
        public string Kommun { get; set; } = null!;

        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<GemObjekt> GemObjekts { get; set; }

        public virtual ICollection<ArkNamnd> Namnds { get; set; }
    }
}