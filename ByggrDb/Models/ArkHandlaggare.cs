namespace ByggrDb
{
    public partial class ArkHandlaggare
    {
        public ArkHandlaggare()
        {
            ArkArendeGruppHandlaggares = new HashSet<ArkArendeGruppHandlaggare>();
            ArkArendeHandlaggares = new HashSet<ArkArendeHandlaggare>();
            ArkArendeRegSigns = new HashSet<ArkArende>();
            ArkArendeUpdSigns = new HashSet<ArkArende>();
            ArkBevakatUtskickOmgs = new HashSet<ArkBevakatUtskickOmg>();
            ArkBevakatUtskickPamOmgs = new HashSet<ArkBevakatUtskickPamOmg>();
            ArkBevakatUtskickPams = new HashSet<ArkBevakatUtskickPam>();
            ArkBevakatUtskickSvars = new HashSet<ArkBevakatUtskickSvar>();
            ArkBevakatUtskicks = new HashSet<ArkBevakatUtskick>();
            ArkEnhetHandlaggares = new HashSet<ArkEnhetHandlaggare>();
            ArkGenerellHandlings = new HashSet<ArkGenerellHandling>();
            ArkHandelseBesluts = new HashSet<ArkHandelseBeslut>();
            ArkHandelseHandlaggares = new HashSet<ArkHandelse>();
            ArkHandelseRegSigns = new HashSet<ArkHandelse>();
            ArkHandelseUpdSigns = new HashSet<ArkHandelse>();
            ArkHandlings = new HashSet<ArkHandling>();
            ArkLoggAndras = new HashSet<ArkLoggAndra>();
            ArkLoggLasas = new HashSet<ArkLoggLasa>();
            ArkNotifieringHandlaggares = new HashSet<ArkNotifiering>();
            ArkNotifieringKvitteradAvHandlaggares = new HashSet<ArkNotifiering>();
            ArkNotifieringRegSigns = new HashSet<ArkNotifiering>();
            GemPersOrgAdresses = new HashSet<GemPersOrgAdress>();
            GemPersOrgAttentions = new HashSet<GemPersOrgAttention>();
            GemPersOrgVersions = new HashSet<GemPersOrgVersion>();
            GemPersOrgs = new HashSet<GemPersOrg>();
        }

        public int HandlaggareId { get; set; }
        public string HandlSign { get; set; } = null!;
        public string ForNamn { get; set; } = null!;
        public string EfterNamn { get; set; } = null!;
        public string? Titel { get; set; }
        public string? Telefon { get; set; }
        public string? Mobil { get; set; }
        public string? Epost { get; set; }
        public string? FsFaktRef { get; set; }
        public string? UserName { get; set; }
        public bool ArAktiv { get; set; }
        public bool ArDelegat { get; set; }
        public string? ByggRepostVisningsnamn { get; set; }

        public virtual ICollection<ArkArendeGruppHandlaggare> ArkArendeGruppHandlaggares { get; set; }
        public virtual ICollection<ArkArendeHandlaggare> ArkArendeHandlaggares { get; set; }
        public virtual ICollection<ArkArende> ArkArendeRegSigns { get; set; }
        public virtual ICollection<ArkArende> ArkArendeUpdSigns { get; set; }
        public virtual ICollection<ArkBevakatUtskickOmg> ArkBevakatUtskickOmgs { get; set; }
        public virtual ICollection<ArkBevakatUtskickPamOmg> ArkBevakatUtskickPamOmgs { get; set; }
        public virtual ICollection<ArkBevakatUtskickPam> ArkBevakatUtskickPams { get; set; }
        public virtual ICollection<ArkBevakatUtskickSvar> ArkBevakatUtskickSvars { get; set; }
        public virtual ICollection<ArkBevakatUtskick> ArkBevakatUtskicks { get; set; }
        public virtual ICollection<ArkEnhetHandlaggare> ArkEnhetHandlaggares { get; set; }
        public virtual ICollection<ArkGenerellHandling> ArkGenerellHandlings { get; set; }
        public virtual ICollection<ArkHandelseBeslut> ArkHandelseBesluts { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseHandlaggares { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseRegSigns { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseUpdSigns { get; set; }
        public virtual ICollection<ArkHandling> ArkHandlings { get; set; }
        public virtual ICollection<ArkLoggAndra> ArkLoggAndras { get; set; }
        public virtual ICollection<ArkLoggLasa> ArkLoggLasas { get; set; }
        public virtual ICollection<ArkNotifiering> ArkNotifieringHandlaggares { get; set; }
        public virtual ICollection<ArkNotifiering> ArkNotifieringKvitteradAvHandlaggares { get; set; }
        public virtual ICollection<ArkNotifiering> ArkNotifieringRegSigns { get; set; }
        public virtual ICollection<GemPersOrgAdress> GemPersOrgAdresses { get; set; }
        public virtual ICollection<GemPersOrgAttention> GemPersOrgAttentions { get; set; }
        public virtual ICollection<GemPersOrgVersion> GemPersOrgVersions { get; set; }
        public virtual ICollection<GemPersOrg> GemPersOrgs { get; set; }
    }
}