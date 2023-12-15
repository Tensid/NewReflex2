namespace ByggrDb
{
    public partial class ArkBevakatUtskickOldModel
    {
        public int UtskickId { get; set; }
        public int ArendeId { get; set; }
        public int Omgang { get; set; }
        public int UtskickTyp { get; set; }
        public int PersOrgVersionId { get; set; }
        public int? PersOrgAttentionId { get; set; }
        public int? Rollid { get; set; }
        public int? Fnr { get; set; }
        public string? Fastighet { get; set; }
        public bool Erfodras { get; set; }
        public bool Erinran { get; set; }
        public int? HandelseIdUtskick { get; set; }
        public DateTime? SenastSvarDatum { get; set; }
        public int? HandelseIdPaminn { get; set; }
        public int? HandelseIdSvar { get; set; }
        public string? Anteckning { get; set; }
        public string? UtskickText { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }
        public int? HandelseIdPaminnNastSenast { get; set; }
    }
}