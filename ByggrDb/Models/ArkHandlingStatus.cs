namespace ByggrDb
{
    public partial class ArkHandlingStatus
    {
        public ArkHandlingStatus()
        {
            ArkHandelseFordefinierads = new HashSet<ArkHandelseFordefinierad>();
            ArkHandlings = new HashSet<ArkHandling>();
        }

        public int HandlingStatusId { get; set; }
        public string Status { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<ArkHandelseFordefinierad> ArkHandelseFordefinierads { get; set; }
        public virtual ICollection<ArkHandling> ArkHandlings { get; set; }
    }
}