namespace ByggrDb
{
    public partial class ArkHandlaggareRoll
    {
        public ArkHandlaggareRoll()
        {
            ArkArendeHandls = new HashSet<ArkArendeHandlaggare>();
        }

        public int HandlaggareRollId { get; set; }
        public string Roll { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int? EnhetId { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ArkEnhet? Enhet { get; set; }

        public virtual ICollection<ArkArendeHandlaggare> ArkArendeHandls { get; set; }
    }
}