namespace ByggrDb
{
    public partial class ArkArendeMilstolparV1
    {
        public int ArendeId { get; set; }
        public int ArendeTypId { get; set; }
        public int MilstolpeId { get; set; }
        public int MilstolpeNr { get; set; }
        public DateTime? MilstolpeDatum { get; set; }
        public int? Tidsmatningfranmilstolpeid { get; set; }
        public int? TidsgransVarning { get; set; }
        public int? Tidsgrans { get; set; }
    }
}