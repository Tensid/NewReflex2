namespace ByggrDb
{
    public partial class ArkLoggAndraFalt
    {
        public int LoggAndraFaltId { get; set; }
        public int LoggAndraId { get; set; }
        public string FaltNamn { get; set; } = null!;
        public string? Varde { get; set; }
        public int? VardeNkey { get; set; }

        public virtual ArkLoggAndra LoggAndra { get; set; } = null!;
    }
}