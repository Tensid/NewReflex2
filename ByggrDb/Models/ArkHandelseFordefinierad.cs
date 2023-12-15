namespace ByggrDb
{
    public partial class ArkHandelseFordefinierad
    {
        public int HandelseFordefinieradId { get; set; }
        public string HandelseFordefinierad { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int HandelseTypId { get; set; }
        public int? HandelseSlagId { get; set; }
        public int? HandelseUtfallsId { get; set; }
        public int? HandlingTypId { get; set; }
        public int? HandlingStatusId { get; set; }
        public string? ReportFilename { get; set; }

        public virtual ArkHandelseSlag? HandelseSlag { get; set; }
        public virtual ArkHandelseTyp HandelseTyp { get; set; } = null!;
        public virtual ArkHandelseUtfall? HandelseUtfalls { get; set; }
        public virtual ArkHandlingStatus? HandlingStatus { get; set; }
        public virtual ArkHandlingTyp? HandlingTyp { get; set; }
    }
}