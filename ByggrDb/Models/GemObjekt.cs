namespace ByggrDb
{
    public partial class GemObjekt
    {
        public GemObjekt()
        {
            ArkArendeBelAdrs = new HashSet<ArkArendeBelAdr>();
            ArkArendeLghs = new HashSet<ArkArendeLgh>();
            ArkArendeObjekts = new HashSet<ArkArendeObjekt>();
            ArkArendeRegBygs = new HashSet<ArkArendeRegByg>();
            ArkBevakatUtskicks = new HashSet<ArkBevakatUtskick>();
            ArkHandelses = new HashSet<ArkHandelse>();
            BabLokationBelAdressObjekts = new HashSet<BabLokation>();
            BabLokationFastighetObjekts = new HashSet<BabLokation>();
            BabLokationLghObjekts = new HashSet<BabLokation>();
            GemPrelRegByggnadFastighetObjekts = new HashSet<GemPrelRegByggnad>();
            OvkVentilationSystems = new HashSet<OvkVentilationSystem>();
        }

        public int ObjektId { get; set; }
        public decimal TypId { get; set; }
        public int ObjektTypId { get; set; }
        public string? XmlForhandsGranska { get; set; }
        public string Beskrivning { get; set; } = null!;
        public int? GeomChecksum { get; set; }
        public string? TypUuid { get; set; }
        public string? KomKod { get; set; }

        public virtual GemKommun? KomKodNavigation { get; set; }
        public virtual GemObjektTyp ObjektTyp { get; set; } = null!;
        public virtual GemPrelRegByggnad GemPrelRegByggnadObjekt { get; set; } = null!;
        public virtual ICollection<ArkArendeBelAdr> ArkArendeBelAdrs { get; set; }
        public virtual ICollection<ArkArendeLgh> ArkArendeLghs { get; set; }
        public virtual ICollection<ArkArendeObjekt> ArkArendeObjekts { get; set; }
        public virtual ICollection<ArkArendeRegByg> ArkArendeRegBygs { get; set; }
        public virtual ICollection<ArkBevakatUtskick> ArkBevakatUtskicks { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelses { get; set; }
        public virtual ICollection<BabLokation> BabLokationBelAdressObjekts { get; set; }
        public virtual ICollection<BabLokation> BabLokationFastighetObjekts { get; set; }
        public virtual ICollection<BabLokation> BabLokationLghObjekts { get; set; }
        public virtual ICollection<GemPrelRegByggnad> GemPrelRegByggnadFastighetObjekts { get; set; }
        public virtual ICollection<OvkVentilationSystem> OvkVentilationSystems { get; set; }
    }
}