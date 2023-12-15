namespace ByggrDb
{
    public partial class DdsDocumentfileSmstest
    {
        public int DocId { get; set; }
        public int VersionId { get; set; }
        public int? ComponentId { get; set; }
        public int? Filesize { get; set; }
        public string? Fileextention { get; set; }
        public byte[]? Documentfile { get; set; }
    }
}