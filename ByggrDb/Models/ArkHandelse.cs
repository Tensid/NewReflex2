namespace ByggrDb
{
    public partial class ArkHandelse
    {
        public ArkHandelse()
        {
            ArkBevakatUtskickPamOmgs = new HashSet<ArkBevakatUtskickPamOmg>();
            ArkBevakatUtskickSvars = new HashSet<ArkBevakatUtskickSvar>();
            ArkHandelseHandlings = new HashSet<ArkHandelseHandling>();
            ArkHandelsePersOrgVersions = new HashSet<ArkHandelsePersOrgVersion>();
            ArkInkorgs = new HashSet<ArkInkorg>();
            ArkNotifierings = new HashSet<ArkNotifiering>();
            GemDmsdoclinks = new HashSet<GemDmsdoclink>();
            InverseRefHandelse = new HashSet<ArkHandelse>();
        }

        public int HandelseId { get; set; }
        public int? ArendeId { get; set; }
        public int InUt { get; set; }
        public int HandelseTypId { get; set; }
        public int? HandelseSlagId { get; set; }
        public int? HandelseUtfallsId { get; set; }
        public string Rubrik { get; set; } = null!;
        public int HandlaggareId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime? SlutDatum { get; set; }
        public string? Anteckning { get; set; }
        public int? ObjektId { get; set; }
        public int RegSignId { get; set; }
        public DateTime RegDatum { get; set; }
        public DateTime UpdDatum { get; set; }
        public int UpdSignId { get; set; }
        public bool ArbetsMtrl { get; set; }
        public bool Sekretess { get; set; }
        public string? SekretessKapitel { get; set; }
        public string? SekretessParagraf { get; set; }
        public int EnhetId { get; set; }
        public string? XmlForhandsGranska { get; set; }
        public int? RefHandelseId { get; set; }
        public bool ArMakulerad { get; set; }
        public int? DebId { get; set; }
        public bool ArKlar { get; set; }
        public string? Fgsid { get; set; }
        public int? ArkiveringStatus { get; set; }
        public int? TidEjDebiterbar { get; set; }
        public int? TidDebiterbar { get; set; }

        public virtual ArkArende? Arende { get; set; }
        public virtual ArkEnhet Enhet { get; set; } = null!;
        public virtual ArkHandelseUtfall? Handelse { get; set; }
        public virtual ArkHandelseSlag? HandelseNavigation { get; set; }
        public virtual ArkHandelseSlag? HandelseSlag { get; set; }
        public virtual ArkHandelseTyp HandelseTyp { get; set; } = null!;
        public virtual ArkHandelseUtfall? HandelseUtfalls { get; set; }
        public virtual ArkHandlaggare Handlaggare { get; set; } = null!;
        public virtual GemObjekt? Objekt { get; set; }
        public virtual ArkHandelse? RefHandelse { get; set; }
        public virtual ArkHandlaggare RegSign { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ArkBevakatUtskickOmg ArkBevakatUtskickOmg { get; set; } = null!;
        public virtual ArkHandelseBeslut ArkHandelseBeslut { get; set; } = null!;
        public virtual ICollection<ArkBevakatUtskickPamOmg> ArkBevakatUtskickPamOmgs { get; set; }
        public virtual ICollection<ArkBevakatUtskickSvar> ArkBevakatUtskickSvars { get; set; }
        public virtual ICollection<ArkHandelseHandling> ArkHandelseHandlings { get; set; }
        public virtual ICollection<ArkHandelsePersOrgVersion> ArkHandelsePersOrgVersions { get; set; }
        public virtual ICollection<ArkInkorg> ArkInkorgs { get; set; }
        public virtual ICollection<ArkNotifiering> ArkNotifierings { get; set; }
        public virtual ICollection<GemDmsdoclink> GemDmsdoclinks { get; set; }
        public virtual ICollection<ArkHandelse> InverseRefHandelse { get; set; }
    }
}