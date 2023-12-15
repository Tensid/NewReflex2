namespace ByggrDb
{
    public partial class TkcObjectType
    {
        public int ObjectTypeId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; } = null!;
        public string? ClassName { get; set; }
        public decimal? IsDomain { get; set; }
        public decimal? IsDependent { get; set; }
    }
}