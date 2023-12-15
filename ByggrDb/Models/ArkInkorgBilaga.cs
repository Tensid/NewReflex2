namespace ByggrDb
{
    public partial class ArkInkorgBilaga
    {
        public int InkorgId { get; set; }
        public int InkorgBilagaId { get; set; }
        public int? DoclinkId { get; set; }
        public string? OriginalFilename { get; set; }
        public string? OriginalContentType { get; set; }
        public int? OriginalFilesize { get; set; }
        public string StoredOriginal { get; set; } = null!;
        public string StoredPdf { get; set; } = null!;
        public bool IsMainMail { get; set; }

        public virtual GemDmsdoclink? Doclink { get; set; }
        public virtual ArkInkorg Inkorg { get; set; } = null!;
    }
}