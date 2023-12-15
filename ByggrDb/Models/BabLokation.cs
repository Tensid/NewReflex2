namespace ByggrDb
{
    public partial class BabLokation
    {
        public BabLokation()
        {
            BabArtikelLokations = new HashSet<BabArtikelLokation>();
            BabLagers = new HashSet<BabLager>();
        }

        public int LokationId { get; set; }
        public int? FastighetObjektId { get; set; }
        public int? BelAdressObjektId { get; set; }
        public int? LghObjektId { get; set; }

        public virtual GemObjekt? BelAdressObjekt { get; set; }
        public virtual GemObjekt? FastighetObjekt { get; set; }
        public virtual GemObjekt? LghObjekt { get; set; }
        public virtual ICollection<BabArtikelLokation> BabArtikelLokations { get; set; }
        public virtual ICollection<BabLager> BabLagers { get; set; }
    }
}