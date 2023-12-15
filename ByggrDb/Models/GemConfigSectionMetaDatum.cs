namespace ByggrDb
{
    public partial class GemConfigSectionMetaDatum
    {
        public GemConfigSectionMetaDatum()
        {
            GemConfigValues = new HashSet<GemConfigValue>();
        }

        public int ConfigSectionMetaDataId { get; set; }
        public int ConfigMetaDataId { get; set; }
        public int ConfigSectionId { get; set; }
        public string? ConfigDefaultValue { get; set; }
        public bool AutoPersist { get; set; }
        public string? Version { get; set; }

        public virtual GemConfigMetaDatum ConfigMetaData { get; set; } = null!;
        public virtual GemConfigSection ConfigSection { get; set; } = null!;
        public virtual ICollection<GemConfigValue> GemConfigValues { get; set; }
    }
}