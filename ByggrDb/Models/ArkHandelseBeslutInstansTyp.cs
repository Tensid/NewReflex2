namespace ByggrDb
{
    public partial class ArkHandelseBeslutInstansTyp
    {
        public ArkHandelseBeslutInstansTyp()
        {
            ArkHandelseBesluts = new HashSet<ArkHandelseBeslut>();
        }

        public int HandelseBeslutInstansTypId { get; set; }
        public string InstansTyp { get; set; } = null!;
        public string InstansPrefix { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArDelegat { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ICollection<ArkHandelseBeslut> ArkHandelseBesluts { get; set; }
    }
}