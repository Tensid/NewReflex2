namespace ByggrDb
{
    public partial class OvkVentilationSystemType
    {
        public OvkVentilationSystemType()
        {
            OvkVentilationSystems = new HashSet<OvkVentilationSystem>();
        }

        public int VentilationSystemTypeId { get; set; }
        public string? VentilationSystemType { get; set; }

        public virtual ICollection<OvkVentilationSystem> OvkVentilationSystems { get; set; }
    }
}