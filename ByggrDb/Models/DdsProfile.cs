namespace ByggrDb
{
    public partial class DdsProfile
    {
        public int DocId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatorId { get; set; }
        public string? DocTypeId { get; set; }
        public string? StorageTypeId { get; set; }
        public int? RetentionTime { get; set; }
        public string? CreationDate { get; set; }
        public string? CreationTime { get; set; }
        public string? CheckoutUserId { get; set; }
        public string? CheckoutDate { get; set; }
        public string? CheckoutTime { get; set; }
        public string? CheckoutHost { get; set; }
        public string? CheckoutDrive { get; set; }
        public string? CheckoutFilename { get; set; }
        public int? CheckoutVersionId { get; set; }
    }
}