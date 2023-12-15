namespace ByggrDb
{
    public partial class DebFakturaRad
    {
        public int FakturaId { get; set; }
        public int DebId { get; set; }
        public int AvgLopNr { get; set; }
        public decimal BeloppNetto { get; set; }
        public decimal Moms { get; set; }
    }
}