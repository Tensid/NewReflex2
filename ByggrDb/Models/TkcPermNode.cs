namespace ByggrDb
{
    public partial class TkcPermNode
    {
        public int PermNodeId { get; set; }
        public decimal PermNodeType { get; set; }
        public string Name { get; set; } = null!;
        public int? PackageId { get; set; }
        public string? Description { get; set; }
    }
}