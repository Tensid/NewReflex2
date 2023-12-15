namespace ByggrDb
{
    public partial class GemObjektTyp
    {
        public GemObjektTyp()
        {
            GemObjekts = new HashSet<GemObjekt>();
        }

        public int ObjektTypId { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }
        public short? ObjektKlass { get; set; }

        public virtual ICollection<GemObjekt> GemObjekts { get; set; }
    }
}