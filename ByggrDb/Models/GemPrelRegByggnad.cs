namespace ByggrDb
{
    public partial class GemPrelRegByggnad
    {
        public GemPrelRegByggnad()
        {
            ArkArendeRegBygs = new HashSet<ArkArendeRegByg>();
        }

        public int ObjektId { get; set; }
        public int FastighetObjektId { get; set; }
        public string PrelAndamal { get; set; } = null!;
        public string? PrelDetaljeratAndamal { get; set; }

        public virtual GemObjekt FastighetObjekt { get; set; } = null!;
        public virtual GemObjekt Objekt { get; set; } = null!;
        public virtual ICollection<ArkArendeRegByg> ArkArendeRegBygs { get; set; }
    }
}