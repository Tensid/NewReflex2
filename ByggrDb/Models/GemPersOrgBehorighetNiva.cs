namespace ByggrDb
{
    public partial class GemPersOrgBehorighetNiva
    {
        public GemPersOrgBehorighetNiva()
        {
            ArkMittByggeKods = new HashSet<ArkMittByggeKod>();
            GemPersOrgBehorighets = new HashSet<GemPersOrgBehorighet>();
        }

        public int PersOrgBehorighetNivaId { get; set; }
        public string BehNiva { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual ICollection<ArkMittByggeKod> ArkMittByggeKods { get; set; }
        public virtual ICollection<GemPersOrgBehorighet> GemPersOrgBehorighets { get; set; }
    }
}