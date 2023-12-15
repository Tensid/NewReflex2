namespace ByggrDb
{
    public partial class ArkArendeGrupp
    {
        public ArkArendeGrupp()
        {
            ArkArendeGruppHandlaggares = new HashSet<ArkArendeGruppHandlaggare>();
            ArkArendeTyps = new HashSet<ArkArendeTyp>();
            ArkArendes = new HashSet<ArkArende>();
            ArkDiarieArendeGruppArendeGruppNavigations = new HashSet<ArkDiarieArendeGrupp>();
            ArkDiarieArendeGruppArendeGrupps = new HashSet<ArkDiarieArendeGrupp>();
            ArkHandelseTyps = new HashSet<ArkHandelseTyp>();
        }

        public int ArendeGruppId { get; set; }
        public string ArendeGrupp { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int? DiarieId { get; set; }
        public int? AvgiftGruppId { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ArkDiarieArendeGrupp? ArkDiarieArendeGrupp { get; set; }
        public virtual ArkDiarie? Diarie { get; set; }
        public virtual ICollection<ArkArendeGruppHandlaggare> ArkArendeGruppHandlaggares { get; set; }
        public virtual ICollection<ArkArendeTyp> ArkArendeTyps { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<ArkDiarieArendeGrupp> ArkDiarieArendeGruppArendeGruppNavigations { get; set; }
        public virtual ICollection<ArkDiarieArendeGrupp> ArkDiarieArendeGruppArendeGrupps { get; set; }
        public virtual ICollection<ArkHandelseTyp> ArkHandelseTyps { get; set; }
    }
}