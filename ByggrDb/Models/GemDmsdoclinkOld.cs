namespace ByggrDb
{
    public partial class GemDmsdoclinkOld
    {
        public int DoclinkId { get; set; }
        public string DmsdocId { get; set; } = null!;
        public string? Filetype { get; set; }
        public int? Usecount { get; set; }
        public bool? SplitOnSend { get; set; }
    }
}