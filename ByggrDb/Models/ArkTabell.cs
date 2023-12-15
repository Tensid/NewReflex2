namespace ByggrDb
{
    public partial class ArkTabell
    {
        public ArkTabell()
        {
            ArkLoggAndras = new HashSet<ArkLoggAndra>();
            ArkLoggLasas = new HashSet<ArkLoggLasa>();
            ArkTabellGrupps = new HashSet<ArkTabellGrupp>();
        }

        public int TabellId { get; set; }
        public string Tabell { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public string? Kommentar { get; set; }
        public int TabellGruppId { get; set; }
        public bool ArLoggaAndringTabell { get; set; }
        public bool ArLoggaLasaTabell { get; set; }
        public string PkKolumn { get; set; } = null!;
        public byte ArLoggaNyTabell { get; set; }
        public bool ArLoggaRaderaTabell { get; set; }

        public virtual ArkTabellGrupp TabellGrupp { get; set; } = null!;
        public virtual ICollection<ArkLoggAndra> ArkLoggAndras { get; set; }
        public virtual ICollection<ArkLoggLasa> ArkLoggLasas { get; set; }
        public virtual ICollection<ArkTabellGrupp> ArkTabellGrupps { get; set; }
    }
}