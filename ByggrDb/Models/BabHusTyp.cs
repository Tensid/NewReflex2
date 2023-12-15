namespace ByggrDb
{
    public partial class BabHusTyp
    {
        public BabHusTyp()
        {
            BabArendes = new HashSet<BabArende>();
        }

        public int HusTypId { get; set; }
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<BabArende> BabArendes { get; set; }
    }
}