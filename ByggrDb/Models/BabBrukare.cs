namespace ByggrDb
{
    public partial class BabBrukare
    {
        public int PersOrgId { get; set; }
        public int ArtikelLokationId { get; set; }
        public bool HuvudBrukare { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime? AvfordDatum { get; set; }

        public virtual BabBostadsAnpassning ArtikelLokation { get; set; } = null!;
        public virtual GemPersOrg PersOrg { get; set; } = null!;
    }
}