namespace ByggrDb
{
    public partial class ArkLoggTyp
    {
        public ArkLoggTyp()
        {
            ArkLoggAndras = new HashSet<ArkLoggAndra>();
        }

        public int LoggTypId { get; set; }
        public string? LoggTyp { get; set; }
        public string? Beskrivning { get; set; }

        public virtual ICollection<ArkLoggAndra> ArkLoggAndras { get; set; }
    }
}