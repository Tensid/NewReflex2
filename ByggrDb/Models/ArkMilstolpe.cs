namespace ByggrDb
{
    public partial class ArkMilstolpe
    {
        public ArkMilstolpe()
        {
            ArkArendeTypMilstolpes = new HashSet<ArkArendeTypMilstolpe>();
            ArkHandelseSlags = new HashSet<ArkHandelseSlag>();
        }

        public int MilstolpeId { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool? ArAktiv { get; set; }

        public virtual ICollection<ArkArendeTypMilstolpe> ArkArendeTypMilstolpes { get; set; }
        public virtual ICollection<ArkHandelseSlag> ArkHandelseSlags { get; set; }
    }
}