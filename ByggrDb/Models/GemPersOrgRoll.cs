namespace ByggrDb
{
    public partial class GemPersOrgRoll
    {
        public GemPersOrgRoll()
        {
            ArkArendePersOrgVersionRolls = new HashSet<ArkArendePersOrgVersionRoll>();
            ArkHandelsePersOrgVersionRolls = new HashSet<ArkHandelsePersOrgVersionRoll>();
            ArkMittByggeKods = new HashSet<ArkMittByggeKod>();
            GemPersOrgBehorighets = new HashSet<GemPersOrgBehorighet>();
        }

        public int Rollid { get; set; }
        public string Roll { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public DateTime? Slutdatum { get; set; }
        public string? Anteckning { get; set; }
        public int? RutinKodId { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ArkRutinKod? RutinKod { get; set; }
        public virtual ICollection<ArkArendePersOrgVersionRoll> ArkArendePersOrgVersionRolls { get; set; }
        public virtual ICollection<ArkHandelsePersOrgVersionRoll> ArkHandelsePersOrgVersionRolls { get; set; }
        public virtual ICollection<ArkMittByggeKod> ArkMittByggeKods { get; set; }
        public virtual ICollection<GemPersOrgBehorighet> GemPersOrgBehorighets { get; set; }
    }
}