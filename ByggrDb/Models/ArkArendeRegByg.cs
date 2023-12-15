namespace ByggrDb
{
    public partial class ArkArendeRegByg
    {
        public int ArendeObjektId { get; set; }
        public int ObjektId { get; set; }
        public int? PrelRegByggnadObjektId { get; set; }

        public virtual ArkArendeObjekt ArendeObjekt { get; set; } = null!;
        public virtual GemObjekt Objekt { get; set; } = null!;
        public virtual GemPrelRegByggnad? PrelRegByggnadObjekt { get; set; }
    }
}