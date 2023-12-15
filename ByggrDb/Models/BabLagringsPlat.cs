namespace ByggrDb
{
    public partial class BabLagringsPlat
    {
        public int ArtikelLokationId { get; set; }
        public int? LagerId { get; set; }

        public virtual BabArtikelLokation ArtikelLokation { get; set; } = null!;
        public virtual BabLager? Lager { get; set; }
    }
}