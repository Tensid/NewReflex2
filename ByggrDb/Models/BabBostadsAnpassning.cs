namespace ByggrDb
{
    public partial class BabBostadsAnpassning
    {
        public BabBostadsAnpassning()
        {
            BabAtgards = new HashSet<BabAtgard>();
            BabBrukares = new HashSet<BabBrukare>();
        }

        public int ArtikelLokationId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime? AterstalldDatum { get; set; }

        public virtual BabArtikelLokation ArtikelLokation { get; set; } = null!;
        public virtual ICollection<BabAtgard> BabAtgards { get; set; }
        public virtual ICollection<BabBrukare> BabBrukares { get; set; }
    }
}