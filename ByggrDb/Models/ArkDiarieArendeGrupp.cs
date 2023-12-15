namespace ByggrDb
{
    public partial class ArkDiarieArendeGrupp
    {
        public ArkDiarieArendeGrupp()
        {
            ArkArendeGrupps = new HashSet<ArkArendeGrupp>();
            ArkArendes = new HashSet<ArkArende>();
        }

        public int DiarieId { get; set; }
        public int ArendeGruppId { get; set; }
        public int? AvgiftGruppId { get; set; }
        public bool ArAktiv { get; set; }
        public string? ArendeGruppUniquenessCheck { get; set; }

        public virtual ArkArendeGrupp ArendeGrupp { get; set; } = null!;
        public virtual ArkArendeGrupp? ArendeGruppNavigation { get; set; }
        public virtual ArkDiarie Diarie { get; set; } = null!;
        public virtual ICollection<ArkArendeGrupp> ArkArendeGrupps { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
    }
}