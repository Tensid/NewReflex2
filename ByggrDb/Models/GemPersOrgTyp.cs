namespace ByggrDb
{
    public partial class GemPersOrgTyp
    {
        public GemPersOrgTyp()
        {
            GemPersOrgs = new HashSet<GemPersOrg>();
        }

        public int PersOrgTypId { get; set; }
        public string? PersOrgTyp { get; set; }
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<GemPersOrg> GemPersOrgs { get; set; }
    }
}