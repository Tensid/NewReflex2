namespace ByggrDb
{
    public partial class ArkRutinKod
    {
        public ArkRutinKod()
        {
            ArkHandelseSlags = new HashSet<ArkHandelseSlag>();
            ArkHandelseTyps = new HashSet<ArkHandelseTyp>();
            GemPersOrgRolls = new HashSet<GemPersOrgRoll>();
        }

        public int RutinKodId { get; set; }
        public int RutinId { get; set; }
        public string RutinKod { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual ArkRutin Rutin { get; set; } = null!;
        public virtual ICollection<ArkHandelseSlag> ArkHandelseSlags { get; set; }
        public virtual ICollection<ArkHandelseTyp> ArkHandelseTyps { get; set; }
        public virtual ICollection<GemPersOrgRoll> GemPersOrgRolls { get; set; }
    }
}