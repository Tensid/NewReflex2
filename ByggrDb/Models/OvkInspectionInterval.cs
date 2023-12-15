namespace ByggrDb
{
    public partial class OvkInspectionInterval
    {
        public OvkInspectionInterval()
        {
            OvkVentilationSystems = new HashSet<OvkVentilationSystem>();
        }

        public int InspectionIntervalId { get; set; }
        public string? InspectionInterval { get; set; }

        public virtual ICollection<OvkVentilationSystem> OvkVentilationSystems { get; set; }
    }
}