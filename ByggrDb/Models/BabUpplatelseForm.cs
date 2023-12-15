namespace ByggrDb
{
    public partial class BabUpplatelseForm
    {
        public BabUpplatelseForm()
        {
            BabArendes = new HashSet<BabArende>();
        }

        public int UpplatelseFormId { get; set; }
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<BabArende> BabArendes { get; set; }
    }
}