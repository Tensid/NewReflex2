namespace ByggrDb
{
    public partial class TkcPredicate
    {
        public int PredicateId { get; set; }
        public string Name { get; set; } = null!;
        public int MeaningId { get; set; }
        public decimal? PredicateOperator { get; set; }
    }
}