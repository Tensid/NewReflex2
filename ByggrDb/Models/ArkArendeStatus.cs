namespace ByggrDb
{
    public partial class ArkArendeStatus
    {
        public ArkArendeStatus()
        {
            ArkArendes = new HashSet<ArkArende>();
        }

        public decimal StatusId { get; set; }
        public string Status { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<ArkArende> ArkArendes { get; set; }
    }
}