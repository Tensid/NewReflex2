namespace ByggrDb
{
    public partial class ArkNamnd
    {
        public ArkNamnd()
        {
            ArkArendes = new HashSet<ArkArende>();
            Enhets = new HashSet<ArkEnhet>();
            KomKods = new HashSet<GemKommun>();
        }

        public int NamndId { get; set; }
        public string Namnd { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int? DiarieId { get; set; }

        public virtual ArkDiarie? Diarie { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }

        public virtual ICollection<ArkEnhet> Enhets { get; set; }
        public virtual ICollection<GemKommun> KomKods { get; set; }
    }
}