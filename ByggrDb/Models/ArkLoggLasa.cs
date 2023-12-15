namespace ByggrDb
{
    public partial class ArkLoggLasa
    {
        public int LoggLasaId { get; set; }
        public int? TabellId { get; set; }
        public int TypId { get; set; }
        public DateTime LoggTimestamp { get; set; }
        public int HandlaggareId { get; set; }

        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;
        public virtual ArkTabell? Tabell { get; set; }
    }
}