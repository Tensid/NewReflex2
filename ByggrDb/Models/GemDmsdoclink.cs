namespace ByggrDb
{
    public partial class GemDmsdoclink
    {
        public GemDmsdoclink()
        {
            ArkInkorgBilagas = new HashSet<ArkInkorgBilaga>();
        }

        public int DoclinkId { get; set; }
        public string DmsdocId { get; set; } = null!;
        public string? Filetype { get; set; }
        public int? Usecount { get; set; }
        public bool? SplitOnSend { get; set; }
        public int? HandelseIdSplittbar { get; set; }

        public virtual ArkHandelse? HandelseIdSplittbarNavigation { get; set; }
        public virtual ArkHandling? ArkHandling { get; set; }
        public virtual ICollection<ArkInkorgBilaga> ArkInkorgBilagas { get; set; }
    }
}