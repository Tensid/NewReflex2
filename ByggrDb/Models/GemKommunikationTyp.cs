namespace ByggrDb
{
    public partial class GemKommunikationTyp
    {
        public GemKommunikationTyp()
        {
            ArkMittByggeKods = new HashSet<ArkMittByggeKod>();
            GemPersOrgKommunikations = new HashSet<GemPersOrgKommunikation>();
        }

        public int KomTypId { get; set; }
        public string? KomTyp { get; set; }
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual ICollection<ArkMittByggeKod> ArkMittByggeKods { get; set; }
        public virtual ICollection<GemPersOrgKommunikation> GemPersOrgKommunikations { get; set; }
    }
}