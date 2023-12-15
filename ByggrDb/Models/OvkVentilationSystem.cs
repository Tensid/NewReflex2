namespace ByggrDb
{
    public partial class OvkVentilationSystem
    {
        public int VentilationSystemId { get; set; }
        public int VentilationSystemTypeId { get; set; }
        public int InspectionIntervalId { get; set; }
        public int BuildingId { get; set; }
        public bool? InspectionResultAcceptable { get; set; }
        public string? SystemNumber { get; set; }
        public string? Description { get; set; }
        public string? InternalBuildingName { get; set; }
        public DateTime? InstallationDate { get; set; }
        public bool Active { get; set; }

        public virtual GemObjekt Building { get; set; } = null!;
        public virtual OvkInspectionInterval InspectionInterval { get; set; } = null!;
        public virtual OvkVentilationSystemType VentilationSystemType { get; set; } = null!;
    }
}