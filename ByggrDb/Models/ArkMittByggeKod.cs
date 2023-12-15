namespace ByggrDb
{
    public partial class ArkMittByggeKod
    {
        public ArkMittByggeKod()
        {
            ArkMittByggeKodSlagMappningArkMittByggeKodNavigations = new HashSet<ArkMittByggeKodSlagMappning>();
            ArkMittByggeKodSlagMappningArkMittByggeKods = new HashSet<ArkMittByggeKodSlagMappning>();
        }

        public decimal KodTyp { get; set; }
        public string MittByggeKod { get; set; } = null!;
        public string? Beskrivning { get; set; }
        public int? HandlingTypId { get; set; }
        public int? ArendeKlassId { get; set; }
        public int? Rollid { get; set; }
        public int? PersOrgBehorighetNivaId { get; set; }
        public int? KomTypId { get; set; }

        public virtual ArkArendeKlass? ArendeKlass { get; set; }
        public virtual ArkHandlingTyp? HandlingTyp { get; set; }
        public virtual GemKommunikationTyp? KomTyp { get; set; }
        public virtual GemPersOrgBehorighetNiva? PersOrgBehorighetNiva { get; set; }
        public virtual GemPersOrgRoll? Roll { get; set; }
        public virtual ICollection<ArkMittByggeKodSlagMappning> ArkMittByggeKodSlagMappningArkMittByggeKodNavigations { get; set; }
        public virtual ICollection<ArkMittByggeKodSlagMappning> ArkMittByggeKodSlagMappningArkMittByggeKods { get; set; }
    }
}