namespace ByggrDb
{
    public partial class ArkDiarie
    {
        public ArkDiarie()
        {
            ArkArendeGrupps = new HashSet<ArkArendeGrupp>();
            ArkArendeKlasses = new HashSet<ArkArendeKlass>();
            ArkArendes = new HashSet<ArkArende>();
            ArkDiarieArendeGrupps = new HashSet<ArkDiarieArendeGrupp>();
            ArkDnrs = new HashSet<ArkDnr>();
            ArkEnhets = new HashSet<ArkEnhet>();
            ArkFrasGrupps = new HashSet<ArkFrasGrupp>();
            ArkHandelseBeslutNrs = new HashSet<ArkHandelseBeslutNr>();
            ArkNamnds = new HashSet<ArkNamnd>();
        }

        public int DiarieId { get; set; }
        public string? Prefix { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArNamnd { get; set; }

        public virtual ICollection<ArkArendeGrupp> ArkArendeGrupps { get; set; }
        public virtual ICollection<ArkArendeKlass> ArkArendeKlasses { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<ArkDiarieArendeGrupp> ArkDiarieArendeGrupps { get; set; }
        public virtual ICollection<ArkDnr> ArkDnrs { get; set; }
        public virtual ICollection<ArkEnhet> ArkEnhets { get; set; }
        public virtual ICollection<ArkFrasGrupp> ArkFrasGrupps { get; set; }
        public virtual ICollection<ArkHandelseBeslutNr> ArkHandelseBeslutNrs { get; set; }
        public virtual ICollection<ArkNamnd> ArkNamnds { get; set; }
    }
}