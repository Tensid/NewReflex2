namespace ByggrDb
{
    public partial class TkcPackage
    {
        public int PackageId { get; set; }
        public string Name { get; set; } = null!;
        public string? SrvObjectFactoryClassName { get; set; }
        public string? ClntObjectFactoryClassName { get; set; }
        public string? ProviderObjectFactoryType { get; set; }
    }
}