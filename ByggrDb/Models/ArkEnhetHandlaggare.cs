namespace ByggrDb
{
    public partial class ArkEnhetHandlaggare
    {
        public ArkEnhetHandlaggare()
        {
            ArkArendeGruppHandlaggares = new HashSet<ArkArendeGruppHandlaggare>();
        }

        public int EnhetId { get; set; }
        public int HandlaggareId { get; set; }
        public DateTime FromDat { get; set; }
        public DateTime? TomDat { get; set; }
        public bool ArHvdEnhet { get; set; }
        public bool ArEndastLasa { get; set; }

        public virtual ArkEnhet Enhet { get; set; } = null!;
        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;
        public virtual ICollection<ArkArendeGruppHandlaggare> ArkArendeGruppHandlaggares { get; set; }
    }
}