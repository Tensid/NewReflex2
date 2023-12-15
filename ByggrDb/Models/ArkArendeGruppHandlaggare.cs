namespace ByggrDb
{
    public partial class ArkArendeGruppHandlaggare
    {
        public int EnhetId { get; set; }
        public int HandlaggareId { get; set; }
        public int ArendeGruppId { get; set; }
        public bool ArEndastLasa { get; set; }

        public virtual ArkArendeGrupp ArendeGrupp { get; set; } = null!;
        public virtual ArkEnhetHandlaggare ArkEnhetHandlaggare { get; set; } = null!;
        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;
    }
}