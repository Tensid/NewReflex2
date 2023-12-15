namespace ByggrDb
{
    public partial class ArkArende
    {
        public ArkArende()
        {
            ArkArendeAtgards = new HashSet<ArkArendeAtgard>();
            ArkArendeHandlaggares = new HashSet<ArkArendeHandlaggare>();
            ArkArendeObjekts = new HashSet<ArkArendeObjekt>();
            ArkArendePersOrgVersions = new HashSet<ArkArendePersOrgVersion>();
            ArkBevakatUtskickOmgs = new HashSet<ArkBevakatUtskickOmg>();
            ArkHandelses = new HashSet<ArkHandelse>();
            ArkNotifierings = new HashSet<ArkNotifiering>();
            ArendeKopplBeskrs = new HashSet<ArkArendeKopplBeskr>();
        }

        public int ArendeId { get; set; }
        public string Dnr { get; set; } = null!;
        public int ArendeGruppId { get; set; }
        public int ArendeTypId { get; set; }
        public int? ArendeSlagId { get; set; }
        public string ArendeMening { get; set; } = null!;
        public string? ExtDnr { get; set; }
        public DateTime AnkomstDatum { get; set; }
        public DateTime? SlutDatum { get; set; }
        public DateTime? FasStartDatum { get; set; }
        public decimal StatusId { get; set; }
        public DateTime? VilandeDatum { get; set; }
        public DateTime? MakDatum { get; set; }
        public DateTime? GallringsDatum { get; set; }
        public decimal? GallringsAr { get; set; }
        public string? Anteckning { get; set; }
        public int? RegSignId { get; set; }
        public DateTime RegDatum { get; set; }
        public DateTime UpdDatum { get; set; }
        public int UpdSignId { get; set; }
        public string KomKod { get; set; } = null!;
        public int NamndId { get; set; }
        public int EnhetId { get; set; }
        public int DiarieId { get; set; }
        public string? XmlForhandsGranska { get; set; }
        public int? ArendeKlassId { get; set; }
        public int? ProcessId { get; set; }
        public int? ProcessFasId { get; set; }
        public DateTime? XmlUpdDatum { get; set; }
        public decimal Kalla { get; set; }
        public string? Uuid { get; set; }
        public bool? InomPlan { get; set; }
        public string? ProjektNr { get; set; }
        public DateTime? AtgardStartDat { get; set; }
        public DateTime? AtgardSlutDat { get; set; }
        public bool? ArSammanhBebygg { get; set; }
        public short Kategori { get; set; }
        public short? ArendeKomplexitetId { get; set; }
        public short? ArendePrioritetId { get; set; }

        public virtual ArkArendeGrupp ArendeGrupp { get; set; } = null!;
        public virtual ArkArendeKlass? ArendeKlass { get; set; }
        public virtual ArkArendeKomplexitet? ArendeKomplexitet { get; set; }
        public virtual ArkArendePrioritet? ArendePrioritet { get; set; }
        public virtual ArkArendeSlag? ArendeSlag { get; set; }
        public virtual ArkArendeTyp ArendeTyp { get; set; } = null!;
        public virtual ArkDiarieArendeGrupp ArkDiarieArendeGrupp { get; set; } = null!;
        public virtual ArkDiarie Diarie { get; set; } = null!;
        public virtual ArkEnhet Enhet { get; set; } = null!;
        public virtual GemKommun KomKodNavigation { get; set; } = null!;
        public virtual ArkNamnd Namnd { get; set; } = null!;
        public virtual ArkHandlaggare? RegSign { get; set; }
        public virtual ArkArendeStatus Status { get; set; } = null!;
        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ArkArendeScbstatistik ArkArendeScbstatistik { get; set; } = null!;
        public virtual BabArende BabArende { get; set; } = null!;
        public virtual ICollection<ArkArendeAtgard> ArkArendeAtgards { get; set; }
        public virtual ICollection<ArkArendeHandlaggare> ArkArendeHandlaggares { get; set; }
        public virtual ICollection<ArkArendeObjekt> ArkArendeObjekts { get; set; }
        public virtual ICollection<ArkArendePersOrgVersion> ArkArendePersOrgVersions { get; set; }
        public virtual ICollection<ArkBevakatUtskickOmg> ArkBevakatUtskickOmgs { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelses { get; set; }
        public virtual ICollection<ArkNotifiering> ArkNotifierings { get; set; }

        public virtual ICollection<ArkArendeKopplBeskr> ArendeKopplBeskrs { get; set; }
    }
}