namespace ByggrDb
{
    public partial class ArkInkorg
    {
        public ArkInkorg()
        {
            ArkInkorgBilagas = new HashSet<ArkInkorgBilaga>();
            ArkNotifierings = new HashSet<ArkNotifiering>();
        }

        public int InkorgId { get; set; }
        public decimal MeddelandeKallaTyp { get; set; }
        public string Fran { get; set; } = null!;
        public string Till { get; set; } = null!;
        public string? Kopia { get; set; }
        public string Amne { get; set; } = null!;
        public string? Meddelande { get; set; }
        public DateTime MeddelandeDatum { get; set; }
        public int? RegHandelseId { get; set; }
        public DateTime? UpdDatum { get; set; }
        public string? XmlForhandsGranska { get; set; }

        public virtual ArkHandelse? RegHandelse { get; set; }
        public virtual ICollection<ArkInkorgBilaga> ArkInkorgBilagas { get; set; }
        public virtual ICollection<ArkNotifiering> ArkNotifierings { get; set; }
    }
}