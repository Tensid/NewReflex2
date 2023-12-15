namespace ByggrDb
{
    public partial class ArkUnderrattelse
    {
        public int UnderrattelseId { get; set; }
        public int ArendeId { get; set; }
        public short Underrattelseomgang { get; set; }
        public short UtskickTyp { get; set; }
        public int PersOrgVersionId { get; set; }
        public int? PersOrgAttentionId { get; set; }
        public int? Rollid { get; set; }
        public decimal? Fnr { get; set; }
        public string? Fastighet { get; set; }
        public bool Erfodras { get; set; }
        public bool? Erinran { get; set; }
        public int HandelseIdUtskick { get; set; }
        public DateTime? SenastSvarDatum { get; set; }
        public int? HandelseIdPaminn { get; set; }
        public int? HandelseIdSvar { get; set; }
        public string? Anteckning { get; set; }
        public string? Underrattelsetext { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }
        public int? HandelseIdPaminnNastSenast { get; set; }
    }
}