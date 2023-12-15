namespace ByggrDb
{
    public partial class ArkHandelseHandling
    {
        public int HandelseId { get; set; }
        public int HandlingId { get; set; }
        public byte? SendMode { get; set; }

        public virtual ArkHandelse Handelse { get; set; } = null!;
        public virtual ArkHandling Handling { get; set; } = null!;
    }
}