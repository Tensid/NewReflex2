namespace ByggrDb
{
    public partial class ArkArendeHandlaggare
    {
        public ArkArendeHandlaggare()
        {
            HandlaggareRolls = new HashSet<ArkHandlaggareRoll>();
        }

        public int ArkArendeHandlId { get; set; }
        public int ArendeId { get; set; }
        public int HandlaggareId { get; set; }
        public bool ArHvdHandl { get; set; }

        public virtual ArkArende Arende { get; set; } = null!;
        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;

        public virtual ICollection<ArkHandlaggareRoll> HandlaggareRolls { get; set; }
    }
}