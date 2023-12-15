namespace ByggrDb
{
    public partial class BabArende
    {
        public int ArendeId { get; set; }
        public int? HusTypId { get; set; }
        public int? UpplatelseFormId { get; set; }
        public string? UtbetTillKonto { get; set; }
        public int? UtbetTillKontoTypId { get; set; }

        public virtual ArkArende Arende { get; set; } = null!;
        public virtual BabHusTyp? HusTyp { get; set; }
        public virtual BabUpplatelseForm? UpplatelseForm { get; set; }
        public virtual BabKontoTyp? UtbetTillKontoTyp { get; set; }
    }
}