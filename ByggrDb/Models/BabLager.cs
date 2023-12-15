namespace ByggrDb
{
    public partial class BabLager
    {
        public BabLager()
        {
            BabLagringsPlats = new HashSet<BabLagringsPlat>();
        }

        public int LagerId { get; set; }
        public int LokationId { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual BabLokation Lokation { get; set; } = null!;
        public virtual ICollection<BabLagringsPlat> BabLagringsPlats { get; set; }
    }
}