namespace ByggrDb
{
    public partial class ArkTidsVy
    {
        public ArkTidsVy()
        {
            ArkTidsVyArendeTyps = new HashSet<ArkTidsVyArendeTyp>();
        }

        public int TidsVyId { get; set; }
        public string? Beskrivning { get; set; }
        public int RedovisaAntalVeckor { get; set; }

        public virtual ICollection<ArkTidsVyArendeTyp> ArkTidsVyArendeTyps { get; set; }
    }
}