namespace ByggrDb
{
    public partial class ArkArendeKopplBeskr
    {
        public ArkArendeKopplBeskr()
        {
            Arendes = new HashSet<ArkArende>();
        }

        public int ArendeKopplBeskrId { get; set; }
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<ArkArende> Arendes { get; set; }
    }
}