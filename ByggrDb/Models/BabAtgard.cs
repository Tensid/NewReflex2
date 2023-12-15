namespace ByggrDb
{
    public partial class BabAtgard
    {
        public int ArendeId { get; set; }
        public int AtgardId { get; set; }
        public int Antal { get; set; }
        public string? Placering { get; set; }
        public int? BeslutId { get; set; }
        public decimal? BegartBelopp { get; set; }
        public decimal? BeslutatBelopp { get; set; }
        public DateTime? UtbetaltDatum { get; set; }
        public decimal? UtbetaltBelopp { get; set; }
        public int? ArtikelLokationId { get; set; }

        public virtual ArkArendeAtgard A { get; set; } = null!;
        public virtual BabBostadsAnpassning? ArtikelLokation { get; set; }
        public virtual ArkHandelseBeslut? Beslut { get; set; }
    }
}