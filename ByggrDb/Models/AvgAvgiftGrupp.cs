namespace ByggrDb
{
    public partial class AvgAvgiftGrupp
    {
        public int AvgiftGruppId { get; set; }
        public string AvgiftGruppBen { get; set; } = null!;
        public int GrundAvgiftId { get; set; }
        public bool ArAktiv { get; set; }
        public int SystemId { get; set; }
    }
}