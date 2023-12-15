namespace ByggrDb
{
    public partial class ArkLoggAndra
    {
        public ArkLoggAndra()
        {
            ArkLoggAndraFalts = new HashSet<ArkLoggAndraFalt>();
        }

        public int LoggAndraId { get; set; }
        public int? TabellId { get; set; }
        public int TypId { get; set; }
        public DateTime LoggTimestamp { get; set; }
        public int HandlaggareId { get; set; }
        public int LoggTypId { get; set; }

        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;
        public virtual ArkLoggTyp LoggTyp { get; set; } = null!;
        public virtual ArkTabell? Tabell { get; set; }
        public virtual ICollection<ArkLoggAndraFalt> ArkLoggAndraFalts { get; set; }
    }
}