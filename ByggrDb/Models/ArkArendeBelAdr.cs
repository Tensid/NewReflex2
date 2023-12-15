namespace ByggrDb
{
    public partial class ArkArendeBelAdr
    {
        public ArkArendeBelAdr()
        {
            ArkArendeLghs = new HashSet<ArkArendeLgh>();
        }

        public int ArendeObjektId { get; set; }
        public int ObjektId { get; set; }
        public string Beladress { get; set; } = null!;

        public virtual ArkArendeObjekt ArendeObjekt { get; set; } = null!;
        public virtual GemObjekt Objekt { get; set; } = null!;
        public virtual ICollection<ArkArendeLgh> ArkArendeLghs { get; set; }
    }
}