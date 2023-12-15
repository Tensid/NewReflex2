namespace ByggrDb
{
    public partial class GemConfigSection
    {
        public GemConfigSection()
        {
            GemConfigMetaData = new HashSet<GemConfigMetaDatum>();
            GemConfigSectionMetaData = new HashSet<GemConfigSectionMetaDatum>();
        }

        public int ConfigSectionId { get; set; }
        public int ConfigProductId { get; set; }
        public string SectionName { get; set; } = null!;

        public virtual GemConfigProduct ConfigProduct { get; set; } = null!;
        public virtual ICollection<GemConfigMetaDatum> GemConfigMetaData { get; set; }
        public virtual ICollection<GemConfigSectionMetaDatum> GemConfigSectionMetaData { get; set; }
    }
}