namespace ByggrDb
{
    public partial class DdsVersion
    {
        public int DocId { get; set; }
        public int VersionId { get; set; }
        public string? Description { get; set; }
        public string CreatorId { get; set; } = null!;
        public int? Filesize { get; set; }
        public string? Fileextention { get; set; }
        public string? Documentonline { get; set; }
        public string CreationDate { get; set; } = null!;
        public string CreationTime { get; set; } = null!;
        public string? OfflineDate { get; set; }
        public int? BaseVersionId { get; set; }
        public bool IsArchiveFormat { get; set; }
        public bool IsSigned { get; set; }
        public short? StampType { get; set; }
        public string? StampText { get; set; }
        public string? StampConfig { get; set; }
    }
}