namespace ByggrDb
{
    public partial class ArkArendeMening
    {
        public int ArendeMeningId { get; set; }
        public string ArendeMening { get; set; } = null!;
        public int ArendeTypId { get; set; }

        public virtual ArkArendeTyp ArendeTyp { get; set; } = null!;
    }
}