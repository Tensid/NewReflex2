namespace ByggrDb
{
    public partial class GemConfigValue
    {
        public int ConfigValueId { get; set; }
        public int? ConfigUserId { get; set; }
        public int ConfigSectionMetaDataId { get; set; }
        public string? ConfigValue { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }

        public virtual GemConfigSectionMetaDatum ConfigSectionMetaData { get; set; } = null!;
        public virtual GemConfigUser? ConfigUser { get; set; }
    }
}