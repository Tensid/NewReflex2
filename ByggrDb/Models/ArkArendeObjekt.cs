namespace ByggrDb
{
    public partial class ArkArendeObjekt
    {
        public ArkArendeObjekt()
        {
            ArkArendeBelAdrs = new HashSet<ArkArendeBelAdr>();
            ArkArendeLghs = new HashSet<ArkArendeLgh>();
            ArkArendeRegBygs = new HashSet<ArkArendeRegByg>();
        }

        public int ArendeObjektId { get; set; }
        public int? ArendeId { get; set; }
        public int? ObjektId { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArHvdObjekt { get; set; }
        public short? SpecFastOmr { get; set; }
        public int? GeomChecksum { get; set; }

        public virtual ArkArende? Arende { get; set; }
        public virtual GemObjekt? Objekt { get; set; }
        public virtual ICollection<ArkArendeBelAdr> ArkArendeBelAdrs { get; set; }
        public virtual ICollection<ArkArendeLgh> ArkArendeLghs { get; set; }
        public virtual ICollection<ArkArendeRegByg> ArkArendeRegBygs { get; set; }
    }
}