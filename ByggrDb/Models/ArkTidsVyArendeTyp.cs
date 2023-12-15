namespace ByggrDb
{
    public partial class ArkTidsVyArendeTyp
    {
        public int TidsVyId { get; set; }
        public int ArendeTypId { get; set; }
        public int MilstolpeId { get; set; }

        public virtual ArkArendeTyp ArendeTyp { get; set; } = null!;
        public virtual ArkArendeTypMilstolpe ArkArendeTypMilstolpe { get; set; } = null!;
        public virtual ArkTidsVy TidsVy { get; set; } = null!;
    }
}