namespace ByggrDb
{
    public partial class TkcObjectTypeAttribute
    {
        public int ObjectTypeId { get; set; }
        public int AttributeId { get; set; }
        public string Name { get; set; } = null!;
        public int? MeaningId { get; set; }
        public int? TableId { get; set; }
        public int? ColumnId { get; set; }
    }
}