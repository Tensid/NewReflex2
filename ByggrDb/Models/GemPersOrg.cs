namespace ByggrDb
{
    public partial class GemPersOrg
    {
        public GemPersOrg()
        {
            BabBrukares = new HashSet<BabBrukare>();
            GemPersOrgAttentions = new HashSet<GemPersOrgAttention>();
            GemPersOrgBehorighets = new HashSet<GemPersOrgBehorighet>();
            GemPersOrgKommunikations = new HashSet<GemPersOrgKommunikation>();
            GemPersOrgVersions = new HashSet<GemPersOrgVersion>();
            InverseRefPersOrg = new HashSet<GemPersOrg>();
        }

        public int PersOrgId { get; set; }
        public int? RefPersOrgId { get; set; }
        public int PersOrgTypId { get; set; }
        public string? PersOrgNr { get; set; }
        public bool ArForetag { get; set; }
        public bool ArInternKund { get; set; }
        public string? BestallarIdent { get; set; }
        public bool ArRemissInstans { get; set; }
        public string? FsKundnr { get; set; }
        public int? Pid { get; set; }
        public string? Anteckning { get; set; }
        public DateTime UpdDat { get; set; }
        public int UpdSignId { get; set; }
        public string? XmlForhandsGranska { get; set; }
        public string? FakturaIdent { get; set; }
        public bool ArAktiv { get; set; }
        public string? Motpart { get; set; }

        public virtual GemPersOrgTyp PersOrgTyp { get; set; } = null!;
        public virtual GemPersOrg? RefPersOrg { get; set; }
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual GemPersOrgAdress GemPersOrgAdress { get; set; } = null!;
        public virtual ICollection<BabBrukare> BabBrukares { get; set; }
        public virtual ICollection<GemPersOrgAttention> GemPersOrgAttentions { get; set; }
        public virtual ICollection<GemPersOrgBehorighet> GemPersOrgBehorighets { get; set; }
        public virtual ICollection<GemPersOrgKommunikation> GemPersOrgKommunikations { get; set; }
        public virtual ICollection<GemPersOrgVersion> GemPersOrgVersions { get; set; }
        public virtual ICollection<GemPersOrg> InverseRefPersOrg { get; set; }
    }
}