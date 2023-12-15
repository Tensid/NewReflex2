namespace ByggrDb
{
    public partial class ArkHandelseBeslut
    {
        public ArkHandelseBeslut()
        {
            BabAtgards = new HashSet<BabAtgard>();
        }

        public int HandelseId { get; set; }
        public string? BeslutNr { get; set; }
        public int HandelseBeslutInstansTypId { get; set; }
        public int? HandlaggareId { get; set; }
        public bool ArHuvudBeslut { get; set; }
        public DateTime? GiltigTillDatum { get; set; }
        public string? BeslutsText { get; set; }
        public bool? ArMindreAvvikelse { get; set; }

        public virtual ArkHandelse Handelse { get; set; } = null!;
        public virtual ArkHandelseBeslutInstansTyp HandelseBeslutInstansTyp { get; set; } = null!;
        public virtual ArkHandlaggare? Handlaggare { get; set; }
        public virtual ICollection<BabAtgard> BabAtgards { get; set; }
    }
}