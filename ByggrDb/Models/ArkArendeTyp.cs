namespace ByggrDb
{
    public partial class ArkArendeTyp
    {
        public ArkArendeTyp()
        {
            ArkArendeMenings = new HashSet<ArkArendeMening>();
            ArkArendeSlags = new HashSet<ArkArendeSlag>();
            ArkArendeTypMilstolpes = new HashSet<ArkArendeTypMilstolpe>();
            ArkArendes = new HashSet<ArkArende>();
            ArkTidsVyArendeTyps = new HashSet<ArkTidsVyArendeTyp>();
        }

        public int ArendeTypId { get; set; }
        public string ArendeTyp { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int ArendeGruppId { get; set; }
        public int? AvgiftGruppId { get; set; }
        public bool ArAktiv { get; set; }
        public short Kategori { get; set; }

        public virtual ArkArendeGrupp ArendeGrupp { get; set; } = null!;
        public virtual ICollection<ArkArendeMening> ArkArendeMenings { get; set; }
        public virtual ICollection<ArkArendeSlag> ArkArendeSlags { get; set; }
        public virtual ICollection<ArkArendeTypMilstolpe> ArkArendeTypMilstolpes { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<ArkTidsVyArendeTyp> ArkTidsVyArendeTyps { get; set; }
    }
}