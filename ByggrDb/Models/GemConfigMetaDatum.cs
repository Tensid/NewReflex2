namespace ByggrDb
{
    public partial class GemConfigMetaDatum
    {
        public GemConfigMetaDatum()
        {
            GemConfigSectionMetaData = new HashSet<GemConfigSectionMetaDatum>();
        }

        public int ConfigMetaDataId { get; set; }
        public int? ConfigSectionId { get; set; }
        public string MetaDataKey { get; set; } = null!;
        public string MetaDataFormat { get; set; } = null!;
        public string? MetaDataDescription { get; set; }

        public virtual GemConfigSection? ConfigSection { get; set; }
        public virtual ICollection<GemConfigSectionMetaDatum> GemConfigSectionMetaData { get; set; }
    }
}