namespace ByggrDb
{
    public partial class TkcMeaning
    {
        public int MeaningId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; } = null!;
    }
}