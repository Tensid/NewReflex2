namespace ByggrDb
{
    public partial class ArkTabellGrupp
    {
        public ArkTabellGrupp()
        {
            ArkTabells = new HashSet<ArkTabell>();
        }

        public int TabellGruppId { get; set; }
        public string TabellGrupp { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int HvdTabellId { get; set; }

        public virtual ArkTabell HvdTabell { get; set; } = null!;
        public virtual ICollection<ArkTabell> ArkTabells { get; set; }
    }
}