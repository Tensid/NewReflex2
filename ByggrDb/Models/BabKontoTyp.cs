namespace ByggrDb
{
    public partial class BabKontoTyp
    {
        public BabKontoTyp()
        {
            BabArendes = new HashSet<BabArende>();
        }

        public int KontoTypId { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual ICollection<BabArende> BabArendes { get; set; }
    }
}