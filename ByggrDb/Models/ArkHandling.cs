namespace ByggrDb
{
    public partial class ArkHandling
    {
        public ArkHandling()
        {
            ArkHandelseHandlings = new HashSet<ArkHandelseHandling>();
        }

        public int HandlingId { get; set; }
        public int? DoclinkId { get; set; }
        public int HandlingTypId { get; set; }
        public int HandlingStatusId { get; set; }
        public DateTime HandlingDatum { get; set; }
        public string? ExtRef { get; set; }
        public string? Anteckning { get; set; }
        public int? UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }
        public string Uuid { get; set; } = null!;
        public bool ArMakulerad { get; set; }
        public int? ArkiveringStatus { get; set; }
        public DateTime? EjGallandeFranDatum { get; set; }

        public virtual GemDmsdoclink? Doclink { get; set; }
        public virtual ArkHandlingStatus HandlingStatus { get; set; } = null!;
        public virtual ArkHandlingTyp HandlingTyp { get; set; } = null!;
        public virtual ArkHandlaggare? UpdSign { get; set; }
        public virtual ICollection<ArkHandelseHandling> ArkHandelseHandlings { get; set; }
    }
}