namespace ByggrDb
{
    public partial class ArkArendeTypMilstolpe
    {
        public ArkArendeTypMilstolpe()
        {
            ArkTidsVyArendeTyps = new HashSet<ArkTidsVyArendeTyp>();
            InverseArkArendeTypMilstolpeNavigation = new HashSet<ArkArendeTypMilstolpe>();
        }

        public int ArendeTypId { get; set; }
        public int MilstolpeId { get; set; }
        public int MilstolpeNr { get; set; }
        public int? TidsMatningFranMilstolpeId { get; set; }
        public int? TidsgransVarning { get; set; }
        public int? Tidsgrans { get; set; }

        public virtual ArkArendeTyp ArendeTyp { get; set; } = null!;
        public virtual ArkArendeTypMilstolpe? ArkArendeTypMilstolpeNavigation { get; set; }
        public virtual ArkMilstolpe Milstolpe { get; set; } = null!;
        public virtual ICollection<ArkTidsVyArendeTyp> ArkTidsVyArendeTyps { get; set; }
        public virtual ICollection<ArkArendeTypMilstolpe> InverseArkArendeTypMilstolpeNavigation { get; set; }
    }
}