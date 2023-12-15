namespace ByggrDb
{
    public partial class ArkArendeLgh
    {
        public int ArendeObjektId { get; set; }
        public int ObjektId { get; set; }
        public int? BelAdrObjektId { get; set; }
        public string LghNr { get; set; } = null!;

        public virtual ArkArendeObjekt ArendeObjekt { get; set; } = null!;
        public virtual ArkArendeBelAdr? ArkArendeBelAdr { get; set; }
        public virtual GemObjekt Objekt { get; set; } = null!;
    }
}