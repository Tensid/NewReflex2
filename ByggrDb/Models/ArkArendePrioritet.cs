namespace ByggrDb
{
    public partial class ArkArendePrioritet
    {
        public ArkArendePrioritet()
        {
            ArkArendes = new HashSet<ArkArende>();
        }

        public short ArendePrioritetId { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ICollection<ArkArende> ArkArendes { get; set; }
    }
}