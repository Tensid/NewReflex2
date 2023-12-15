using Microsoft.EntityFrameworkCore;

namespace ByggrDb
{
    public partial class Byggr : DbContext
    {
        public Byggr()
        {
        }

        public Byggr(DbContextOptions<Byggr> options)
            : base(options)
        {
        }

        public virtual DbSet<ArendebasV1> ArendebasV1s { get; set; } = null!;
        public virtual DbSet<ArkArende> ArkArendes { get; set; } = null!;
        public virtual DbSet<ArkArendeAtgard> ArkArendeAtgards { get; set; } = null!;
        public virtual DbSet<ArkArendeBelAdr> ArkArendeBelAdrs { get; set; } = null!;
        public virtual DbSet<ArkArendeBeslutV1> ArkArendeBeslutV1s { get; set; } = null!;
        public virtual DbSet<ArkArendeGrupp> ArkArendeGrupps { get; set; } = null!;
        public virtual DbSet<ArkArendeGruppHandlaggare> ArkArendeGruppHandlaggares { get; set; } = null!;
        public virtual DbSet<ArkArendeHandlaggare> ArkArendeHandlaggares { get; set; } = null!;
        public virtual DbSet<ArkArendeHandlaggareHvdHlV1> ArkArendeHandlaggareHvdHlV1s { get; set; } = null!;
        public virtual DbSet<ArkArendeHvdBeslutV1> ArkArendeHvdBeslutV1s { get; set; } = null!;
        public virtual DbSet<ArkArendeKlass> ArkArendeKlasses { get; set; } = null!;
        public virtual DbSet<ArkArendeKomplexitet> ArkArendeKomplexitets { get; set; } = null!;
        public virtual DbSet<ArkArendeKopplBeskr> ArkArendeKopplBeskrs { get; set; } = null!;
        public virtual DbSet<ArkArendeLgh> ArkArendeLghs { get; set; } = null!;
        public virtual DbSet<ArkArendeMening> ArkArendeMenings { get; set; } = null!;
        public virtual DbSet<ArkArendeMilstolparCrV1> ArkArendeMilstolparCrV1s { get; set; } = null!;
        public virtual DbSet<ArkArendeMilstolparV1> ArkArendeMilstolparV1s { get; set; } = null!;
        public virtual DbSet<ArkArendeObjekt> ArkArendeObjekts { get; set; } = null!;
        public virtual DbSet<ArkArendeObjektHvdObjektV1> ArkArendeObjektHvdObjektV1s { get; set; } = null!;
        public virtual DbSet<ArkArendePersOrgVersion> ArkArendePersOrgVersions { get; set; } = null!;
        public virtual DbSet<ArkArendePersOrgVersionRoll> ArkArendePersOrgVersionRolls { get; set; } = null!;
        public virtual DbSet<ArkArendePrioritet> ArkArendePrioritets { get; set; } = null!;
        public virtual DbSet<ArkArendeRegByg> ArkArendeRegBygs { get; set; } = null!;
        public virtual DbSet<ArkArendeRemiss> ArkArendeRemisses { get; set; } = null!;
        public virtual DbSet<ArkArendeScbstatistik> ArkArendeScbstatistiks { get; set; } = null!;
        public virtual DbSet<ArkArendeSlag> ArkArendeSlags { get; set; } = null!;
        public virtual DbSet<ArkArendeSlagIdNullTill0V1> ArkArendeSlagIdNullTill0V1s { get; set; } = null!;
        public virtual DbSet<ArkArendeStatus> ArkArendeStatuses { get; set; } = null!;
        public virtual DbSet<ArkArendeTyp> ArkArendeTyps { get; set; } = null!;
        public virtual DbSet<ArkArendeTypMilstolpe> ArkArendeTypMilstolpes { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskick> ArkBevakatUtskicks { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskickOldMod> ArkBevakatUtskickOldMods { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskickOldModel> ArkBevakatUtskickOldModels { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskickOmg> ArkBevakatUtskickOmgs { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskickPam> ArkBevakatUtskickPams { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskickPamOmg> ArkBevakatUtskickPamOmgs { get; set; } = null!;
        public virtual DbSet<ArkBevakatUtskickSvar> ArkBevakatUtskickSvars { get; set; } = null!;
        public virtual DbSet<ArkBevakning> ArkBevaknings { get; set; } = null!;
        public virtual DbSet<ArkBevakningsTyp> ArkBevakningsTyps { get; set; } = null!;
        public virtual DbSet<ArkDiarie> ArkDiaries { get; set; } = null!;
        public virtual DbSet<ArkDiarieArendeGrupp> ArkDiarieArendeGrupps { get; set; } = null!;
        public virtual DbSet<ArkDnr> ArkDnrs { get; set; } = null!;
        public virtual DbSet<ArkEnhet> ArkEnhets { get; set; } = null!;
        public virtual DbSet<ArkEnhetHandlaggare> ArkEnhetHandlaggares { get; set; } = null!;
        public virtual DbSet<ArkFra> ArkFras { get; set; } = null!;
        public virtual DbSet<ArkFrasGrupp> ArkFrasGrupps { get; set; } = null!;
        public virtual DbSet<ArkFrasTyp> ArkFrasTyps { get; set; } = null!;
        public virtual DbSet<ArkGenerellHandling> ArkGenerellHandlings { get; set; } = null!;
        public virtual DbSet<ArkGenerellHandlingGenerellHandlingKategori> ArkGenerellHandlingGenerellHandlingKategoris { get; set; } = null!;
        public virtual DbSet<ArkGenerellHandlingKategori> ArkGenerellHandlingKategoris { get; set; } = null!;
        public virtual DbSet<ArkHandelse> ArkHandelses { get; set; } = null!;
        public virtual DbSet<ArkHandelseBeslut> ArkHandelseBesluts { get; set; } = null!;
        public virtual DbSet<ArkHandelseBeslutInstansTyp> ArkHandelseBeslutInstansTyps { get; set; } = null!;
        public virtual DbSet<ArkHandelseBeslutNr> ArkHandelseBeslutNrs { get; set; } = null!;
        public virtual DbSet<ArkHandelseFordefinierad> ArkHandelseFordefinierads { get; set; } = null!;
        public virtual DbSet<ArkHandelseHandling> ArkHandelseHandlings { get; set; } = null!;
        public virtual DbSet<ArkHandelsePersOrgVersion> ArkHandelsePersOrgVersions { get; set; } = null!;
        public virtual DbSet<ArkHandelsePersOrgVersionRoll> ArkHandelsePersOrgVersionRolls { get; set; } = null!;
        public virtual DbSet<ArkHandelseSlag> ArkHandelseSlags { get; set; } = null!;
        public virtual DbSet<ArkHandelseTyp> ArkHandelseTyps { get; set; } = null!;
        public virtual DbSet<ArkHandelseUtfall> ArkHandelseUtfalls { get; set; } = null!;
        public virtual DbSet<ArkHandlaggare> ArkHandlaggares { get; set; } = null!;
        public virtual DbSet<ArkHandlaggareRoll> ArkHandlaggareRolls { get; set; } = null!;
        public virtual DbSet<ArkHandling> ArkHandlings { get; set; } = null!;
        public virtual DbSet<ArkHandlingArkstatus231Konv> ArkHandlingArkstatus231Konvs { get; set; } = null!;
        public virtual DbSet<ArkHandlingStatus> ArkHandlingStatuses { get; set; } = null!;
        public virtual DbSet<ArkHandlingTyp> ArkHandlingTyps { get; set; } = null!;
        public virtual DbSet<ArkInkorg> ArkInkorgs { get; set; } = null!;
        public virtual DbSet<ArkInkorgBilaga> ArkInkorgBilagas { get; set; } = null!;
        public virtual DbSet<ArkLoggAndra> ArkLoggAndras { get; set; } = null!;
        public virtual DbSet<ArkLoggAndraFalt> ArkLoggAndraFalts { get; set; } = null!;
        public virtual DbSet<ArkLoggAndraFaltVkeyValue> ArkLoggAndraFaltVkeyValues { get; set; } = null!;
        public virtual DbSet<ArkLoggLasa> ArkLoggLasas { get; set; } = null!;
        public virtual DbSet<ArkLoggTyp> ArkLoggTyps { get; set; } = null!;
        public virtual DbSet<ArkMilstolpe> ArkMilstolpes { get; set; } = null!;
        public virtual DbSet<ArkMittByggeKod> ArkMittByggeKods { get; set; } = null!;
        public virtual DbSet<ArkMittByggeKodSlagMappning> ArkMittByggeKodSlagMappnings { get; set; } = null!;
        public virtual DbSet<ArkNamnd> ArkNamnds { get; set; } = null!;
        public virtual DbSet<ArkNotifiering> ArkNotifierings { get; set; } = null!;
        public virtual DbSet<ArkNotifieringKlass> ArkNotifieringKlasses { get; set; } = null!;
        public virtual DbSet<ArkProdukt> ArkProdukts { get; set; } = null!;
        public virtual DbSet<ArkRutin> ArkRutins { get; set; } = null!;
        public virtual DbSet<ArkRutinKod> ArkRutinKods { get; set; } = null!;
        public virtual DbSet<ArkScbstatistik> ArkScbstatistiks { get; set; } = null!;
        public virtual DbSet<ArkScbstatistikLgh> ArkScbstatistikLghs { get; set; } = null!;
        public virtual DbSet<ArkStandardSok> ArkStandardSoks { get; set; } = null!;
        public virtual DbSet<ArkTabell> ArkTabells { get; set; } = null!;
        public virtual DbSet<ArkTabellGrupp> ArkTabellGrupps { get; set; } = null!;
        public virtual DbSet<ArkTidsVy> ArkTidsVies { get; set; } = null!;
        public virtual DbSet<ArkTidsVyArendeTyp> ArkTidsVyArendeTyps { get; set; } = null!;
        public virtual DbSet<ArkUnderrattelse> ArkUnderrattelses { get; set; } = null!;
        public virtual DbSet<ArkVersion> ArkVersions { get; set; } = null!;
        public virtual DbSet<ArkarendeGeofirV1> ArkarendeGeofirV1s { get; set; } = null!;
        public virtual DbSet<AvgAvgiftBelopp> AvgAvgiftBelopps { get; set; } = null!;
        public virtual DbSet<AvgAvgiftGrupp> AvgAvgiftGrupps { get; set; } = null!;
        public virtual DbSet<AvgAvgiftIntervall> AvgAvgiftIntervalls { get; set; } = null!;
        public virtual DbSet<AvgAvgiftTyp> AvgAvgiftTyps { get; set; } = null!;
        public virtual DbSet<AvgBeloppTyp> AvgBeloppTyps { get; set; } = null!;
        public virtual DbSet<AvgBeraknFormel> AvgBeraknFormels { get; set; } = null!;
        public virtual DbSet<AvgDelAvgift> AvgDelAvgifts { get; set; } = null!;
        public virtual DbSet<AvgGrundAvgift> AvgGrundAvgifts { get; set; } = null!;
        public virtual DbSet<AvgGrundBelopp> AvgGrundBelopps { get; set; } = null!;
        public virtual DbSet<AvgIndex> AvgIndices { get; set; } = null!;
        public virtual DbSet<AvgIndexBerakn> AvgIndexBerakns { get; set; } = null!;
        public virtual DbSet<AvgIndexSerie> AvgIndexSeries { get; set; } = null!;
        public virtual DbSet<AvgIntervallBelopp> AvgIntervallBelopps { get; set; } = null!;
        public virtual DbSet<AvgKomKontermall> AvgKomKontermalls { get; set; } = null!;
        public virtual DbSet<AvgKontermall> AvgKontermalls { get; set; } = null!;
        public virtual DbSet<AvgKontoDef> AvgKontoDefs { get; set; } = null!;
        public virtual DbSet<AvgOfintervall> AvgOfintervalls { get; set; } = null!;
        public virtual DbSet<AvgOftabell> AvgOftabells { get; set; } = null!;
        public virtual DbSet<BabArende> BabArendes { get; set; } = null!;
        public virtual DbSet<BabArtikel> BabArtikels { get; set; } = null!;
        public virtual DbSet<BabArtikelLokation> BabArtikelLokations { get; set; } = null!;
        public virtual DbSet<BabAtgard> BabAtgards { get; set; } = null!;
        public virtual DbSet<BabBostadsAnpassning> BabBostadsAnpassnings { get; set; } = null!;
        public virtual DbSet<BabBrukare> BabBrukares { get; set; } = null!;
        public virtual DbSet<BabHusTyp> BabHusTyps { get; set; } = null!;
        public virtual DbSet<BabKontoTyp> BabKontoTyps { get; set; } = null!;
        public virtual DbSet<BabLager> BabLagers { get; set; } = null!;
        public virtual DbSet<BabLagringsPlat> BabLagringsPlats { get; set; } = null!;
        public virtual DbSet<BabLokation> BabLokations { get; set; } = null!;
        public virtual DbSet<BabLokationOld> BabLokationOlds { get; set; } = null!;
        public virtual DbSet<BabMappadArtikel> BabMappadArtikels { get; set; } = null!;
        public virtual DbSet<BabUpplatelseForm> BabUpplatelseForms { get; set; } = null!;
        public virtual DbSet<BabVersion> BabVersions { get; set; } = null!;
        public virtual DbSet<DdsDocumentfile> DdsDocumentfiles { get; set; } = null!;
        public virtual DbSet<DdsDocumentfileSmstest> DdsDocumentfileSmstests { get; set; } = null!;
        public virtual DbSet<DdsProfile> DdsProfiles { get; set; } = null!;
        public virtual DbSet<DdsVersion> DdsVersions { get; set; } = null!;
        public virtual DbSet<DebAvgift> DebAvgifts { get; set; } = null!;
        public virtual DbSet<DebAvgiftSpec> DebAvgiftSpecs { get; set; } = null!;
        public virtual DbSet<DebAvisering> DebAviserings { get; set; } = null!;
        public virtual DbSet<DebDebiterSpec> DebDebiterSpecs { get; set; } = null!;
        public virtual DbSet<DebDebitering> DebDebiterings { get; set; } = null!;
        public virtual DbSet<DebEkonomiSystem> DebEkonomiSystems { get; set; } = null!;
        public virtual DbSet<DebFaktura> DebFakturas { get; set; } = null!;
        public virtual DbSet<DebFakturaRad> DebFakturaRads { get; set; } = null!;
        public virtual DbSet<DebMom> DebMoms { get; set; } = null!;
        public virtual DbSet<DebMomsKod> DebMomsKods { get; set; } = null!;
        public virtual DbSet<DebSystem> DebSystems { get; set; } = null!;
        public virtual DbSet<DebSystemParam> DebSystemParams { get; set; } = null!;
        public virtual DbSet<Dual> Duals { get; set; } = null!;
        public virtual DbSet<FastighetGeofirV1> FastighetGeofirV1s { get; set; } = null!;
        public virtual DbSet<FirGeomSetting> FirGeomSettings { get; set; } = null!;
        public virtual DbSet<GdRbArendeGeofirPunktV1> GdRbArendeGeofirPunktV1s { get; set; } = null!;
        public virtual DbSet<GdRbArendeGeofirYtaV1> GdRbArendeGeofirYtaV1s { get; set; } = null!;
        public virtual DbSet<GdRbFriHandelsGeofirPunktV1> GdRbFriHandelsGeofirPunktV1s { get; set; } = null!;
        public virtual DbSet<GdRbFriHandelsGeofirYtaV1> GdRbFriHandelsGeofirYtaV1s { get; set; } = null!;
        public virtual DbSet<GdRbHandelseGeofirPunktV1> GdRbHandelseGeofirPunktV1s { get; set; } = null!;
        public virtual DbSet<GdRbHandelseGeofirYtaV1> GdRbHandelseGeofirYtaV1s { get; set; } = null!;
        public virtual DbSet<GdRbHuvudbeslutGeofirPunktV1> GdRbHuvudbeslutGeofirPunktV1s { get; set; } = null!;
        public virtual DbSet<GdRbHuvudbeslutGeofirYtaV1> GdRbHuvudbeslutGeofirYtaV1s { get; set; } = null!;
        public virtual DbSet<GdRbHvdhandlaggGeofirPunktV1> GdRbHvdhandlaggGeofirPunktV1s { get; set; } = null!;
        public virtual DbSet<GdRbHvdhandlaggGeofirYtaV1> GdRbHvdhandlaggGeofirYtaV1s { get; set; } = null!;
        public virtual DbSet<GdRbUHvdbeslGeofirPunktV1> GdRbUHvdbeslGeofirPunktV1s { get; set; } = null!;
        public virtual DbSet<GdRbUHvdbeslGeofirYtaV1> GdRbUHvdbeslGeofirYtaV1s { get; set; } = null!;
        public virtual DbSet<GemConfigMetaDatum> GemConfigMetaData { get; set; } = null!;
        public virtual DbSet<GemConfigProduct> GemConfigProducts { get; set; } = null!;
        public virtual DbSet<GemConfigSection> GemConfigSections { get; set; } = null!;
        public virtual DbSet<GemConfigSectionMetaDatum> GemConfigSectionMetaData { get; set; } = null!;
        public virtual DbSet<GemConfigUser> GemConfigUsers { get; set; } = null!;
        public virtual DbSet<GemConfigValue> GemConfigValues { get; set; } = null!;
        public virtual DbSet<GemCounter> GemCounters { get; set; } = null!;
        public virtual DbSet<GemDmsdoclink> GemDmsdoclinks { get; set; } = null!;
        public virtual DbSet<GemDmsdoclinkOld> GemDmsdoclinkOlds { get; set; } = null!;
        public virtual DbSet<GemHiss> GemHisses { get; set; } = null!;
        public virtual DbSet<GemIndividInventarie> GemIndividInventaries { get; set; } = null!;
        public virtual DbSet<GemKommun> GemKommuns { get; set; } = null!;
        public virtual DbSet<GemKommunV1> GemKommunV1s { get; set; } = null!;
        public virtual DbSet<GemKommunikationTyp> GemKommunikationTyps { get; set; } = null!;
        public virtual DbSet<GemObjekt> GemObjekts { get; set; } = null!;
        public virtual DbSet<GemObjektTyp> GemObjektTyps { get; set; } = null!;
        public virtual DbSet<GemPersOrg> GemPersOrgs { get; set; } = null!;
        public virtual DbSet<GemPersOrgAdress> GemPersOrgAdresses { get; set; } = null!;
        public virtual DbSet<GemPersOrgAttention> GemPersOrgAttentions { get; set; } = null!;
        public virtual DbSet<GemPersOrgBehorighet> GemPersOrgBehorighets { get; set; } = null!;
        public virtual DbSet<GemPersOrgBehorighetNiva> GemPersOrgBehorighetNivas { get; set; } = null!;
        public virtual DbSet<GemPersOrgKommunikation> GemPersOrgKommunikations { get; set; } = null!;
        public virtual DbSet<GemPersOrgRoll> GemPersOrgRolls { get; set; } = null!;
        public virtual DbSet<GemPersOrgTyp> GemPersOrgTyps { get; set; } = null!;
        public virtual DbSet<GemPersOrgVersion> GemPersOrgVersions { get; set; } = null!;
        public virtual DbSet<GemPersOrgVersionNyastV1> GemPersOrgVersionNyastV1s { get; set; } = null!;
        public virtual DbSet<GemPersOrgVersionNyastV2> GemPersOrgVersionNyastV2s { get; set; } = null!;
        public virtual DbSet<GemPrelRegByggnad> GemPrelRegByggnads { get; set; } = null!;
        public virtual DbSet<Konv240BevPamMissingHpv> Konv240BevPamMissingHpvs { get; set; } = null!;
        public virtual DbSet<Konv240BevPamNsMissingHpv> Konv240BevPamNsMissingHpvs { get; set; } = null!;
        public virtual DbSet<Konv240BevSvarMissingHpv> Konv240BevSvarMissingHpvs { get; set; } = null!;
        public virtual DbSet<Konv240BevUtsMissingFast> Konv240BevUtsMissingFasts { get; set; } = null!;
        public virtual DbSet<Konv240BevUtsMissingHandelseIdUtskick> Konv240BevUtsMissingHandelseIdUtskicks { get; set; } = null!;
        public virtual DbSet<Konv240BevUtsMissingHpv> Konv240BevUtsMissingHpvs { get; set; } = null!;
        public virtual DbSet<Konv240BevUtsMissingHpvroll> Konv240BevUtsMissingHpvrolls { get; set; } = null!;
        public virtual DbSet<OvRbArbeladrGeoV1> OvRbArbeladrGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArbygGeoV1> OvRbArbygGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArendeGeofirV1> OvRbArendeGeofirV1s { get; set; } = null!;
        public virtual DbSet<OvRbArendeobjektGeoV1> OvRbArendeobjektGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArgenomrGeoV1> OvRbArgenomrGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArgraevomrGeoAtgardV1> OvRbArgraevomrGeoAtgardV1s { get; set; } = null!;
        public virtual DbSet<OvRbArgraevomrGeoAtgardV2> OvRbArgraevomrGeoAtgardV2s { get; set; } = null!;
        public virtual DbSet<OvRbArgraevomrGeoAtgardV3> OvRbArgraevomrGeoAtgardV3s { get; set; } = null!;
        public virtual DbSet<OvRbArgraevomrGeoV1> OvRbArgraevomrGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArprelbeladrGeoV1> OvRbArprelbeladrGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArprelbygGeoV1> OvRbArprelbygGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArpreldetplanGeoV1> OvRbArpreldetplanGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArprelfastGeoV1> OvRbArprelfastGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbArtillsynomrGeoV1> OvRbArtillsynomrGeoV1s { get; set; } = null!;
        public virtual DbSet<OvRbFriHandelsGeofirV1> OvRbFriHandelsGeofirV1s { get; set; } = null!;
        public virtual DbSet<OvRbHandelseGeofirV1> OvRbHandelseGeofirV1s { get; set; } = null!;
        public virtual DbSet<OvRbHuvudbeslutGeofirV1> OvRbHuvudbeslutGeofirV1s { get; set; } = null!;
        public virtual DbSet<OvRbHvdhandlaggGeofirV1> OvRbHvdhandlaggGeofirV1s { get; set; } = null!;
        public virtual DbSet<OvRbUHvdbeslGeofirV1> OvRbUHvdbeslGeofirV1s { get; set; } = null!;
        public virtual DbSet<OvkInspectionInterval> OvkInspectionIntervals { get; set; } = null!;
        public virtual DbSet<OvkVentilationSystem> OvkVentilationSystems { get; set; } = null!;
        public virtual DbSet<OvkVentilationSystemType> OvkVentilationSystemTypes { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<TkcGroup> TkcGroups { get; set; } = null!;
        public virtual DbSet<TkcLinkConstraint> TkcLinkConstraints { get; set; } = null!;
        public virtual DbSet<TkcMeaning> TkcMeanings { get; set; } = null!;
        public virtual DbSet<TkcObjectType> TkcObjectTypes { get; set; } = null!;
        public virtual DbSet<TkcObjectTypeAttribute> TkcObjectTypeAttributes { get; set; } = null!;
        public virtual DbSet<TkcOperation> TkcOperations { get; set; } = null!;
        public virtual DbSet<TkcOperationMeaning> TkcOperationMeanings { get; set; } = null!;
        public virtual DbSet<TkcPackage> TkcPackages { get; set; } = null!;
        public virtual DbSet<TkcPermLink> TkcPermLinks { get; set; } = null!;
        public virtual DbSet<TkcPermNode> TkcPermNodes { get; set; } = null!;
        public virtual DbSet<TkcPredicate> TkcPredicates { get; set; } = null!;
        public virtual DbSet<TkcRole> TkcRoles { get; set; } = null!;
        public virtual DbSet<TkcUser> TkcUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=utv-db16;Database=tekisr;Uid=tekisr;Pwd=tekisr;Persist Security Info = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArendebasV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ARENDEBAS_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<ArkArende>(entity =>
            {
                entity.HasKey(e => e.ArendeId)
                    .HasName("XPKarkArende");

                entity.ToTable("arkArende");

                entity.HasIndex(e => new { e.Dnr, e.EnhetId, e.ArendeId }, "XIEARKARENDE_DNRUpper");

                entity.HasIndex(e => new { e.StatusId, e.AnkomstDatum, e.EnhetId }, "XIEARKARENDE_Status_Ank_Dat");

                entity.Property(e => e.AnkomstDatum).HasColumnType("datetime");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ArendeMening)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AtgardSlutDat).HasColumnType("datetime");

                entity.Property(e => e.AtgardStartDat).HasColumnType("datetime");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExtDnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FasStartDatum).HasColumnType("datetime");

                entity.Property(e => e.GallringsAr).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.GallringsDatum).HasColumnType("datetime");

                entity.Property(e => e.Kalla).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MakDatum).HasColumnType("datetime");

                entity.Property(e => e.ProjektNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.SlutDatum).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID");

                entity.Property(e => e.VilandeDatum).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska).HasColumnType("text");

                entity.Property(e => e.XmlUpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.ArendeGrupp)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.ArendeGruppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkArendeGrupp");

                entity.HasOne(d => d.ArendeKlass)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.ArendeKlassId)
                    .HasConstraintName("arkArende_arkArendeKlass");

                entity.HasOne(d => d.ArendeKomplexitet)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.ArendeKomplexitetId)
                    .HasConstraintName("arkArende_ArendeKomplexitet");

                entity.HasOne(d => d.ArendePrioritet)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.ArendePrioritetId)
                    .HasConstraintName("arkArende_ArendePrioritet");

                entity.HasOne(d => d.ArendeSlag)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.ArendeSlagId)
                    .HasConstraintName("arkArende_arkArendeSlag");

                entity.HasOne(d => d.ArendeTyp)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.ArendeTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkArendeTyp");

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.DiarieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkDiarie");

                entity.HasOne(d => d.Enhet)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.EnhetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkEnhet");

                entity.HasOne(d => d.KomKodNavigation)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.KomKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_GEM_KOMMUN");

                entity.HasOne(d => d.Namnd)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.NamndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkNamnd");

                entity.HasOne(d => d.RegSign)
                    .WithMany(p => p.ArkArendeRegSigns)
                    .HasForeignKey(d => d.RegSignId)
                    .HasConstraintName("arkArende_arkHandlagg_RegSign");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkArendeStatus");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkArendeUpdSigns)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkHandlagg_UpdSign");

                entity.HasOne(d => d.ArkDiarieArendeGrupp)
                    .WithMany(p => p.ArkArendes)
                    .HasForeignKey(d => new { d.DiarieId, d.ArendeGruppId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_DiarieArendeGrp");
            });

            modelBuilder.Entity<ArkArendeAtgard>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.AtgardId })
                    .HasName("XPKarkArendeAtgard");

                entity.ToTable("arkArendeAtgard");

                entity.HasIndex(e => e.ArendeKlassId, "XFKarkArendeAtgard_ArendeKlass");

                entity.HasIndex(e => e.ArendeSlagId, "XFKarkArendeAtgard_ArendeSlag");

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkArendeAtgards)
                    .HasForeignKey(d => d.ArendeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_arkArendeAtgard");

                entity.HasOne(d => d.ArendeKlass)
                    .WithMany(p => p.ArkArendeAtgards)
                    .HasForeignKey(d => d.ArendeKlassId)
                    .HasConstraintName("arkArendeKlass_arkArendeAtgard");

                entity.HasOne(d => d.ArendeSlag)
                    .WithMany(p => p.ArkArendeAtgards)
                    .HasForeignKey(d => d.ArendeSlagId)
                    .HasConstraintName("arkArendeSlag_arkArendeAtgard");
            });

            modelBuilder.Entity<ArkArendeBelAdr>(entity =>
            {
                entity.HasKey(e => new { e.ArendeObjektId, e.ObjektId })
                    .HasName("XPKarkArende_BelAdr");

                entity.ToTable("arkArende_BelAdr");

                entity.HasIndex(e => new { e.ArendeObjektId, e.Beladress }, "XAK1arkArende_BelAdr")
                    .IsUnique();

                entity.HasIndex(e => new { e.ObjektId, e.ArendeObjektId }, "XFKarkArende_BelAdr_Objekt");

                entity.Property(e => e.ArendeObjektId).HasColumnName("Arende_ObjektId");

                entity.Property(e => e.Beladress)
                    .HasMaxLength(107)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeObjekt)
                    .WithMany(p => p.ArkArendeBelAdrs)
                    .HasForeignKey(d => d.ArendeObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_BelAdr_ArendeObjekt");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.ArkArendeBelAdrs)
                    .HasForeignKey(d => d.ObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_BelAdr_Objekt");
            });

            modelBuilder.Entity<ArkArendeBeslutV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArende_Beslut_V1");

                entity.Property(e => e.AnkomstDatum).HasColumnType("datetime");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ArendeMening)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExtDnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FasStartDatum).HasColumnType("datetime");

                entity.Property(e => e.GallringsAr).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.GallringsDatum).HasColumnType("datetime");

                entity.Property(e => e.Kalla).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MakDatum).HasColumnType("datetime");

                entity.Property(e => e.ProjektNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.SlutDatum).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID");

                entity.Property(e => e.VilandeDatum).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska).HasColumnType("text");

                entity.Property(e => e.XmlUpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArkArendeGrupp>(entity =>
            {
                entity.HasKey(e => e.ArendeGruppId)
                    .HasName("XPKarkArendeGrupp");

                entity.ToTable("arkArendeGrupp");

                entity.HasIndex(e => new { e.ArendeGruppId, e.ArendeGrupp }, "UK1arkArendeGrupp_ArendeGrupp")
                    .IsUnique();

                entity.HasIndex(e => new { e.DiarieId, e.ArendeGrupp }, "XAK1arkArendeGrupp")
                    .IsUnique();

                entity.HasIndex(e => new { e.DiarieId, e.ArAktiv }, "XFKARKARENDEGRUPP_ARKDIARIE");

                entity.Property(e => e.ArendeGruppId).ValueGeneratedOnAdd();

                entity.Property(e => e.ArendeGrupp)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkArendeGrupps)
                    .HasForeignKey(d => d.DiarieId)
                    .HasConstraintName("arkArendeGrupp_arkDiarie");

                entity.HasOne(d => d.ArkDiarieArendeGrupp)
                    .WithMany(p => p.ArkArendeGrupps)
                    .HasForeignKey(d => new { d.DiarieId, d.ArendeGruppId })
                    .HasConstraintName("arkArendeGrupp_DiarieArendeGrp");
            });

            modelBuilder.Entity<ArkArendeGruppHandlaggare>(entity =>
            {
                entity.HasKey(e => new { e.EnhetId, e.HandlaggareId, e.ArendeGruppId })
                    .HasName("XPKarkArendeGrupp_Handlaggare");

                entity.ToTable("arkArendeGrupp_Handlaggare");

                entity.HasIndex(e => e.ArendeGruppId, "XFKARKARENDEGRUPP_HANDL_AREGRP");

                entity.HasIndex(e => new { e.HandlaggareId, e.EnhetId }, "XFKARKARENDEGRUPP_HANDL_HANDL");

                entity.HasOne(d => d.ArendeGrupp)
                    .WithMany(p => p.ArkArendeGruppHandlaggares)
                    .HasForeignKey(d => d.ArendeGruppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeGrupp_Handl_arkAreGrp");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkArendeGruppHandlaggares)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeGrupp_Handl_arkHandl");

                entity.HasOne(d => d.ArkEnhetHandlaggare)
                    .WithMany(p => p.ArkArendeGruppHandlaggares)
                    .HasForeignKey(d => new { d.EnhetId, d.HandlaggareId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeGrupp_Handl_arkEHandl");
            });

            modelBuilder.Entity<ArkArendeHandlaggare>(entity =>
            {
                entity.HasKey(e => e.ArkArendeHandlId)
                    .HasName("XPKarkArende_Handlaggare");

                entity.ToTable("arkArende_Handlaggare");

                entity.HasIndex(e => new { e.ArendeId, e.HandlaggareId }, "XAK1arkArende_Handlaggare")
                    .IsUnique();

                entity.HasIndex(e => new { e.ArendeId, e.ArHvdHandl, e.HandlaggareId }, "XFKARKARENDE_HANDLAGG_ARENDE");

                entity.HasIndex(e => new { e.HandlaggareId, e.ArHvdHandl, e.ArendeId }, "XIE1arkArende_Handlaggare");

                entity.Property(e => e.ArkArendeHandlId).HasColumnName("arkArende_HandlId");

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkArendeHandlaggares)
                    .HasForeignKey(d => d.ArendeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_Handlagg_arkArende");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkArendeHandlaggares)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_Handlaggare_Hl");

                entity.HasMany(d => d.HandlaggareRolls)
                    .WithMany(p => p.ArkArendeHandls)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArkArendeHandlaggareRoll",
                        l => l.HasOne<ArkHandlaggareRoll>().WithMany().HasForeignKey("HandlaggareRollId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkArende_HandlRoll_arkHlRoll"),
                        r => r.HasOne<ArkArendeHandlaggare>().WithMany().HasForeignKey("ArkArendeHandlId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkArende_HandlRoll_arkAren_Hl"),
                        j =>
                        {
                            j.HasKey("ArkArendeHandlId", "HandlaggareRollId").HasName("XPKarkArende_HandlaggareRoll");

                            j.ToTable("arkArende_HandlaggareRoll");

                            j.IndexerProperty<int>("ArkArendeHandlId").HasColumnName("arkArende_HandlId");
                        });
            });

            modelBuilder.Entity<ArkArendeHandlaggareHvdHlV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArende_Handlaggare_HvdHl_V1");

                entity.Property(e => e.EfterNamn)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Epost)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ForNamn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FsFaktRef)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Fs_FaktRef");

                entity.Property(e => e.HandlSign)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Mobil)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkArendeHvdBeslutV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArende_HvdBeslut_V1");

                entity.Property(e => e.AnkomstDatum).HasColumnType("datetime");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ArendeKlassIdNullTillNoll).HasColumnName("ArendeKlassId_NullTillNoll");

                entity.Property(e => e.ArendeMening)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArendeSlagIdNullTillNoll).HasColumnName("ArendeSlagID_NullTillNoll");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExtDnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FasStartDatum).HasColumnType("datetime");

                entity.Property(e => e.GallringsAr).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.GallringsDatum).HasColumnType("datetime");

                entity.Property(e => e.Kalla).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MakDatum).HasColumnType("datetime");

                entity.Property(e => e.ProjektNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.SlutDatum).HasColumnType("datetime");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID");

                entity.Property(e => e.VilandeDatum).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska).HasColumnType("text");

                entity.Property(e => e.XmlUpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArkArendeKlass>(entity =>
            {
                entity.HasKey(e => e.ArendeKlassId)
                    .HasName("XPKarkArendeKlass");

                entity.ToTable("arkArendeKlass");

                entity.HasIndex(e => new { e.ArendeKlass, e.DiarieId }, "XAK1arkArendeKlass")
                    .IsUnique();

                entity.HasIndex(e => e.DiarieId, "XFKARKARENDEKLASS_ARKDIARIE");

                entity.HasIndex(e => new { e.ArAktiv, e.DiarieId }, "XIE1ARKARENDEKLASS");

                entity.Property(e => e.ArendeKlass)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkArendeKlasses)
                    .HasForeignKey(d => d.DiarieId)
                    .HasConstraintName("arkArendeKlass_arkDiarie");
            });

            modelBuilder.Entity<ArkArendeKomplexitet>(entity =>
            {
                entity.HasKey(e => e.ArendeKomplexitetId)
                    .HasName("XPKarkArendeKomplexitet");

                entity.ToTable("arkArendeKomplexitet");

                entity.Property(e => e.ArendeKomplexitetId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ArkArendeKopplBeskr>(entity =>
            {
                entity.HasKey(e => e.ArendeKopplBeskrId)
                    .HasName("XPKarkArendeKopplBeskr");

                entity.ToTable("arkArendeKopplBeskr");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Arendes)
                    .WithMany(p => p.ArendeKopplBeskrs)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArkArendeKoppl",
                        l => l.HasOne<ArkArende>().WithMany().HasForeignKey("ArendeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkArendeKoppl_arkArende"),
                        r => r.HasOne<ArkArendeKopplBeskr>().WithMany().HasForeignKey("ArendeKopplBeskrId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkArendeKoppl_arkAreKopplBesk"),
                        j =>
                        {
                            j.HasKey("ArendeKopplBeskrId", "ArendeId").HasName("XPKarkArendeKoppl");

                            j.ToTable("arkArendeKoppl");

                            j.HasIndex(new[] { "ArendeId", "ArendeKopplBeskrId" }, "XFKARKARENDEKOPPL_ARKARENDE");
                        });
            });

            modelBuilder.Entity<ArkArendeLgh>(entity =>
            {
                entity.HasKey(e => new { e.ArendeObjektId, e.ObjektId })
                    .HasName("XPKarkArende_Lgh");

                entity.ToTable("arkArende_Lgh");

                entity.HasIndex(e => new { e.ArendeObjektId, e.BelAdrObjektId, e.LghNr }, "XAK1arkArende_Lgh")
                    .IsUnique();

                entity.HasIndex(e => e.ObjektId, "XFKarkArende_Lgh_Objekt");

                entity.Property(e => e.ArendeObjektId).HasColumnName("Arende_ObjektId");

                entity.Property(e => e.BelAdrObjektId).HasColumnName("BelAdr_ObjektId");

                entity.Property(e => e.LghNr)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeObjekt)
                    .WithMany(p => p.ArkArendeLghs)
                    .HasForeignKey(d => d.ArendeObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_Lgh_ArendeObjekt");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.ArkArendeLghs)
                    .HasForeignKey(d => d.ObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_Lgh_Objekt");

                entity.HasOne(d => d.ArkArendeBelAdr)
                    .WithMany(p => p.ArkArendeLghs)
                    .HasForeignKey(d => new { d.ArendeObjektId, d.BelAdrObjektId })
                    .HasConstraintName("arkArende_Lgh_Arende_BelAdr");
            });

            modelBuilder.Entity<ArkArendeMening>(entity =>
            {
                entity.HasKey(e => e.ArendeMeningId)
                    .HasName("XPKarkArendeMening");

                entity.ToTable("arkArendeMening");

                entity.HasIndex(e => new { e.ArendeMening, e.ArendeTypId }, "XAK1arkArendeMening")
                    .IsUnique();

                entity.HasIndex(e => e.ArendeTypId, "XFKARKARENDEMENING_ARENDETYP");

                entity.Property(e => e.ArendeMening)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeTyp)
                    .WithMany(p => p.ArkArendeMenings)
                    .HasForeignKey(d => d.ArendeTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeMening_arkArendeTyp");
            });

            modelBuilder.Entity<ArkArendeMilstolparCrV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArendeMilstolpar_CR_V1");
            });

            modelBuilder.Entity<ArkArendeMilstolparV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArendeMilstolpar_V1");

                entity.Property(e => e.MilstolpeDatum).HasColumnType("datetime");

                entity.Property(e => e.Tidsmatningfranmilstolpeid).HasColumnName("tidsmatningfranmilstolpeid");
            });

            modelBuilder.Entity<ArkArendeObjekt>(entity =>
            {
                entity.HasKey(e => e.ArendeObjektId)
                    .HasName("XPKarkArende_Objekt");

                entity.ToTable("arkArende_Objekt");

                entity.HasIndex(e => new { e.ArendeId, e.ArHvdObjekt }, "XAK1arkArende_Objekt")
                    .IsUnique()
                    .HasFilter("([ArHvdObjekt]=(1))");

                entity.HasIndex(e => new { e.ObjektId, e.ArHvdObjekt }, "XFKARKARENDE_OBJEKT_GEMOBJEKT");

                entity.HasIndex(e => new { e.ArendeId, e.ArHvdObjekt, e.ObjektId }, "XIE1arkArende_Objekt");

                entity.HasIndex(e => new { e.Beskrivning, e.ObjektId }, "XIE2arkArende_Objekt");

                entity.Property(e => e.ArendeObjektId).HasColumnName("Arende_ObjektId");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkArendeObjekts)
                    .HasForeignKey(d => d.ArendeId)
                    .HasConstraintName("arkArende_Objekt_arkArende");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.ArkArendeObjekts)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("arkArende_Objekt_gemObjekt");
            });

            modelBuilder.Entity<ArkArendeObjektHvdObjektV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArende_Objekt_HvdObjekt_V1");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkArendePersOrgVersion>(entity =>
            {
                entity.HasKey(e => e.ArendePersOrgVersionId)
                    .HasName("XPKarkArende_PersOrgVersion");

                entity.ToTable("arkArende_PersOrgVersion");

                entity.HasIndex(e => new { e.ArendeId, e.PersOrgVersionId, e.PersOrgAttentionId }, "XAK1arkArende_PersOrgVersion")
                    .IsUnique();

                entity.HasIndex(e => e.PersOrgVersionId, "XFKARKARENDE_PERSORGV_PERSORGV");

                entity.HasIndex(e => e.PersOrgAttentionId, "XFKARKARENDE_PERSORGV_PRSORGAT");

                entity.Property(e => e.ArendePersOrgVersionId).HasColumnName("Arende_PersOrgVersionId");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkArendePersOrgVersions)
                    .HasForeignKey(d => d.ArendeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_PersOrgVer_arkArende");

                entity.HasOne(d => d.PersOrgAttention)
                    .WithMany(p => p.ArkArendePersOrgVersions)
                    .HasForeignKey(d => d.PersOrgAttentionId)
                    .HasConstraintName("arkArende_PersOrgV_PersOrgAtt");

                entity.HasOne(d => d.PersOrgVersion)
                    .WithMany(p => p.ArkArendePersOrgVersions)
                    .HasForeignKey(d => d.PersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_PersOrgV_arkPersOrgV");
            });

            modelBuilder.Entity<ArkArendePersOrgVersionRoll>(entity =>
            {
                entity.HasKey(e => new { e.ArendePersOrgVersionId, e.Rollid })
                    .HasName("XPKarkArende_PersOrgVersionRoll");

                entity.ToTable("arkArende_PersOrgVersionRoll");

                entity.Property(e => e.ArendePersOrgVersionId).HasColumnName("Arende_PersOrgVersionId");

                entity.Property(e => e.RollDatum).HasColumnType("datetime");

                entity.HasOne(d => d.ArendePersOrgVersion)
                    .WithMany(p => p.ArkArendePersOrgVersionRolls)
                    .HasForeignKey(d => d.ArendePersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_PersOrgVerRoll_Koppl");

                entity.HasOne(d => d.Roll)
                    .WithMany(p => p.ArkArendePersOrgVersionRolls)
                    .HasForeignKey(d => d.Rollid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_PersOrgVerRoll_Roll");
            });

            modelBuilder.Entity<ArkArendePrioritet>(entity =>
            {
                entity.HasKey(e => e.ArendePrioritetId)
                    .HasName("XPKarkArendePrioritet");

                entity.ToTable("arkArendePrioritet");

                entity.Property(e => e.ArendePrioritetId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ArkArendeRegByg>(entity =>
            {
                entity.HasKey(e => new { e.ArendeObjektId, e.ObjektId })
                    .HasName("XPKarkArende_RegByg");

                entity.ToTable("arkArende_RegByg");

                entity.HasIndex(e => new { e.ObjektId, e.ArendeObjektId }, "XFKarkArende_RegByg_Objekt");

                entity.HasIndex(e => new { e.PrelRegByggnadObjektId, e.ArendeObjektId }, "XFKarkPrelRegByg_Arende_RegByg");

                entity.Property(e => e.ArendeObjektId).HasColumnName("Arende_ObjektId");

                entity.HasOne(d => d.ArendeObjekt)
                    .WithMany(p => p.ArkArendeRegBygs)
                    .HasForeignKey(d => d.ArendeObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_RegByg_ArendeObjekt");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.ArkArendeRegBygs)
                    .HasForeignKey(d => d.ObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_RegByg_Objekt");

                entity.HasOne(d => d.PrelRegByggnadObjekt)
                    .WithMany(p => p.ArkArendeRegBygs)
                    .HasForeignKey(d => d.PrelRegByggnadObjektId)
                    .HasConstraintName("gemPrelRegByg_Arende_RegByg");
            });

            modelBuilder.Entity<ArkArendeRemiss>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArendeRemiss");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fnr)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FNR");

                entity.Property(e => e.Remisstext)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SenastSvarDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArkArendeScbstatistik>(entity =>
            {
                entity.HasKey(e => e.ArendeId)
                    .HasName("XPKarkArende_SCBStatistik");

                entity.ToTable("arkArende_SCBStatistik");

                entity.Property(e => e.ArendeId).ValueGeneratedNever();

                entity.Property(e => e.ScbstatistikId).HasColumnName("SCBStatistikId");

                entity.Property(e => e.SenastSandDatum).HasColumnType("datetime");

                entity.Property(e => e.SenastSandMd5checksum)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SenastSandMD5Checksum")
                    .IsFixedLength();

                entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

                entity.HasOne(d => d.Arende)
                    .WithOne(p => p.ArkArendeScbstatistik)
                    .HasForeignKey<ArkArendeScbstatistik>(d => d.ArendeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_SCBStat_Arende");

                entity.HasOne(d => d.Scbstatistik)
                    .WithMany(p => p.ArkArendeScbstatistiks)
                    .HasForeignKey(d => d.ScbstatistikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_SCBStat_SCBStat");
            });

            modelBuilder.Entity<ArkArendeSlag>(entity =>
            {
                entity.HasKey(e => e.ArendeSlagId)
                    .HasName("XPKarkArendeSlag");

                entity.ToTable("arkArendeSlag");

                entity.HasIndex(e => new { e.ArendeSlag, e.ArendeTypId }, "XAK1arkArendeSlag")
                    .IsUnique();

                entity.HasIndex(e => new { e.ArendeTypId, e.ArAktiv }, "XFKARKARENDESLAG_ARKARENDETYP");

                entity.Property(e => e.ArendeSlag)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeTyp)
                    .WithMany(p => p.ArkArendeSlags)
                    .HasForeignKey(d => d.ArendeTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeSlag_arkArendeTyp");
            });

            modelBuilder.Entity<ArkArendeSlagIdNullTill0V1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkArende_SlagID_NullTill_0_V1");

                entity.Property(e => e.AnkomstDatum).HasColumnType("datetime");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ArendeId).ValueGeneratedOnAdd();

                entity.Property(e => e.ArendeKlassIdNullTillNoll).HasColumnName("ArendeKlassId_NullTillNoll");

                entity.Property(e => e.ArendeMening)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArendeSlagIdNullTillNoll).HasColumnName("ArendeSlagID_NullTillNoll");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExtDnr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FasStartDatum).HasColumnType("datetime");

                entity.Property(e => e.GallringsAr).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.GallringsDatum).HasColumnType("datetime");

                entity.Property(e => e.Kalla).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MakDatum).HasColumnType("datetime");

                entity.Property(e => e.ProjektNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.SlutDatum).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID");

                entity.Property(e => e.VilandeDatum).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska).HasColumnType("text");

                entity.Property(e => e.XmlUpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArkArendeStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("XPKarkArendeStatus");

                entity.ToTable("arkArendeStatus");

                entity.HasIndex(e => e.Status, "XAK1arkArendeStatus")
                    .IsUnique();

                entity.Property(e => e.StatusId)
                    .HasColumnType("numeric(1, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkArendeTyp>(entity =>
            {
                entity.HasKey(e => e.ArendeTypId)
                    .HasName("XPKarkArendeTyp");

                entity.ToTable("arkArendeTyp");

                entity.HasIndex(e => new { e.ArendeTyp, e.ArendeGruppId }, "XAK1arkArendeTyp")
                    .IsUnique();

                entity.HasIndex(e => new { e.ArendeGruppId, e.ArAktiv, e.ArendeTypId }, "XFKARKARENDETYP_ARKARENDEGRUPP");

                entity.Property(e => e.ArendeTyp)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeGrupp)
                    .WithMany(p => p.ArkArendeTyps)
                    .HasForeignKey(d => d.ArendeGruppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeTyp_arkArendeGrupp");
            });

            modelBuilder.Entity<ArkArendeTypMilstolpe>(entity =>
            {
                entity.HasKey(e => new { e.ArendeTypId, e.MilstolpeId })
                    .HasName("XPKarkArendeTyp_Milstolpe");

                entity.ToTable("arkArendeTyp_Milstolpe");

                entity.HasIndex(e => new { e.ArendeTypId, e.MilstolpeNr }, "XAK1arkArendeTyp_Milstolpe")
                    .IsUnique();

                entity.HasIndex(e => e.MilstolpeId, "XFKARKARENDETYP_MILSTOLPE_MIST");

                entity.HasIndex(e => new { e.TidsMatningFranMilstolpeId, e.ArendeTypId }, "XFKARKARENDETYP_MILSTOLPE_TIDM");

                entity.HasOne(d => d.ArendeTyp)
                    .WithMany(p => p.ArkArendeTypMilstolpes)
                    .HasForeignKey(d => d.ArendeTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeTyp_Milstolpe_AreTyp");

                entity.HasOne(d => d.Milstolpe)
                    .WithMany(p => p.ArkArendeTypMilstolpes)
                    .HasForeignKey(d => d.MilstolpeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeTyp_Milstolpe_Milst");

                entity.HasOne(d => d.ArkArendeTypMilstolpeNavigation)
                    .WithMany(p => p.InverseArkArendeTypMilstolpeNavigation)
                    .HasForeignKey(d => new { d.ArendeTypId, d.TidsMatningFranMilstolpeId })
                    .HasConstraintName("arkArendeTyp_Milstolpe_Tidm");
            });

            modelBuilder.Entity<ArkBevakatUtskick>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.HandelseIdUtskick, e.UtskickId })
                    .HasName("XPKarkBevakatUtskick");

                entity.ToTable("arkBevakatUtskick");

                entity.HasIndex(e => new { e.HandelsePersOrgVersionId, e.ArendeId, e.HandelseIdUtskick, e.ObjektId }, "XAKarkBevakatUtskick_Pers_Fast")
                    .IsUnique()
                    .HasFilter("([Handelse_PersOrgVersionId]>(9456))");

                entity.HasIndex(e => e.UtskickId, "XAKarkBevakatUtskick_UtskickId")
                    .IsUnique();

                entity.HasIndex(e => e.HandelsePersOrgVersionId, "XFKarkBevakatUtskick_HPVer");

                entity.HasIndex(e => e.ObjektId, "XFKarkBevakatUtskick_Objekt");

                entity.Property(e => e.UtskickId).ValueGeneratedOnAdd();

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HandelsePersOrgVersionId).HasColumnName("Handelse_PersOrgVersionId");

                entity.Property(e => e.SenastSvarDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.UtskickText)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.HandelsePersOrgVersion)
                    .WithMany(p => p.ArkBevakatUtskicks)
                    .HasForeignKey(d => d.HandelsePersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskick_HPVer");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.ArkBevakatUtskicks)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("arkBevakatUtskick_gemObjekt");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkBevakatUtskicks)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskick_Handl_UpdSig");

                entity.HasOne(d => d.ArkBevakatUtskickOmg)
                    .WithMany(p => p.ArkBevakatUtskicks)
                    .HasForeignKey(d => new { d.ArendeId, d.HandelseIdUtskick })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskick_Omg");

                entity.HasOne(d => d.ArkHandelsePersOrgVersionRoll)
                    .WithMany(p => p.ArkBevakatUtskicks)
                    .HasForeignKey(d => new { d.Rollid, d.HandelsePersOrgVersionId })
                    .HasConstraintName("arkBevakatUtskick_HPVerRoll");
            });

            modelBuilder.Entity<ArkBevakatUtskickOldMod>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkBevakatUtskick_OldMod");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fnr)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FNR");

                entity.Property(e => e.SenastSvarDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Utskicktext)
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkBevakatUtskickOldModel>(entity =>
            {
                entity.HasKey(e => e.UtskickId)
                    .HasName("XPKarkBevakatUtskick_OldModel");

                entity.ToTable("arkBevakatUtskick_OldModel");

                entity.HasIndex(e => new { e.ArendeId, e.UtskickTyp }, "XFKARKBEVAKATUTSKICK_ARKARENDE");

                entity.HasIndex(e => new { e.HandelseIdPaminn, e.UtskickTyp }, "XFKARKBEVAKATUTSKICK_HNDLS_PAM");

                entity.HasIndex(e => new { e.HandelseIdSvar, e.UtskickTyp }, "XFKARKBEVAKATUTSKICK_HNDLS_SV");

                entity.HasIndex(e => new { e.HandelseIdUtskick, e.UtskickTyp }, "XFKARKBEVAKATUTSKICK_HNDLS_UTS");

                entity.HasIndex(e => new { e.PersOrgAttentionId, e.UtskickTyp }, "XFKARKBEVAKATUTSKICK_PERSORGAT");

                entity.HasIndex(e => new { e.PersOrgVersionId, e.UtskickTyp }, "XFKARKBEVAKATUTSKICK_PERSORGV");

                entity.HasIndex(e => new { e.HandelseIdPaminnNastSenast, e.UtskickTyp }, "XFKARKBEVAKATUT_HAND_PAMNSTSEN");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.SenastSvarDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.UtskickText)
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkBevakatUtskickOmg>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.HandelseIdUtskick })
                    .HasName("XPKarkBevakatUtskickOmg");

                entity.ToTable("arkBevakatUtskickOmg");

                entity.HasIndex(e => new { e.ArendeId, e.UtskickTyp, e.Omgang }, "XAKarkBevakatUtskickOmg_Omgang")
                    .IsUnique();

                entity.HasIndex(e => e.HandelseIdUtskick, "XFKarkBevakatUtskickOmg_H_Uts")
                    .IsUnique();

                entity.Property(e => e.MeddelandeMall)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkBevakatUtskickOmgs)
                    .HasForeignKey(d => d.ArendeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickOmg_Are");

                entity.HasOne(d => d.HandelseIdUtskickNavigation)
                    .WithOne(p => p.ArkBevakatUtskickOmg)
                    .HasForeignKey<ArkBevakatUtskickOmg>(d => d.HandelseIdUtskick)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickOmg_Hdlse_Uts");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkBevakatUtskickOmgs)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickOmg_UpdSign");
            });

            modelBuilder.Entity<ArkBevakatUtskickPam>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.HandelseIdUtskick, e.UtskickId, e.HandelseIdPaminn })
                    .HasName("XPKarkBevakatUtskickPam");

                entity.ToTable("arkBevakatUtskickPam");

                entity.HasIndex(e => e.HandelsePersOrgVersionId, "XFKarkBevakatUtskickPam_HPVer");

                entity.Property(e => e.HandelsePersOrgVersionId).HasColumnName("Handelse_PersOrgVersionId");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.UtskickText)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.HandelsePersOrgVersion)
                    .WithMany(p => p.ArkBevakatUtskickPams)
                    .HasForeignKey(d => d.HandelsePersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPam_HPVer");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkBevakatUtskickPams)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPam_UpdSign");

                entity.HasOne(d => d.ArkBevakatUtskickPamOmg)
                    .WithMany(p => p.ArkBevakatUtskickPams)
                    .HasForeignKey(d => new { d.ArendeId, d.HandelseIdUtskick, d.HandelseIdPaminn })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPam_Omg");

                entity.HasOne(d => d.ArkBevakatUtskick)
                    .WithMany(p => p.ArkBevakatUtskickPams)
                    .HasForeignKey(d => new { d.ArendeId, d.HandelseIdUtskick, d.UtskickId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPam_BevUtsk");
            });

            modelBuilder.Entity<ArkBevakatUtskickPamOmg>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.HandelseIdUtskick, e.HandelseIdPaminn })
                    .HasName("XPKarkBevakatUtskickPamOmg");

                entity.ToTable("arkBevakatUtskickPamOmg");

                entity.HasIndex(e => e.HandelseIdPaminn, "XFKarkBevakatUtskickPamOmg_Hnd");

                entity.Property(e => e.MeddelandeMall)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.HandelseIdPaminnNavigation)
                    .WithMany(p => p.ArkBevakatUtskickPamOmgs)
                    .HasForeignKey(d => d.HandelseIdPaminn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPamOmg_Hdlse");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkBevakatUtskickPamOmgs)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPamOmg_UpdSig");

                entity.HasOne(d => d.ArkBevakatUtskickOmg)
                    .WithMany(p => p.ArkBevakatUtskickPamOmgs)
                    .HasForeignKey(d => new { d.ArendeId, d.HandelseIdUtskick })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickPamOmg_Omg");
            });

            modelBuilder.Entity<ArkBevakatUtskickSvar>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.HandelseIdUtskick, e.UtskickId, e.HandelseIdSvar })
                    .HasName("XPKarkBevakatUtskickSvar");

                entity.ToTable("arkBevakatUtskickSvar");

                entity.HasIndex(e => new { e.Rollid, e.HandelsePersOrgVersionId }, "XFKarkBevakatUtskickSv_HPVRoll");

                entity.HasIndex(e => e.UtskickId, "XFKarkBevakatUtskickSv_UtskId");

                entity.HasIndex(e => e.HandelsePersOrgVersionId, "XFKarkBevakatUtskickSvar_HPVer");

                entity.HasIndex(e => e.HandelseIdSvar, "XFKarkBevakatUtskickSvar_Hndls");

                entity.Property(e => e.HandelsePersOrgVersionId).HasColumnName("Handelse_PersOrgVersionId");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.HandelseIdSvarNavigation)
                    .WithMany(p => p.ArkBevakatUtskickSvars)
                    .HasForeignKey(d => d.HandelseIdSvar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickSvar_Handelse");

                entity.HasOne(d => d.HandelsePersOrgVersion)
                    .WithMany(p => p.ArkBevakatUtskickSvars)
                    .HasForeignKey(d => d.HandelsePersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickSvar_HPVer");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkBevakatUtskickSvars)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickSvar_UpdSign");

                entity.HasOne(d => d.ArkHandelsePersOrgVersionRoll)
                    .WithMany(p => p.ArkBevakatUtskickSvars)
                    .HasForeignKey(d => new { d.Rollid, d.HandelsePersOrgVersionId })
                    .HasConstraintName("arkBevakatUtskickSvar_HPVeRoll");

                entity.HasOne(d => d.ArkBevakatUtskick)
                    .WithMany(p => p.ArkBevakatUtskickSvars)
                    .HasForeignKey(d => new { d.ArendeId, d.HandelseIdUtskick, d.UtskickId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakatUtskickSvar_BevUtsk");
            });

            modelBuilder.Entity<ArkBevakning>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("arkBevakning");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BevaknTyp)
                    .WithMany()
                    .HasForeignKey(d => d.BevaknTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakning_arkBevakningsTyp");

                entity.HasOne(d => d.Bevakning)
                    .WithMany()
                    .HasForeignKey(d => d.BevakningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkBevakning_arkNotifiering");
            });

            modelBuilder.Entity<ArkBevakningsTyp>(entity =>
            {
                entity.HasKey(e => e.BevaknTypId)
                    .HasName("XPKarkBevakningsTyp");

                entity.ToTable("arkBevakningsTyp");

                entity.HasIndex(e => e.BevaknTyp, "XAK1arkBevakningsTyp")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BevaknTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkDiarie>(entity =>
            {
                entity.HasKey(e => e.DiarieId)
                    .HasName("XPKarkDiarie");

                entity.ToTable("arkDiarie");

                entity.HasIndex(e => e.Prefix, "XAK1arkDiarie")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkDiarieArendeGrupp>(entity =>
            {
                entity.HasKey(e => new { e.DiarieId, e.ArendeGruppId })
                    .HasName("XPKarkDiarie_ArendeGrupp");

                entity.ToTable("arkDiarie_ArendeGrupp");

                entity.HasIndex(e => new { e.DiarieId, e.ArendeGruppUniquenessCheck }, "XAK1arkDiarie_ArendeGrupp")
                    .IsUnique()
                    .HasFilter("([ArendeGruppUniquenessCheck] IS NOT NULL)");

                entity.HasIndex(e => e.ArendeGruppId, "XFKarkDiarieArGrp_ArendeGrupp");

                entity.Property(e => e.ArendeGruppUniquenessCheck)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeGrupp)
                    .WithMany(p => p.ArkDiarieArendeGruppArendeGrupps)
                    .HasForeignKey(d => d.ArendeGruppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkDiarieArGrp_ArendeGrupp");

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkDiarieArendeGrupps)
                    .HasForeignKey(d => d.DiarieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkDiarieArendeGrupp_Diarie");

                entity.HasOne(d => d.ArendeGruppNavigation)
                    .WithMany(p => p.ArkDiarieArendeGruppArendeGruppNavigations)
                    .HasPrincipalKey(p => new { p.ArendeGruppId, p.ArendeGrupp })
                    .HasForeignKey(d => new { d.ArendeGruppId, d.ArendeGruppUniquenessCheck })
                    .HasConstraintName("arkDiarieArendeGrupp_ArGrp_Kod");
            });

            modelBuilder.Entity<ArkDnr>(entity =>
            {
                entity.HasKey(e => new { e.DiarieId, e.Ar, e.Nummer })
                    .HasName("XPKarkDnr");

                entity.ToTable("arkDnr");

                entity.HasIndex(e => e.DiarieId, "XFKARKDNR_ARKDIARIE");

                entity.Property(e => e.Ar).HasColumnType("numeric(4, 0)");

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkDnrs)
                    .HasForeignKey(d => d.DiarieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkDnr_arkDiarie");
            });

            modelBuilder.Entity<ArkEnhet>(entity =>
            {
                entity.HasKey(e => e.EnhetId)
                    .HasName("XPKarkEnhet");

                entity.ToTable("arkEnhet");

                entity.HasIndex(e => e.Enhet, "XAK1arkEnhet")
                    .IsUnique();

                entity.Property(e => e.ArendeBekraftelseText)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ArkivbildareKod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BesokAdress)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Enhet)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnhetKod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnhetsLogga)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Epost)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.OrgNr)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PostAdress)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PostNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.PostOrt)
                    .HasMaxLength(27)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonNr)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.WebbAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkEnhets)
                    .HasForeignKey(d => d.DiarieId)
                    .HasConstraintName("arkEnhet_arkDiarie");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.ArkEnhets)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkEnhet_arkProdukt");
            });

            modelBuilder.Entity<ArkEnhetHandlaggare>(entity =>
            {
                entity.HasKey(e => new { e.EnhetId, e.HandlaggareId })
                    .HasName("XPKarkEnhet_Handlaggare");

                entity.ToTable("arkEnhet_Handlaggare");

                entity.HasIndex(e => new { e.HandlaggareId, e.EnhetId }, "XFKARKENHET_HANDLAGGARE_HANDL");

                entity.Property(e => e.FromDat).HasColumnType("datetime");

                entity.Property(e => e.TomDat).HasColumnType("datetime");

                entity.HasOne(d => d.Enhet)
                    .WithMany(p => p.ArkEnhetHandlaggares)
                    .HasForeignKey(d => d.EnhetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkEnhet_Handlaggare_arkEnhet");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkEnhetHandlaggares)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkEnhet_Handlaggare_arkHandl");
            });

            modelBuilder.Entity<ArkFra>(entity =>
            {
                entity.HasKey(e => e.FrasId)
                    .HasName("XPKarkFras");

                entity.ToTable("arkFras");

                entity.HasIndex(e => new { e.FrasTypId, e.FrasKod }, "XAK1arkFras")
                    .IsUnique();

                entity.HasIndex(e => e.FrasTypId, "XFKARKFRAS_ARKFRASTYP");

                entity.Property(e => e.Fras)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FrasKod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FrasTyp)
                    .WithMany(p => p.ArkFras)
                    .HasForeignKey(d => d.FrasTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkFras_arkFrasTyp");
            });

            modelBuilder.Entity<ArkFrasGrupp>(entity =>
            {
                entity.HasKey(e => e.FrasGruppId)
                    .HasName("XPKarkFrasGrupp");

                entity.ToTable("arkFrasGrupp");

                entity.HasIndex(e => e.DiarieId, "XFKARKFRASGRUPP_ARKDIARIE");

                entity.Property(e => e.FrasGruppBeskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FrasGruppKod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkFrasGrupps)
                    .HasForeignKey(d => d.DiarieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkFrasGrupp_arkDiarie");
            });

            modelBuilder.Entity<ArkFrasTyp>(entity =>
            {
                entity.HasKey(e => e.FrasTypId)
                    .HasName("XPKarkFrasTyp");

                entity.ToTable("arkFrasTyp");

                entity.HasIndex(e => e.FrasGruppId, "XFKARKFRASTYP_ARKFRASGRUPP");

                entity.Property(e => e.FrasTypBeskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FrasTypKod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FrasGrupp)
                    .WithMany(p => p.ArkFrasTyps)
                    .HasForeignKey(d => d.FrasGruppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkFrasTyp_arkFrasGrupp");
            });

            modelBuilder.Entity<ArkGenerellHandling>(entity =>
            {
                entity.HasKey(e => e.GenerellHandlingId)
                    .HasName("XPKarkGenerellHandling");

                entity.ToTable("arkGenerellHandling");

                entity.Property(e => e.FilNamn)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkGenerellHandlings)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkGenerellHandling_Handlaggare_UpdSig");
            });

            modelBuilder.Entity<ArkGenerellHandlingGenerellHandlingKategori>(entity =>
            {
                entity.HasKey(e => e.GenerellHandlingGenerellHandlingKategoriId)
                    .HasName("XPKarkGenerellHandling_GenerellHandlingKategori");

                entity.ToTable("arkGenerellHandling_GenerellHandlingKategori");

                entity.Property(e => e.GenerellHandlingGenerellHandlingKategoriId).HasColumnName("GenerellHandling_GenerellHandlingKategoriId");

                entity.HasOne(d => d.GenerellHandling)
                    .WithMany(p => p.ArkGenerellHandlingGenerellHandlingKategoris)
                    .HasForeignKey(d => d.GenerellHandlingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkGenerellHandling_GenerellHandlingKategori_GenerellHandlingId");

                entity.HasOne(d => d.GenerellHandlingKategori)
                    .WithMany(p => p.ArkGenerellHandlingGenerellHandlingKategoris)
                    .HasForeignKey(d => d.GenerellHandlingKategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkGenerellHandling_GenerellHandlingKategori_GenerellHandlingKategoriId");
            });

            modelBuilder.Entity<ArkGenerellHandlingKategori>(entity =>
            {
                entity.HasKey(e => e.GenerellHandlingKategoriId)
                    .HasName("XPKarkGenerellHandlingKategori");

                entity.ToTable("arkGenerellHandlingKategori");

                entity.HasIndex(e => e.Beskrivning, "UQarkGenerellHandlingKategori_Beskrivning")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkHandelse>(entity =>
            {
                entity.HasKey(e => e.HandelseId)
                    .HasName("XPKarkHandelse");

                entity.ToTable("arkHandelse");

                entity.HasIndex(e => new { e.ArendeId, e.HandelseId }, "XAKarkHandelse_ArendeId_HId")
                    .IsUnique();

                entity.HasIndex(e => new { e.HandelseTypId, e.StartDatum }, "XIEARKHANDELSE_HT_SDat");

                entity.HasIndex(e => e.StartDatum, "XIEARKHANDELSE_StartDat");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Fgsid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("FGSId");

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.Rubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SekretessKapitel)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SekretessParagraf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SlutDatum).HasColumnType("datetime");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska).HasColumnType("text");

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkHandelses)
                    .HasForeignKey(d => d.ArendeId)
                    .HasConstraintName("arkHandelse_arkArende");

                entity.HasOne(d => d.Enhet)
                    .WithMany(p => p.ArkHandelses)
                    .HasForeignKey(d => d.EnhetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_arkEnhet");

                entity.HasOne(d => d.HandelseSlag)
                    .WithMany(p => p.ArkHandelseHandelseSlags)
                    .HasForeignKey(d => d.HandelseSlagId)
                    .HasConstraintName("arkHandelse_arkHandelseSlag");

                entity.HasOne(d => d.HandelseTyp)
                    .WithMany(p => p.ArkHandelses)
                    .HasForeignKey(d => d.HandelseTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_arkHandelseTyp");

                entity.HasOne(d => d.HandelseUtfalls)
                    .WithMany(p => p.ArkHandelseHandelseUtfalls)
                    .HasForeignKey(d => d.HandelseUtfallsId)
                    .HasConstraintName("arkHandelse_arkHandelseUtfall");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkHandelseHandlaggares)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_arkHandl_Hl");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.ArkHandelses)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("arkHandelse_gemObjekt");

                entity.HasOne(d => d.RefHandelse)
                    .WithMany(p => p.InverseRefHandelse)
                    .HasForeignKey(d => d.RefHandelseId)
                    .HasConstraintName("arkHandelse_Handelse_refHand");

                entity.HasOne(d => d.RegSign)
                    .WithMany(p => p.ArkHandelseRegSigns)
                    .HasForeignKey(d => d.RegSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_arkHandl_RegSign");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkHandelseUpdSigns)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_arkHandl_UpdSign");

                entity.HasOne(d => d.Handelse)
                    .WithMany(p => p.ArkHandelseHandelses)
                    .HasPrincipalKey(p => new { p.HandelseSlagId, p.HandelseUtfallsId })
                    .HasForeignKey(d => new { d.HandelseSlagId, d.HandelseUtfallsId })
                    .HasConstraintName("arkHandelse_arkHandelseUtf_uk");

                entity.HasOne(d => d.HandelseNavigation)
                    .WithMany(p => p.ArkHandelseHandelseNavigations)
                    .HasPrincipalKey(p => new { p.HandelseTypId, p.HandelseSlagId })
                    .HasForeignKey(d => new { d.HandelseTypId, d.HandelseSlagId })
                    .HasConstraintName("arkHandelse_arkHandelseSlag_uk");
            });

            modelBuilder.Entity<ArkHandelseBeslut>(entity =>
            {
                entity.HasKey(e => e.HandelseId)
                    .HasName("XPKarkHandelseBeslut");

                entity.ToTable("arkHandelseBeslut");

                entity.HasIndex(e => new { e.HandelseId, e.ArHuvudBeslut }, "XFKARKHANDELSEBESLUT_HANDELSE");

                entity.Property(e => e.HandelseId).ValueGeneratedNever();

                entity.Property(e => e.BeslutNr)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BeslutsText)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.GiltigTillDatum).HasColumnType("datetime");

                entity.HasOne(d => d.HandelseBeslutInstansTyp)
                    .WithMany(p => p.ArkHandelseBesluts)
                    .HasForeignKey(d => d.HandelseBeslutInstansTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandBesl_arkHandBeslinstans");

                entity.HasOne(d => d.Handelse)
                    .WithOne(p => p.ArkHandelseBeslut)
                    .HasForeignKey<ArkHandelseBeslut>(d => d.HandelseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelseBeslut_arkHandelse");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkHandelseBesluts)
                    .HasForeignKey(d => d.HandlaggareId)
                    .HasConstraintName("arkHandelseBesl_arkHandlaggare");
            });

            modelBuilder.Entity<ArkHandelseBeslutInstansTyp>(entity =>
            {
                entity.HasKey(e => e.HandelseBeslutInstansTypId)
                    .HasName("XPKarkHandelseBeslutInstansTyp");

                entity.ToTable("arkHandelseBeslutInstansTyp");

                entity.HasIndex(e => e.InstansTyp, "XAK1arkHandelseBeslutInstansTy")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InstansPrefix)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InstansTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkHandelseBeslutNr>(entity =>
            {
                entity.HasKey(e => new { e.DiarieId, e.Ar })
                    .HasName("XPKarkHandelseBeslutNr");

                entity.ToTable("arkHandelseBeslutNr");

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkHandelseBeslutNrs)
                    .HasForeignKey(d => d.DiarieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelseBeslutNr_arkDiarie");
            });

            modelBuilder.Entity<ArkHandelseFordefinierad>(entity =>
            {
                entity.HasKey(e => e.HandelseFordefinieradId);

                entity.ToTable("arkHandelseFordefinierad");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.HandelseFordefinierad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportFilename)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.HandelseSlag)
                    .WithMany(p => p.ArkHandelseFordefinierads)
                    .HasForeignKey(d => d.HandelseSlagId)
                    .HasConstraintName("FK_arkHandelseFordefinierad_arkHandelseSlag");

                entity.HasOne(d => d.HandelseTyp)
                    .WithMany(p => p.ArkHandelseFordefinierads)
                    .HasForeignKey(d => d.HandelseTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_arkHandelseFordefinierad_arkHandelseTyp");

                entity.HasOne(d => d.HandelseUtfalls)
                    .WithMany(p => p.ArkHandelseFordefinierads)
                    .HasForeignKey(d => d.HandelseUtfallsId)
                    .HasConstraintName("FK_arkHandelseFordefinierad_arkHandelseUtfall");

                entity.HasOne(d => d.HandlingStatus)
                    .WithMany(p => p.ArkHandelseFordefinierads)
                    .HasForeignKey(d => d.HandlingStatusId)
                    .HasConstraintName("FK_arkHandelseFordefinierad_arkHandlingStatus");

                entity.HasOne(d => d.HandlingTyp)
                    .WithMany(p => p.ArkHandelseFordefinierads)
                    .HasForeignKey(d => d.HandlingTypId)
                    .HasConstraintName("FK_arkHandelseFordefinierad_arkHandlingTyp");
            });

            modelBuilder.Entity<ArkHandelseHandling>(entity =>
            {
                entity.HasKey(e => new { e.HandelseId, e.HandlingId })
                    .HasName("XPKarkHandelse_Handling");

                entity.ToTable("arkHandelse_Handling");

                entity.HasIndex(e => new { e.HandlingId, e.HandelseId }, "XFKARKHANDELSE_HANDLING_HANDL");

                entity.HasOne(d => d.Handelse)
                    .WithMany(p => p.ArkHandelseHandlings)
                    .HasForeignKey(d => d.HandelseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_Handling_Handelse");

                entity.HasOne(d => d.Handling)
                    .WithMany(p => p.ArkHandelseHandlings)
                    .HasForeignKey(d => d.HandlingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_Handling_Handling");
            });

            modelBuilder.Entity<ArkHandelsePersOrgVersion>(entity =>
            {
                entity.HasKey(e => e.HandelsePersOrgVersionId)
                    .HasName("XPKarkHandelse_PersOrgVersion");

                entity.ToTable("arkHandelse_PersOrgVersion");

                entity.HasIndex(e => new { e.HandelseId, e.PersOrgVersionId, e.PersOrgAttentionId, e.PersorgKomunikationTypId }, "XAK1arkHandelse_PersOrgVersion")
                    .IsUnique();

                entity.HasIndex(e => new { e.HandelseId, e.PersOrgVersionId }, "XFKARKHANDELSE_PERSORGV_HNDLSE");

                entity.HasIndex(e => e.PersorgKomunikationTypId, "XFKARKHANDELSE_PERSORGV_KOMTID");

                entity.HasIndex(e => new { e.PersOrgVersionId, e.HandelseId }, "XFKARKHANDELSE_PERSORGV_PEORGV");

                entity.HasIndex(e => e.PersOrgAttentionId, "XFKARKHANDELS_PERSORGV_PORGATT");

                entity.Property(e => e.HandelsePersOrgVersionId).HasColumnName("Handelse_PersOrgVersionId");

                entity.Property(e => e.PersorgKomunikationTypId).HasColumnName("Persorg_KomunikationTypId");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.Handelse)
                    .WithMany(p => p.ArkHandelsePersOrgVersions)
                    .HasForeignKey(d => d.HandelseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_PersOrgV_Handelse");

                entity.HasOne(d => d.PersOrgAttention)
                    .WithMany(p => p.ArkHandelsePersOrgVersions)
                    .HasForeignKey(d => d.PersOrgAttentionId)
                    .HasConstraintName("arkHandels_PersOrgV_PersOrgAtt");

                entity.HasOne(d => d.PersOrgVersion)
                    .WithMany(p => p.ArkHandelsePersOrgVersions)
                    .HasForeignKey(d => d.PersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_PersOrgV_PersOrgV");

                entity.HasOne(d => d.PersorgKomunikationTyp)
                    .WithMany(p => p.ArkHandelsePersOrgVersions)
                    .HasForeignKey(d => d.PersorgKomunikationTypId)
                    .HasConstraintName("arkHandelse_PersOrgV_KomTypID");
            });

            modelBuilder.Entity<ArkHandelsePersOrgVersionRoll>(entity =>
            {
                entity.HasKey(e => new { e.Rollid, e.HandelsePersOrgVersionId })
                    .HasName("XPKarkHandelse_PersOrgVersionRoll");

                entity.ToTable("arkHandelse_PersOrgVersionRoll");

                entity.HasIndex(e => new { e.HandelsePersOrgVersionId, e.Rollid }, "XFKARKHANDELSE_PERSORGVROLL_KP");

                entity.Property(e => e.HandelsePersOrgVersionId).HasColumnName("Handelse_PersOrgVersionId");

                entity.Property(e => e.RollDatum).HasColumnType("datetime");

                entity.HasOne(d => d.HandelsePersOrgVersion)
                    .WithMany(p => p.ArkHandelsePersOrgVersionRolls)
                    .HasForeignKey(d => d.HandelsePersOrgVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_PersOrgVRoll_Koppl");

                entity.HasOne(d => d.Roll)
                    .WithMany(p => p.ArkHandelsePersOrgVersionRolls)
                    .HasForeignKey(d => d.Rollid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelse_PersOrgVRoll_Roll");
            });

            modelBuilder.Entity<ArkHandelseSlag>(entity =>
            {
                entity.HasKey(e => e.HandelseSlagId)
                    .HasName("XPKarkHandelseSlag");

                entity.ToTable("arkHandelseSlag");

                entity.HasIndex(e => new { e.HandelseTypId, e.HandelseSlagId }, "UKarkHandelseSlag_HTyp_Hslag")
                    .IsUnique();

                entity.HasIndex(e => new { e.HandelseTypId, e.HandelseSlag }, "XAK1arkHandelseSlag")
                    .IsUnique();

                entity.HasIndex(e => e.RutinKodId, "XFKARKHANDELSESLAG_ARKRUTINKOD");

                entity.HasIndex(e => new { e.HandelseTypId, e.ArAktiv, e.RutinKodId }, "XFKARKHANDELSESLAG_HANDELSETYP");

                entity.HasIndex(e => e.MilstolpeId, "XFKARKHANDELSESLAG_MILSTOLPE");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HandelseSlag)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.HandelseTyp)
                    .WithMany(p => p.ArkHandelseSlags)
                    .HasForeignKey(d => d.HandelseTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelseSlag_arkHandelseTyp");

                entity.HasOne(d => d.Milstolpe)
                    .WithMany(p => p.ArkHandelseSlags)
                    .HasForeignKey(d => d.MilstolpeId)
                    .HasConstraintName("arkHandelseSlag_Milstolpe");

                entity.HasOne(d => d.RutinKod)
                    .WithMany(p => p.ArkHandelseSlags)
                    .HasForeignKey(d => d.RutinKodId)
                    .HasConstraintName("arkHandelseSlag_arkRutinKod");
            });

            modelBuilder.Entity<ArkHandelseTyp>(entity =>
            {
                entity.HasKey(e => e.HandelseTypId)
                    .HasName("XPKarkHandelseTyp");

                entity.ToTable("arkHandelseTyp");

                entity.HasIndex(e => new { e.HandelseTyp, e.ArendeGruppId }, "XAK1arkHandelseTyp")
                    .IsUnique();

                entity.HasIndex(e => new { e.ArendeGruppId, e.ArAktiv }, "XFKARKHANDELSETYP_ARENDEGRUPP");

                entity.HasIndex(e => e.RutinKodId, "XFKARKHANDELSETYP_ARKRUTINKOD");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HandelseTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeGrupp)
                    .WithMany(p => p.ArkHandelseTyps)
                    .HasForeignKey(d => d.ArendeGruppId)
                    .HasConstraintName("arkHandelseTyp_arkArendeGrupp");

                entity.HasOne(d => d.RutinKod)
                    .WithMany(p => p.ArkHandelseTyps)
                    .HasForeignKey(d => d.RutinKodId)
                    .HasConstraintName("arkHandelseTyp_arkRutinKod");
            });

            modelBuilder.Entity<ArkHandelseUtfall>(entity =>
            {
                entity.HasKey(e => e.HandelseUtfallsId)
                    .HasName("XPKarkHandelseUtfall");

                entity.ToTable("arkHandelseUtfall");

                entity.HasIndex(e => new { e.HandelseSlagId, e.HandelseUtfallsId }, "UKarkHandelseUtfall_HSlag_HUtf")
                    .IsUnique();

                entity.HasIndex(e => new { e.HandelseSlagId, e.HandelseUtfall }, "XAK1arkHandelseUtfall")
                    .IsUnique();

                entity.HasIndex(e => new { e.HandelseSlagId, e.ArAktiv }, "XFKARKHANDELSEUTFALL_HNDLSSLAG");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HandelseUtfall)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rubrik)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.HandelseSlag)
                    .WithMany(p => p.ArkHandelseUtfalls)
                    .HasForeignKey(d => d.HandelseSlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandelseUtfall_HandelseSlag");
            });

            modelBuilder.Entity<ArkHandlaggare>(entity =>
            {
                entity.HasKey(e => e.HandlaggareId)
                    .HasName("XPKarkHandlaggare");

                entity.ToTable("arkHandlaggare");

                entity.HasIndex(e => e.HandlSign, "XAK1arkHandlaggare")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "XAK2arkHandlaggare")
                    .IsUnique()
                    .HasFilter("([UserName] IS NOT NULL)");

                entity.Property(e => e.ByggRepostVisningsnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ByggREpostVisningsnamn");

                entity.Property(e => e.EfterNamn)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Epost)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ForNamn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FsFaktRef)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Fs_FaktRef");

                entity.Property(e => e.HandlSign)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Mobil)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkHandlaggareRoll>(entity =>
            {
                entity.HasKey(e => e.HandlaggareRollId)
                    .HasName("XPKarkHandlaggareRoll");

                entity.ToTable("arkHandlaggareRoll");

                entity.HasIndex(e => e.Beskrivning, "XAK1arkHandlaggareRoll")
                    .IsUnique();

                entity.HasIndex(e => e.EnhetId, "XFKARKHANDLAGGAREROLL_ARKENHET");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Roll)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Enhet)
                    .WithMany(p => p.ArkHandlaggareRolls)
                    .HasForeignKey(d => d.EnhetId)
                    .HasConstraintName("arkHandlaggareRoll_arkEnhet");
            });

            modelBuilder.Entity<ArkHandling>(entity =>
            {
                entity.HasKey(e => e.HandlingId)
                    .HasName("XPKarkHandling");

                entity.ToTable("arkHandling");

                entity.HasIndex(e => e.DoclinkId, "XAKARKHANDLING_GEM_DMSDOCLINK")
                    .IsUnique()
                    .HasFilter("([Doclink_Id] IS NOT NULL)");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.DoclinkId).HasColumnName("DOCLINK_ID");

                entity.Property(e => e.EjGallandeFranDatum).HasColumnType("datetime");

                entity.Property(e => e.ExtRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HandlingDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID");

                entity.HasOne(d => d.Doclink)
                    .WithOne(p => p.ArkHandling)
                    .HasForeignKey<ArkHandling>(d => d.DoclinkId)
                    .HasConstraintName("arkHandling_Gem_DMSDocLink");

                entity.HasOne(d => d.HandlingStatus)
                    .WithMany(p => p.ArkHandlings)
                    .HasForeignKey(d => d.HandlingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandling_arkHandlingStatus");

                entity.HasOne(d => d.HandlingTyp)
                    .WithMany(p => p.ArkHandlings)
                    .HasForeignKey(d => d.HandlingTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkHandling_arkHandlingTyp");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.ArkHandlings)
                    .HasForeignKey(d => d.UpdSignId)
                    .HasConstraintName("arkHandling_Handlaggare_UpdSig");
            });

            modelBuilder.Entity<ArkHandlingArkstatus231Konv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("arkHandling_Arkstatus_231_Konv");

                entity.Property(e => e.HandlingDatum).HasColumnType("datetime");

                entity.Property(e => e.HandlingId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ArkHandlingStatus>(entity =>
            {
                entity.HasKey(e => e.HandlingStatusId)
                    .HasName("XPKarkHandlingStatus");

                entity.ToTable("arkHandlingStatus");

                entity.HasIndex(e => e.Status, "XAK1arkHandlingStatus")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkHandlingTyp>(entity =>
            {
                entity.HasKey(e => e.HandlingTypId)
                    .HasName("XPKarkHandlingTyp");

                entity.ToTable("arkHandlingTyp");

                entity.HasIndex(e => e.HandlingTyp, "XAK1arkHandlingTyp")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HandlingTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkInkorg>(entity =>
            {
                entity.HasKey(e => e.InkorgId)
                    .HasName("XPKarkInkorg");

                entity.ToTable("arkInkorg");

                entity.HasIndex(e => new { e.RegHandelseId, e.MeddelandeKallaTyp }, "XFKARKINKORG_HANDELSE_REGHNDID");

                entity.HasIndex(e => new { e.UpdDatum, e.InkorgId }, "XIE1arkInkorg");

                entity.HasIndex(e => new { e.MeddelandeDatum, e.MeddelandeKallaTyp }, "XIE2KARKINKORG");

                entity.Property(e => e.Amne)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fran)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Kopia)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Meddelande).HasColumnType("text");

                entity.Property(e => e.MeddelandeDatum).HasColumnType("datetime");

                entity.Property(e => e.MeddelandeKallaTyp).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.Till)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska).HasColumnType("text");

                entity.HasOne(d => d.RegHandelse)
                    .WithMany(p => p.ArkInkorgs)
                    .HasForeignKey(d => d.RegHandelseId)
                    .HasConstraintName("arkInkorg_Handelse_RegHandId");
            });

            modelBuilder.Entity<ArkInkorgBilaga>(entity =>
            {
                entity.HasKey(e => new { e.InkorgId, e.InkorgBilagaId })
                    .HasName("XPKarkInkorgBilaga");

                entity.ToTable("arkInkorgBilaga");

                entity.Property(e => e.InkorgBilagaId).ValueGeneratedOnAdd();

                entity.Property(e => e.DoclinkId).HasColumnName("DOCLINK_ID");

                entity.Property(e => e.OriginalContentType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalFilename)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StoredOriginal)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StoredPdf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StoredPDF");

                entity.HasOne(d => d.Doclink)
                    .WithMany(p => p.ArkInkorgBilagas)
                    .HasForeignKey(d => d.DoclinkId)
                    .HasConstraintName("arkInkorgBilaga_Gem_DMSDocLink");

                entity.HasOne(d => d.Inkorg)
                    .WithMany(p => p.ArkInkorgBilagas)
                    .HasForeignKey(d => d.InkorgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkInkorgBilaga_arkInkorg");
            });

            modelBuilder.Entity<ArkLoggAndra>(entity =>
            {
                entity.HasKey(e => e.LoggAndraId)
                    .HasName("XPKarkLoggAndra");

                entity.ToTable("arkLoggAndra");

                entity.HasIndex(e => new { e.TypId, e.TabellId }, "XIEARKLOGGANDRATYP");

                entity.Property(e => e.LoggTimestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkLoggAndras)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkLoggAndra_arkHandlaggare");

                entity.HasOne(d => d.LoggTyp)
                    .WithMany(p => p.ArkLoggAndras)
                    .HasForeignKey(d => d.LoggTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkLoggAndra_arkLoggTyp");

                entity.HasOne(d => d.Tabell)
                    .WithMany(p => p.ArkLoggAndras)
                    .HasForeignKey(d => d.TabellId)
                    .HasConstraintName("arkLoggAndra_arkTabell");
            });

            modelBuilder.Entity<ArkLoggAndraFalt>(entity =>
            {
                entity.HasKey(e => new { e.LoggAndraId, e.FaltNamn })
                    .HasName("XPKarkLoggAndraFalt")
                    .IsClustered(false);

                entity.ToTable("arkLoggAndraFalt");

                entity.HasIndex(e => e.VardeNkey, "XIEARKLOGGANDRAFALT_VARDE_NKey");

                entity.Property(e => e.FaltNamn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LoggAndraFaltId).ValueGeneratedOnAdd();

                entity.Property(e => e.Varde)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.VardeNkey)
                    .HasColumnName("VARDE_NKey")
                    .HasComputedColumnSql("(case [FALTNAMN] when 'ARKARENDE_HANDLID' then CONVERT([int],[VARDE]) when 'ArkArendeHandlId' then CONVERT([int],[VARDE])  end)", false);

                entity.HasOne(d => d.LoggAndra)
                    .WithMany(p => p.ArkLoggAndraFalts)
                    .HasForeignKey(d => d.LoggAndraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkLoggAndraFalt_arkLoggAndra");
            });

            modelBuilder.Entity<ArkLoggAndraFaltVkeyValue>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkLoggAndraFalt_VKeyValue");

                entity.Property(e => e.FaltNamn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KeyValue)
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkLoggLasa>(entity =>
            {
                entity.HasKey(e => e.LoggLasaId)
                    .HasName("XPKarkLoggLasa");

                entity.ToTable("arkLoggLasa");

                entity.Property(e => e.LoggTimestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkLoggLasas)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkLoggLasa_arkHandlaggare");

                entity.HasOne(d => d.Tabell)
                    .WithMany(p => p.ArkLoggLasas)
                    .HasForeignKey(d => d.TabellId)
                    .HasConstraintName("arkLoggLasa_arkTabell");
            });

            modelBuilder.Entity<ArkLoggTyp>(entity =>
            {
                entity.HasKey(e => e.LoggTypId)
                    .HasName("XPKarkLoggTyp");

                entity.ToTable("arkLoggTyp");

                entity.HasIndex(e => e.LoggTyp, "XAK1arkLoggTyp")
                    .IsUnique();

                entity.Property(e => e.LoggTypId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LoggTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkMilstolpe>(entity =>
            {
                entity.HasKey(e => e.MilstolpeId)
                    .HasName("XPKarkMilstolpe");

                entity.ToTable("arkMilstolpe");

                entity.Property(e => e.ArAktiv)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkMittByggeKod>(entity =>
            {
                entity.HasKey(e => new { e.KodTyp, e.MittByggeKod })
                    .HasName("XPKarkMittByggeKod");

                entity.ToTable("arkMittByggeKod");

                entity.HasIndex(e => e.ArendeKlassId, "XFKARKMITTBYGGEKOD_ARENDEKLASS");

                entity.HasIndex(e => e.KomTypId, "XFKARKMITTBYGGEKOD_GEMKOMMTYP");

                entity.HasIndex(e => e.HandlingTypId, "XFKARKMITTBYGGEKOD_HANDLINGTYP");

                entity.HasIndex(e => e.Rollid, "XFKARKMITTBYGGEKOD_PERSORGROLL");

                entity.HasIndex(e => e.PersOrgBehorighetNivaId, "XFKARKMITTBYGGEKOD_PORGBEHNIVA");

                entity.Property(e => e.KodTyp).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MittByggeKod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeKlass)
                    .WithMany(p => p.ArkMittByggeKods)
                    .HasForeignKey(d => d.ArendeKlassId)
                    .HasConstraintName("arkMittByggeKod_arkArendeKlass");

                entity.HasOne(d => d.HandlingTyp)
                    .WithMany(p => p.ArkMittByggeKods)
                    .HasForeignKey(d => d.HandlingTypId)
                    .HasConstraintName("arkMittByggeKod_arkHandlingTyp");

                entity.HasOne(d => d.KomTyp)
                    .WithMany(p => p.ArkMittByggeKods)
                    .HasForeignKey(d => d.KomTypId)
                    .HasConstraintName("arkMittByggeKod_gemKommTyp");

                entity.HasOne(d => d.PersOrgBehorighetNiva)
                    .WithMany(p => p.ArkMittByggeKods)
                    .HasForeignKey(d => d.PersOrgBehorighetNivaId)
                    .HasConstraintName("arkMittByggeKod_PersOrgBehNiva");

                entity.HasOne(d => d.Roll)
                    .WithMany(p => p.ArkMittByggeKods)
                    .HasForeignKey(d => d.Rollid)
                    .HasConstraintName("arkMittByggeKod_gemPersOrgRoll");
            });

            modelBuilder.Entity<ArkMittByggeKodSlagMappning>(entity =>
            {
                entity.HasKey(e => new { e.KodTypArendeTyp, e.MittByggeKodArendeTyp, e.KodTypAtgardsTyp, e.MittByggeKodAtgardsTyp })
                    .HasName("XPKarkMittByggeKodSlagMappning");

                entity.ToTable("arkMittByggeKodSlagMappning");

                entity.HasIndex(e => e.ArendeSlagId, "XFKARKMITTBYGGEMAPP_ARENDESLAG");

                entity.Property(e => e.KodTypArendeTyp).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MittByggeKodArendeTyp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KodTypAtgardsTyp).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MittByggeKodAtgardsTyp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArendeSlag)
                    .WithMany(p => p.ArkMittByggeKodSlagMappnings)
                    .HasForeignKey(d => d.ArendeSlagId)
                    .HasConstraintName("arkMittByggeMapp_arkArendeSlag");

                entity.HasOne(d => d.ArkMittByggeKod)
                    .WithMany(p => p.ArkMittByggeKodSlagMappningArkMittByggeKods)
                    .HasForeignKey(d => new { d.KodTypArendeTyp, d.MittByggeKodArendeTyp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkMittByggeMapp_MittBygge_Typ");

                entity.HasOne(d => d.ArkMittByggeKodNavigation)
                    .WithMany(p => p.ArkMittByggeKodSlagMappningArkMittByggeKodNavigations)
                    .HasForeignKey(d => new { d.KodTypAtgardsTyp, d.MittByggeKodAtgardsTyp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkMittByggeMapp_MittBygge_Atg");
            });

            modelBuilder.Entity<ArkNamnd>(entity =>
            {
                entity.HasKey(e => e.NamndId)
                    .HasName("XPKarkNamnd");

                entity.ToTable("arkNamnd");

                entity.HasIndex(e => e.Namnd, "XAK1arkNamnd")
                    .IsUnique();

                entity.HasIndex(e => e.DiarieId, "XFKARKNAMND_ARKDIARIE");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Namnd)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Diarie)
                    .WithMany(p => p.ArkNamnds)
                    .HasForeignKey(d => d.DiarieId)
                    .HasConstraintName("arkNamnd_arkDiarie");

                entity.HasMany(d => d.Enhets)
                    .WithMany(p => p.Namnds)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArkNamndEnhet",
                        l => l.HasOne<ArkEnhet>().WithMany().HasForeignKey("EnhetId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkNamnd_Enhet_arkEnhet"),
                        r => r.HasOne<ArkNamnd>().WithMany().HasForeignKey("NamndId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkNamnd_Enhet_arkNamnd"),
                        j =>
                        {
                            j.HasKey("NamndId", "EnhetId").HasName("XPKarkNamnd_Enhet");

                            j.ToTable("arkNamnd_Enhet");

                            j.HasIndex(new[] { "EnhetId", "NamndId" }, "XFKARKNAMND_ENHET_ARKENHET");
                        });
            });

            modelBuilder.Entity<ArkNotifiering>(entity =>
            {
                entity.HasKey(e => e.NotifieringId)
                    .HasName("XPKarkNotifiering");

                entity.ToTable("arkNotifiering");

                entity.HasIndex(e => new { e.ArendeId, e.BevakatUtskickOmgang }, "XFKARKNOTIFIERING_ARKARENDE");

                entity.HasIndex(e => e.HandelseId, "XFKARKNOTIFIERING_ARKHANDELSE");

                entity.HasIndex(e => e.InkorgId, "XFKARKNOTIFIERING_ARKINKORG");

                entity.HasIndex(e => new { e.HandlaggareId, e.KvitteradDatum }, "XFKARKNOTIFIERING_HANDLAGGARE");

                entity.HasIndex(e => new { e.KvitteradDatum, e.NotifieringDatum }, "XIE1arkNotifiering");

                entity.HasIndex(e => new { e.KvitteradDatum, e.NotifieringDatum, e.NotifieringKlassId }, "XIE2ARKNOTIFIERING");

                entity.Property(e => e.KvitteradDatum).HasColumnType("datetime");

                entity.Property(e => e.NotifieringDatum).HasColumnType("datetime");

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.Arende)
                    .WithMany(p => p.ArkNotifierings)
                    .HasForeignKey(d => d.ArendeId)
                    .HasConstraintName("arkNotifiering_arkArende");

                entity.HasOne(d => d.Handelse)
                    .WithMany(p => p.ArkNotifierings)
                    .HasForeignKey(d => d.HandelseId)
                    .HasConstraintName("arkNotifiering_arkHandelse");

                entity.HasOne(d => d.Handlaggare)
                    .WithMany(p => p.ArkNotifieringHandlaggares)
                    .HasForeignKey(d => d.HandlaggareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkNotifiering_arkHandlaggare");

                entity.HasOne(d => d.Inkorg)
                    .WithMany(p => p.ArkNotifierings)
                    .HasForeignKey(d => d.InkorgId)
                    .HasConstraintName("arkNotifiering_arkInkorg");

                entity.HasOne(d => d.KvitteradAvHandlaggare)
                    .WithMany(p => p.ArkNotifieringKvitteradAvHandlaggares)
                    .HasForeignKey(d => d.KvitteradAvHandlaggareId)
                    .HasConstraintName("arkNotifiering_Handlagg_KvitAv");

                entity.HasOne(d => d.NotifieringKlass)
                    .WithMany(p => p.ArkNotifierings)
                    .HasForeignKey(d => d.NotifieringKlassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkNotifiering_NotifieringKlas");

                entity.HasOne(d => d.RegSign)
                    .WithMany(p => p.ArkNotifieringRegSigns)
                    .HasForeignKey(d => d.RegSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkNotifiering_Handlagg_RegSig");
            });

            modelBuilder.Entity<ArkNotifieringKlass>(entity =>
            {
                entity.HasKey(e => e.NotifieringKlassId)
                    .HasName("XPKarkNotifieringKlass");

                entity.ToTable("arkNotifieringKlass");

                entity.Property(e => e.NotifieringKlassId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkProdukt>(entity =>
            {
                entity.HasKey(e => e.ProduktId)
                    .HasName("XPKarkProdukt");

                entity.ToTable("arkProdukt");

                entity.HasIndex(e => e.Produkt, "XAK1arkProdukt")
                    .IsUnique();

                entity.Property(e => e.ProduktId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Produkt)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkRutin>(entity =>
            {
                entity.HasKey(e => e.RutinId)
                    .HasName("XPKarkRutin");

                entity.ToTable("arkRutin");

                entity.HasIndex(e => e.Rutin, "XAK1arkRutin")
                    .IsUnique();

                entity.Property(e => e.RutinId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Rutin)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkRutinKod>(entity =>
            {
                entity.HasKey(e => e.RutinKodId)
                    .HasName("XPKarkRutinKod");

                entity.ToTable("arkRutinKod");

                entity.HasIndex(e => new { e.ArAktiv, e.RutinKodId }, "IE1ARKRUTINKOD");

                entity.HasIndex(e => new { e.RutinId, e.RutinKod }, "XAK1arkRutinKod")
                    .IsUnique();

                entity.HasIndex(e => new { e.RutinId, e.RutinKodId }, "XFKARKRUTINKOD_ARKRUTIN");

                entity.Property(e => e.RutinKodId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RutinKod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rutin)
                    .WithMany(p => p.ArkRutinKods)
                    .HasForeignKey(d => d.RutinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkRutinKod_arkRutin");
            });

            modelBuilder.Entity<ArkScbstatistik>(entity =>
            {
                entity.HasKey(e => e.ScbstatistikId)
                    .HasName("XPKarkSCBStatistik");

                entity.ToTable("arkSCBStatistik");

                entity.Property(e => e.ScbstatistikId).HasColumnName("SCBStatistikId");

                entity.Property(e => e.AktuellMd5checksum)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("AktuellMD5Checksum")
                    .IsFixedLength();

                entity.Property(e => e.AntalLghEfter).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.AntalLghFore).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.BeviljatDatum).HasColumnType("datetime");

                entity.Property(e => e.BostadsAreaEfter).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.BostadsAreaFore).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.BruttoArea).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.ByggnadTypSpec)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ByggnadsAr).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.ScbatgardTypId).HasColumnName("SCBAtgardTypId");

                entity.Property(e => e.ScbbyggnadTypId).HasColumnName("SCBByggnadTypId");

                entity.Property(e => e.ScblovTypId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("SCBLovTypId");

                entity.Property(e => e.ScbupplatelseFormId).HasColumnName("SCBUpplatelseFormId");

                entity.Property(e => e.SlutDatum).HasColumnType("datetime");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArkScbstatistikLgh>(entity =>
            {
                entity.HasKey(e => new { e.ScbstatistikId, e.ScbstatistikLghId })
                    .HasName("XPKarkSCBStatistikLgh");

                entity.ToTable("arkSCBStatistikLgh");

                entity.Property(e => e.ScbstatistikId).HasColumnName("SCBStatistikId");

                entity.Property(e => e.ScbstatistikLghId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SCBStatistikLghId");

                entity.Property(e => e.Antal).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.AntalRum).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.ScbkokTypId).HasColumnName("SCBKokTypId");

                entity.Property(e => e.ScblagenhetTypId).HasColumnName("SCBLagenhetTypId");

                entity.HasOne(d => d.Scbstatistik)
                    .WithMany(p => p.ArkScbstatistikLghs)
                    .HasForeignKey(d => d.ScbstatistikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkSCBStatistikLgh_SCBStat");
            });

            modelBuilder.Entity<ArkStandardSok>(entity =>
            {
                entity.HasKey(e => e.StandardSokId)
                    .HasName("XPKarkStandardSok");

                entity.ToTable("arkStandardSok");

                entity.HasIndex(e => e.Beskrivning, "XAK1arkStandardSok")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Urval)
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkTabell>(entity =>
            {
                entity.HasKey(e => e.TabellId)
                    .HasName("XPKarkTabell");

                entity.ToTable("arkTabell");

                entity.HasIndex(e => e.Tabell, "XAK1arkTabell")
                    .IsUnique();

                entity.HasIndex(e => e.TabellGruppId, "XFKARKTABELL_ARKTABELLGRUPP");

                entity.Property(e => e.TabellId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Kommentar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PkKolumn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tabell)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.TabellGrupp)
                    .WithMany(p => p.ArkTabells)
                    .HasForeignKey(d => d.TabellGruppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkTabell_arkTabellGrupp");
            });

            modelBuilder.Entity<ArkTabellGrupp>(entity =>
            {
                entity.HasKey(e => e.TabellGruppId)
                    .HasName("XPKarkTabellGrupp");

                entity.ToTable("arkTabellGrupp");

                entity.Property(e => e.TabellGruppId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TabellGrupp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.HvdTabell)
                    .WithMany(p => p.ArkTabellGrupps)
                    .HasForeignKey(d => d.HvdTabellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkTabGrp_arkTabell_HvdTab");
            });

            modelBuilder.Entity<ArkTidsVy>(entity =>
            {
                entity.HasKey(e => e.TidsVyId)
                    .HasName("XPKarkTidsVy");

                entity.ToTable("arkTidsVy");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArkTidsVyArendeTyp>(entity =>
            {
                entity.HasKey(e => new { e.TidsVyId, e.ArendeTypId })
                    .HasName("XPKarkTidsVy_ArendeTyp");

                entity.ToTable("arkTidsVy_ArendeTyp");

                entity.HasIndex(e => new { e.ArendeTypId, e.MilstolpeId }, "XFKARKTIDSVY_ARENDETYP_TYMILST");

                entity.HasOne(d => d.ArendeTyp)
                    .WithMany(p => p.ArkTidsVyArendeTyps)
                    .HasForeignKey(d => d.ArendeTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkTidsVy_ArendeTyp_ArendeTyp");

                entity.HasOne(d => d.TidsVy)
                    .WithMany(p => p.ArkTidsVyArendeTyps)
                    .HasForeignKey(d => d.TidsVyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkTidsVy_ArendeTyp_TidsVy");

                entity.HasOne(d => d.ArkArendeTypMilstolpe)
                    .WithMany(p => p.ArkTidsVyArendeTyps)
                    .HasForeignKey(d => new { d.ArendeTypId, d.MilstolpeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkTidsVy_ArendeTyp_AreTyMilst");
            });

            modelBuilder.Entity<ArkUnderrattelse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("arkUnderrattelse");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fnr)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("FNR");

                entity.Property(e => e.SenastSvarDatum).HasColumnType("datetime");

                entity.Property(e => e.Underrattelsetext)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ArkVersion>(entity =>
            {
                entity.HasKey(e => e.VersionsId)
                    .HasName("XPKarkVersion");

                entity.ToTable("arkVersion");

                entity.Property(e => e.VersionsId)
                    .ValueGeneratedNever()
                    .HasColumnName("versions_id");

                entity.Property(e => e.DatumTid)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("datum_tid");

                entity.Property(e => e.Namn)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("namn");

                entity.Property(e => e.Position)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Produkt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("produkt");

                entity.Property(e => e.Produktgrupp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("produktgrupp");

                entity.Property(e => e.Typ)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("typ");

                entity.Property(e => e.Version)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("version");

                entity.Property(e => e.VersionsDat)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("versions_dat");
            });

            modelBuilder.Entity<ArkarendeGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ARKARENDE_GEOFIR_V1");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatusid)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDESTATUSID");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetid).HasColumnName("ENHETID");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Hbeslutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HBESLUTDATUM");

                entity.Property(e => e.Hbeslutgiltigtilldatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HBESLUTGILTIGTILLDATUM");

                entity.Property(e => e.Hbeslutnr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("HBESLUTNR");

                entity.Property(e => e.Hbeslututfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HBESLUTUTFALL");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndid).HasColumnName("NAMNDID");

                entity.Property(e => e.Objekt)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OBJEKT");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<AvgAvgiftBelopp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgAvgiftBelopp");

                entity.Property(e => e.Belopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.FromDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<AvgAvgiftGrupp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgAvgiftGrupp");

                entity.Property(e => e.AvgiftGruppBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftGruppId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AvgAvgiftIntervall>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgAvgiftIntervall");

                entity.Property(e => e.FromDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<AvgAvgiftTyp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgAvgiftTyp");

                entity.Property(e => e.ArtikelBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ArtikelKod)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftKod)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftSpec)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftTypId).ValueGeneratedOnAdd();

                entity.Property(e => e.BasAr).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.IndexFaktor).HasColumnType("numeric(10, 1)");

                entity.Property(e => e.MomsKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OftabellId).HasColumnName("OFTabellId");

                entity.Property(e => e.PeriodLangd).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ViktFaktor).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<AvgBeloppTyp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgBeloppTyp");

                entity.Property(e => e.BeloppTypBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvgBeraknFormel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgBeraknFormel");

                entity.Property(e => e.BeraknFormel)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.FormelBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FormelId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AvgDelAvgift>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgDelAvgift");

                entity.Property(e => e.AvgiftBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftSpec)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrdning).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ViktFaktor).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<AvgGrundAvgift>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgGrundAvgift");

                entity.Property(e => e.GrundAvgiftBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.GrundAvgiftId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AvgGrundBelopp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgGrundBelopp");

                entity.Property(e => e.Belopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.FromDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<AvgIndex>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgIndex");

                entity.Property(e => e.IndexBen)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IndexId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AvgIndexBerakn>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgIndexBerakn");

                entity.Property(e => e.AndringsManad).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.IndexBeraknBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IndexBeraknId).ValueGeneratedOnAdd();

                entity.Property(e => e.IndexManad).HasColumnType("numeric(2, 0)");
            });

            modelBuilder.Entity<AvgIndexSerie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgIndexSerie");

                entity.Property(e => e.IndexVarde).HasColumnType("numeric(10, 1)");

                entity.Property(e => e.Period).HasColumnType("numeric(6, 0)");
            });

            modelBuilder.Entity<AvgIntervallBelopp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgIntervallBelopp");

                entity.Property(e => e.Belopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.FromDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<AvgKomKontermall>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgKomKontermall");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel1)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel2)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel3)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel4)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel5)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel6)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel7)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvgKontermall>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgKontermall");

                entity.Property(e => e.KonterMallBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.KonterMallId).ValueGeneratedOnAdd();

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvgKontoDef>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgKontoDef");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDelLen).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.KontoDelNr).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LedText)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvgOfintervall>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgOFIntervall");

                entity.Property(e => e.ObjektFaktor).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.OftabellId).HasColumnName("OFTabellId");
            });

            modelBuilder.Entity<AvgOftabell>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avgOFTabell");

                entity.Property(e => e.OftabellBen)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OFTabellBen");

                entity.Property(e => e.OftabellId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OFTabellId");
            });

            modelBuilder.Entity<BabArende>(entity =>
            {
                entity.HasKey(e => e.ArendeId)
                    .HasName("XPKbabArende");

                entity.ToTable("babArende", "bab");

                entity.HasIndex(e => e.UpplatelseFormId, "XFKbabHusTyp_babArende");

                entity.HasIndex(e => e.HusTypId, "XFKbabUpplatelseForm_babArende");

                entity.Property(e => e.ArendeId).ValueGeneratedNever();

                entity.Property(e => e.UtbetTillKonto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Arende)
                    .WithOne(p => p.BabArende)
                    .HasForeignKey<BabArende>(d => d.ArendeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArende_babArende");

                entity.HasOne(d => d.HusTyp)
                    .WithMany(p => p.BabArendes)
                    .HasForeignKey(d => d.HusTypId)
                    .HasConstraintName("babHusTyp_babArende");

                entity.HasOne(d => d.UpplatelseForm)
                    .WithMany(p => p.BabArendes)
                    .HasForeignKey(d => d.UpplatelseFormId)
                    .HasConstraintName("babUpplatelseForm_babArende");

                entity.HasOne(d => d.UtbetTillKontoTyp)
                    .WithMany(p => p.BabArendes)
                    .HasForeignKey(d => d.UtbetTillKontoTypId)
                    .HasConstraintName("babKontoTyp_babArende");
            });

            modelBuilder.Entity<BabArtikel>(entity =>
            {
                entity.HasKey(e => e.ArtikelId)
                    .HasName("XPKbabArtikel");

                entity.ToTable("babArtikel", "bab");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BabArtikelLokation>(entity =>
            {
                entity.HasKey(e => e.ArtikelLokationId)
                    .HasName("XPKbabArtikelLokation");

                entity.ToTable("babArtikelLokation", "bab");

                entity.HasIndex(e => e.ArtikelId, "XFKbabArtikelLokation_babArtikel");

                entity.HasIndex(e => e.LokationId, "XFKbabArtikelLokation_babLokation");

                entity.HasIndex(e => e.IndividInventarieId, "XFKbabArtikelLokation_gemIndividInventarie");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.BabArtikelLokations)
                    .HasForeignKey(d => d.ArtikelId)
                    .HasConstraintName("babArtikel_babArtikelLokation");

                entity.HasOne(d => d.IndividInventarie)
                    .WithMany(p => p.BabArtikelLokations)
                    .HasForeignKey(d => d.IndividInventarieId)
                    .HasConstraintName("gemIndividInventarie_babArtikelLokation");

                entity.HasOne(d => d.Lokation)
                    .WithMany(p => p.BabArtikelLokations)
                    .HasForeignKey(d => d.LokationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babLokation_babArtikelLokation");
            });

            modelBuilder.Entity<BabAtgard>(entity =>
            {
                entity.HasKey(e => new { e.ArendeId, e.AtgardId })
                    .HasName("XPKbabAtgard");

                entity.ToTable("babAtgard", "bab");

                entity.HasIndex(e => e.BeslutId, "XFKbabAtgard_arkHandelseBeslut");

                entity.HasIndex(e => e.ArtikelLokationId, "XFKbabAtgard_babBostadsAnpassning");

                entity.Property(e => e.BegartBelopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.BeslutatBelopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Placering)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UtbetaltBelopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.UtbetaltDatum).HasColumnType("datetime");

                entity.HasOne(d => d.ArtikelLokation)
                    .WithMany(p => p.BabAtgards)
                    .HasForeignKey(d => d.ArtikelLokationId)
                    .HasConstraintName("babBostadsAnpassning_babAtgard");

                entity.HasOne(d => d.Beslut)
                    .WithMany(p => p.BabAtgards)
                    .HasForeignKey(d => d.BeslutId)
                    .HasConstraintName("arkHandelseBeslut_babAtgard");

                entity.HasOne(d => d.A)
                    .WithOne(p => p.BabAtgard)
                    .HasForeignKey<BabAtgard>(d => new { d.ArendeId, d.AtgardId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeAtgard_babAtgard");
            });

            modelBuilder.Entity<BabBostadsAnpassning>(entity =>
            {
                entity.HasKey(e => e.ArtikelLokationId)
                    .HasName("XPKbabBostadsAnpassning");

                entity.ToTable("babBostadsAnpassning", "bab");

                entity.Property(e => e.ArtikelLokationId).ValueGeneratedNever();

                entity.Property(e => e.AterstalldDatum).HasColumnType("datetime");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.HasOne(d => d.ArtikelLokation)
                    .WithOne(p => p.BabBostadsAnpassning)
                    .HasForeignKey<BabBostadsAnpassning>(d => d.ArtikelLokationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babArtikelLokation_babBostadsAnpassning");
            });

            modelBuilder.Entity<BabBrukare>(entity =>
            {
                entity.HasKey(e => new { e.PersOrgId, e.ArtikelLokationId })
                    .HasName("XPKbabBrukare");

                entity.ToTable("babBrukare", "bab");

                entity.HasIndex(e => e.ArtikelLokationId, "XFKbabBrukare_babBostadsAnpassning");

                entity.HasIndex(e => e.PersOrgId, "XFKbabBrukare_gemPersOrg");

                entity.Property(e => e.AvfordDatum).HasColumnType("datetime");

                entity.Property(e => e.StartDatum).HasColumnType("datetime");

                entity.HasOne(d => d.ArtikelLokation)
                    .WithMany(p => p.BabBrukares)
                    .HasForeignKey(d => d.ArtikelLokationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babBostadsAnpassning_babBrukare");

                entity.HasOne(d => d.PersOrg)
                    .WithMany(p => p.BabBrukares)
                    .HasForeignKey(d => d.PersOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrg_babBrukare");
            });

            modelBuilder.Entity<BabHusTyp>(entity =>
            {
                entity.HasKey(e => e.HusTypId)
                    .HasName("XPKbabHusTyp");

                entity.ToTable("babHusTyp", "bab");

                entity.Property(e => e.HusTypId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BabKontoTyp>(entity =>
            {
                entity.HasKey(e => e.KontoTypId)
                    .HasName("XPKbabKontoTyp");

                entity.ToTable("babKontoTyp", "bab");

                entity.Property(e => e.KontoTypId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BabLager>(entity =>
            {
                entity.HasKey(e => e.LagerId)
                    .HasName("XPKbabLager");

                entity.ToTable("babLager", "bab");

                entity.HasIndex(e => e.LokationId, "XFKbabLager_babLokation");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lokation)
                    .WithMany(p => p.BabLagers)
                    .HasForeignKey(d => d.LokationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babLokation_babLager");
            });

            modelBuilder.Entity<BabLagringsPlat>(entity =>
            {
                entity.HasKey(e => e.ArtikelLokationId)
                    .HasName("XPKbabLagringsPlats");

                entity.ToTable("babLagringsPlats", "bab");

                entity.HasIndex(e => e.LagerId, "XFKbabLagringsPlats_babLager");

                entity.Property(e => e.ArtikelLokationId).ValueGeneratedNever();

                entity.HasOne(d => d.ArtikelLokation)
                    .WithOne(p => p.BabLagringsPlat)
                    .HasForeignKey<BabLagringsPlat>(d => d.ArtikelLokationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babArtikelLokation_babLagringsPlats");

                entity.HasOne(d => d.Lager)
                    .WithMany(p => p.BabLagringsPlats)
                    .HasForeignKey(d => d.LagerId)
                    .HasConstraintName("babLager_babLagringsPlats");
            });

            modelBuilder.Entity<BabLokation>(entity =>
            {
                entity.HasKey(e => e.LokationId)
                    .HasName("XPKbabLokation");

                entity.ToTable("babLokation", "bab");

                entity.HasIndex(e => e.BelAdressObjektId, "XFKbabLokation_BelAdress_gemObjekt");

                entity.HasIndex(e => e.FastighetObjektId, "XFKbabLokation_Fastighet_gemObjekt");

                entity.HasIndex(e => e.LghObjektId, "XFKbabLokation_Lgh_gemObjekt");

                entity.HasOne(d => d.BelAdressObjekt)
                    .WithMany(p => p.BabLokationBelAdressObjekts)
                    .HasForeignKey(d => d.BelAdressObjektId)
                    .HasConstraintName("gemObjekt_BelAdress_babLokation");

                entity.HasOne(d => d.FastighetObjekt)
                    .WithMany(p => p.BabLokationFastighetObjekts)
                    .HasForeignKey(d => d.FastighetObjektId)
                    .HasConstraintName("gemObjekt_Fastighet_babLokation");

                entity.HasOne(d => d.LghObjekt)
                    .WithMany(p => p.BabLokationLghObjekts)
                    .HasForeignKey(d => d.LghObjektId)
                    .HasConstraintName("gemObjekt_Lgh_babLokation");
            });

            modelBuilder.Entity<BabLokationOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("babLokation_Old", "bab");
            });

            modelBuilder.Entity<BabMappadArtikel>(entity =>
            {
                entity.HasKey(e => e.MappadArtikelId)
                    .HasName("XPKbabMappadArtikel");

                entity.ToTable("babMappadArtikel", "bab");

                entity.HasIndex(e => e.ArendeKlassId, "XFKbabMappadArtikel_arkArendeKlass");

                entity.HasIndex(e => e.ArendeSlagId, "XFKbabMappadArtikel_arkArendeSlag");

                entity.HasIndex(e => e.ArtikelId, "XFKbabMappadArtikel_babArtikel");

                entity.HasOne(d => d.ArendeKlass)
                    .WithMany(p => p.BabMappadArtikels)
                    .HasForeignKey(d => d.ArendeKlassId)
                    .HasConstraintName("arkArendeKlass_babMappadArtikel");

                entity.HasOne(d => d.ArendeSlag)
                    .WithMany(p => p.BabMappadArtikels)
                    .HasForeignKey(d => d.ArendeSlagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("arkArendeSlag_babMappadArtikel");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.BabMappadArtikels)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babArtikel_babMappadArtikel");
            });

            modelBuilder.Entity<BabUpplatelseForm>(entity =>
            {
                entity.HasKey(e => e.UpplatelseFormId)
                    .HasName("XPKbabUpplatelseForm");

                entity.ToTable("babUpplatelseForm", "bab");

                entity.Property(e => e.UpplatelseFormId).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BabVersion>(entity =>
            {
                entity.HasKey(e => e.VersionsId)
                    .HasName("XPKbabVersion");

                entity.ToTable("babVersion", "bab");

                entity.Property(e => e.VersionsId)
                    .ValueGeneratedNever()
                    .HasColumnName("versions_id");

                entity.Property(e => e.DatumTid)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("datum_tid");

                entity.Property(e => e.Namn)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("namn");

                entity.Property(e => e.Position)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Produkt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("produkt");

                entity.Property(e => e.Produktgrupp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("produktgrupp");

                entity.Property(e => e.Typ)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("typ");

                entity.Property(e => e.Version)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("version");

                entity.Property(e => e.VersionsDat)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("versions_dat");
            });

            modelBuilder.Entity<DdsDocumentfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DDS_DOCUMENTFILE");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.Documentfile)
                    .HasColumnType("image")
                    .HasColumnName("documentfile");

                entity.Property(e => e.Fileextention)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fileextention");

                entity.Property(e => e.Filesize).HasColumnName("filesize");

                entity.Property(e => e.VersionId).HasColumnName("version_id");
            });

            modelBuilder.Entity<DdsDocumentfileSmstest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DDS_DOCUMENTFILE_SMSTEST");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.Documentfile)
                    .HasColumnType("image")
                    .HasColumnName("documentfile");

                entity.Property(e => e.Fileextention)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fileextention");

                entity.Property(e => e.Filesize).HasColumnName("filesize");

                entity.Property(e => e.VersionId).HasColumnName("version_id");
            });

            modelBuilder.Entity<DdsProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DDS_PROFILE");

                entity.Property(e => e.CheckoutDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("checkout_date")
                    .IsFixedLength();

                entity.Property(e => e.CheckoutDrive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("checkout_drive")
                    .IsFixedLength();

                entity.Property(e => e.CheckoutFilename)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("checkout_filename");

                entity.Property(e => e.CheckoutHost)
                    .HasMaxLength(63)
                    .IsUnicode(false)
                    .HasColumnName("checkout_host");

                entity.Property(e => e.CheckoutTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("checkout_time")
                    .IsFixedLength();

                entity.Property(e => e.CheckoutUserId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("checkout_user_id");

                entity.Property(e => e.CheckoutVersionId).HasColumnName("checkout_version_id");

                entity.Property(e => e.CreationDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("creation_date")
                    .IsFixedLength();

                entity.Property(e => e.CreationTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("creation_time")
                    .IsFixedLength();

                entity.Property(e => e.CreatorId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("creator_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.DocTypeId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("doc_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RetentionTime).HasColumnName("retention_time");

                entity.Property(e => e.StorageTypeId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("storage_type_id");
            });

            modelBuilder.Entity<DdsVersion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DDS_VERSION");

                entity.Property(e => e.BaseVersionId).HasColumnName("base_version_id");

                entity.Property(e => e.CreationDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("creation_date")
                    .IsFixedLength();

                entity.Property(e => e.CreationTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("creation_time")
                    .IsFixedLength();

                entity.Property(e => e.CreatorId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("creator_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.Documentonline)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("documentonline")
                    .IsFixedLength();

                entity.Property(e => e.Fileextention)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fileextention");

                entity.Property(e => e.Filesize).HasColumnName("filesize");

                entity.Property(e => e.IsArchiveFormat).HasColumnName("is_archive_format");

                entity.Property(e => e.IsSigned).HasColumnName("is_signed");

                entity.Property(e => e.OfflineDate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("offline_date")
                    .IsFixedLength();

                entity.Property(e => e.StampConfig)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("stamp_config");

                entity.Property(e => e.StampText)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("stamp_text");

                entity.Property(e => e.StampType).HasColumnName("stamp_type");

                entity.Property(e => e.VersionId).HasColumnName("version_id");
            });

            modelBuilder.Entity<DebAvgift>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debAvgift");

                entity.Property(e => e.Antal).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Apris)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("APris");

                entity.Property(e => e.ArtikelBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ArtikelKod)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftKod)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftSpec)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.BeloppNetto).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.DebPeriodFrom).HasColumnType("numeric(6, 0)");

                entity.Property(e => e.DebPeriodTom).HasColumnType("numeric(6, 0)");

                entity.Property(e => e.KontoDel1)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel2)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel3)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel4)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel5)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel6)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KontoDel7)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MomsKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektFaktor).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ViktFaktor).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<DebAvgiftSpec>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debAvgiftSpec");

                entity.Property(e => e.AvgiftBen)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AvgiftSpec)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BeloppNetto).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ViktFaktor).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<DebAvisering>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debAvisering");

                entity.Property(e => e.BeloppNetto).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.BeloppNettoExt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.BeloppNettoInt).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.FilNamn)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.SlutTid)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartTid)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebDebiterSpec>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debDebiterSpec");

                entity.Property(e => e.Position)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpecText)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebDebitering>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debDebitering");

                entity.Property(e => e.AviPeriod).HasColumnType("numeric(6, 0)");

                entity.Property(e => e.DebId).ValueGeneratedOnAdd();

                entity.Property(e => e.GrundBelopp).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektIdent)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebEkonomiSystem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debEkonomiSystem");

                entity.Property(e => e.EkSystemBen)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebFaktura>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debFaktura");

                entity.Property(e => e.BeloppNetto).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.BestallarIdent)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BetalDatum).HasColumnType("datetime");

                entity.Property(e => e.CoAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.FaktRef)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FakturaDatum).HasColumnType("datetime");

                entity.Property(e => e.FakturaId).ValueGeneratedOnAdd();

                entity.Property(e => e.FakturaIdent)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.FakturaText)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ForfallDatum).HasColumnType("datetime");

                entity.Property(e => e.GatuAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.KundNamn)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.KundNr)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.KundRef)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.KundRefBestallarIdent)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Land)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MakulerDatum).HasColumnType("datetime");

                entity.Property(e => e.Moms).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Motpart)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.OrderIdent)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PersOrgNr)
                    .HasMaxLength(33)
                    .IsUnicode(false);

                entity.Property(e => e.PostNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.PostOrt)
                    .HasMaxLength(27)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebFakturaRad>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debFakturaRad");

                entity.Property(e => e.BeloppNetto).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Moms).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<DebMom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debMoms");

                entity.Property(e => e.MomsKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MomsProc).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.MomsText)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebMomsKod>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debMomsKod");

                entity.Property(e => e.ExtMomsKod)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MomsKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MomsKonto)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebSystem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debSystem");

                entity.Property(e => e.SystemBen)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebSystemParam>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("debSystemParam");

                entity.Property(e => e.AvsRutinKod)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BearbetnTyp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BestallKod)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FaktGrp)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FilPrefix)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FtgId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.KundNr)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.RutinKod)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DUAL");

                entity.Property(e => e.Dummy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DUMMY");
            });

            modelBuilder.Entity<FastighetGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FASTIGHET_GEOFIR_V1");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<FirGeomSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FIR_GEOM_SETTINGS");

                entity.Property(e => e.Beskr)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BESKR");

                entity.Property(e => e.InvertXy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INVERT_XY")
                    .IsFixedLength();

                entity.Property(e => e.KsysKod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("KSYS_KOD")
                    .IsFixedLength();

                entity.Property(e => e.Srid).HasColumnName("SRID");

                entity.Property(e => e.TableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_NAME");
            });

            modelBuilder.Entity<GdRbArendeGeofirPunktV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_ARENDE_GEOFIR_PUNKT_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbArendeGeofirYtaV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_ARENDE_GEOFIR_YTA_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbFriHandelsGeofirPunktV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_FRI_HANDELS_GEOFIR_PUNKT_V1");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handelsedatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HANDELSEDATUM");

                entity.Property(e => e.Handelseid).HasColumnName("HANDELSEID");

                entity.Property(e => e.Handelserubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSERUBRIK");

                entity.Property(e => e.Handelseslag)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAG");

                entity.Property(e => e.Handelseslagid).HasColumnName("HANDELSESLAGID");

                entity.Property(e => e.Handelseslagkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAGKOD");

                entity.Property(e => e.Handelseslagrutinid).HasColumnName("HANDELSESLAGRUTINID");

                entity.Property(e => e.Handelseslagrutinkodid).HasColumnName("HANDELSESLAGRUTINKODID");

                entity.Property(e => e.Handelsetyp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYP");

                entity.Property(e => e.Handelsetypid).HasColumnName("HANDELSETYPID");

                entity.Property(e => e.Handelsetypkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYPKOD");

                entity.Property(e => e.Handelsetyprutinid).HasColumnName("HANDELSETYPRUTINID");

                entity.Property(e => e.Handelsetyprutinkodid).HasColumnName("HANDELSETYPRUTINKODID");

                entity.Property(e => e.Handelseutfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALL");

                entity.Property(e => e.Handelseutfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALLKOD");

                entity.Property(e => e.Handelseutfallsid).HasColumnName("HANDELSEUTFALLSID");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbFriHandelsGeofirYtaV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_FRI_HANDELS_GEOFIR_YTA_V1");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handelsedatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HANDELSEDATUM");

                entity.Property(e => e.Handelseid).HasColumnName("HANDELSEID");

                entity.Property(e => e.Handelserubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSERUBRIK");

                entity.Property(e => e.Handelseslag)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAG");

                entity.Property(e => e.Handelseslagid).HasColumnName("HANDELSESLAGID");

                entity.Property(e => e.Handelseslagkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAGKOD");

                entity.Property(e => e.Handelseslagrutinid).HasColumnName("HANDELSESLAGRUTINID");

                entity.Property(e => e.Handelseslagrutinkodid).HasColumnName("HANDELSESLAGRUTINKODID");

                entity.Property(e => e.Handelsetyp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYP");

                entity.Property(e => e.Handelsetypid).HasColumnName("HANDELSETYPID");

                entity.Property(e => e.Handelsetypkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYPKOD");

                entity.Property(e => e.Handelsetyprutinid).HasColumnName("HANDELSETYPRUTINID");

                entity.Property(e => e.Handelsetyprutinkodid).HasColumnName("HANDELSETYPRUTINKODID");

                entity.Property(e => e.Handelseutfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALL");

                entity.Property(e => e.Handelseutfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALLKOD");

                entity.Property(e => e.Handelseutfallsid).HasColumnName("HANDELSEUTFALLSID");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbHandelseGeofirPunktV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_HANDELSE_GEOFIR_PUNKT_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handelsedatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HANDELSEDATUM");

                entity.Property(e => e.Handelseid).HasColumnName("HANDELSEID");

                entity.Property(e => e.Handelserubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSERUBRIK");

                entity.Property(e => e.Handelseslag)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAG");

                entity.Property(e => e.Handelseslagid).HasColumnName("HANDELSESLAGID");

                entity.Property(e => e.Handelseslagkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAGKOD");

                entity.Property(e => e.Handelseslagrutinid).HasColumnName("HANDELSESLAGRUTINID");

                entity.Property(e => e.Handelseslagrutinkodid).HasColumnName("HANDELSESLAGRUTINKODID");

                entity.Property(e => e.Handelsetyp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYP");

                entity.Property(e => e.Handelsetypid).HasColumnName("HANDELSETYPID");

                entity.Property(e => e.Handelsetypkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYPKOD");

                entity.Property(e => e.Handelsetyprutinid).HasColumnName("HANDELSETYPRUTINID");

                entity.Property(e => e.Handelsetyprutinkodid).HasColumnName("HANDELSETYPRUTINKODID");

                entity.Property(e => e.Handelseutfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALL");

                entity.Property(e => e.Handelseutfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALLKOD");

                entity.Property(e => e.Handelseutfallsid).HasColumnName("HANDELSEUTFALLSID");

                entity.Property(e => e.HradId).HasColumnName("HRAD_ID");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbHandelseGeofirYtaV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_HANDELSE_GEOFIR_YTA_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handelsedatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HANDELSEDATUM");

                entity.Property(e => e.Handelseid).HasColumnName("HANDELSEID");

                entity.Property(e => e.Handelserubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSERUBRIK");

                entity.Property(e => e.Handelseslag)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAG");

                entity.Property(e => e.Handelseslagid).HasColumnName("HANDELSESLAGID");

                entity.Property(e => e.Handelseslagkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAGKOD");

                entity.Property(e => e.Handelseslagrutinid).HasColumnName("HANDELSESLAGRUTINID");

                entity.Property(e => e.Handelseslagrutinkodid).HasColumnName("HANDELSESLAGRUTINKODID");

                entity.Property(e => e.Handelsetyp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYP");

                entity.Property(e => e.Handelsetypid).HasColumnName("HANDELSETYPID");

                entity.Property(e => e.Handelsetypkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYPKOD");

                entity.Property(e => e.Handelsetyprutinid).HasColumnName("HANDELSETYPRUTINID");

                entity.Property(e => e.Handelsetyprutinkodid).HasColumnName("HANDELSETYPRUTINKODID");

                entity.Property(e => e.Handelseutfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALL");

                entity.Property(e => e.Handelseutfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALLKOD");

                entity.Property(e => e.Handelseutfallsid).HasColumnName("HANDELSEUTFALLSID");

                entity.Property(e => e.HradId).HasColumnName("HRAD_ID");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbHuvudbeslutGeofirPunktV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_HUVUDBESLUT_GEOFIR_PUNKT_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Beslutarmindreavvikelse).HasColumnName("BESLUTARMINDREAVVIKELSE");

                entity.Property(e => e.Beslutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("BESLUTDATUM");

                entity.Property(e => e.Beslutgiltigtilldatum)
                    .HasColumnType("datetime")
                    .HasColumnName("BESLUTGILTIGTILLDATUM");

                entity.Property(e => e.Beslutinstans)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTINSTANS");

                entity.Property(e => e.Beslutinstansardelegat).HasColumnName("BESLUTINSTANSARDELEGAT");

                entity.Property(e => e.Beslutinstanskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTINSTANSKOD");

                entity.Property(e => e.Beslutnr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTNR");

                entity.Property(e => e.Beslututfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTUTFALL");

                entity.Property(e => e.Beslututfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTUTFALLKOD");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbHuvudbeslutGeofirYtaV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_HUVUDBESLUT_GEOFIR_YTA_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Beslutarmindreavvikelse).HasColumnName("BESLUTARMINDREAVVIKELSE");

                entity.Property(e => e.Beslutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("BESLUTDATUM");

                entity.Property(e => e.Beslutgiltigtilldatum)
                    .HasColumnType("datetime")
                    .HasColumnName("BESLUTGILTIGTILLDATUM");

                entity.Property(e => e.Beslutinstans)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTINSTANS");

                entity.Property(e => e.Beslutinstansardelegat).HasColumnName("BESLUTINSTANSARDELEGAT");

                entity.Property(e => e.Beslutinstanskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTINSTANSKOD");

                entity.Property(e => e.Beslutnr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTNR");

                entity.Property(e => e.Beslututfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTUTFALL");

                entity.Property(e => e.Beslututfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTUTFALLKOD");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbHvdhandlaggGeofirPunktV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_HVDHANDLAGG_GEOFIR_PUNKT_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handlaggarearaktiv).HasColumnName("HANDLAGGAREARAKTIV");

                entity.Property(e => e.Handlaggareid).HasColumnName("HANDLAGGAREID");

                entity.Property(e => e.Handlaggarenamn)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("HANDLAGGARENAMN");

                entity.Property(e => e.Handlaggaresignatur)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("HANDLAGGARESIGNATUR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbHvdhandlaggGeofirYtaV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_HVDHANDLAGG_GEOFIR_YTA_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handlaggarearaktiv).HasColumnName("HANDLAGGAREARAKTIV");

                entity.Property(e => e.Handlaggareid).HasColumnName("HANDLAGGAREID");

                entity.Property(e => e.Handlaggarenamn)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("HANDLAGGARENAMN");

                entity.Property(e => e.Handlaggaresignatur)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("HANDLAGGARESIGNATUR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbUHvdbeslGeofirPunktV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_U_HVDBESL_GEOFIR_PUNKT_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GdRbUHvdbeslGeofirYtaV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GD_RB_U_HVDBESL_GEOFIR_YTA_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<GemConfigMetaDatum>(entity =>
            {
                entity.HasKey(e => e.ConfigMetaDataId)
                    .HasName("XPKgemConfigMetaData");

                entity.ToTable("gemConfigMetaData");

                entity.HasIndex(e => e.ConfigSectionId, "XFKGEMCONFMETDAT_CONFIGSECTION");

                entity.HasIndex(e => new { e.MetaDataKey, e.ConfigSectionId, e.ConfigMetaDataId }, "XIE1GEMCONFIGMETADATA");

                entity.Property(e => e.ConfigMetaDataId).HasColumnName("ConfigMetaDataID");

                entity.Property(e => e.ConfigSectionId).HasColumnName("ConfigSectionID");

                entity.Property(e => e.MetaDataDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDataFormat)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDataKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConfigSection)
                    .WithMany(p => p.GemConfigMetaData)
                    .HasForeignKey(d => d.ConfigSectionId)
                    .HasConstraintName("gemConfMetDat_gemConfigSection");
            });

            modelBuilder.Entity<GemConfigProduct>(entity =>
            {
                entity.HasKey(e => e.ConfigProductId)
                    .HasName("XPKgemConfigProduct");

                entity.ToTable("gemConfigProduct");

                entity.HasIndex(e => new { e.ProductName, e.ConfigProductId }, "XIE1GEMCONFIGPRODUCT");

                entity.Property(e => e.ConfigProductId).HasColumnName("ConfigProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemConfigSection>(entity =>
            {
                entity.HasKey(e => e.ConfigSectionId)
                    .HasName("XPKgemConfigSection");

                entity.ToTable("gemConfigSection");

                entity.HasIndex(e => new { e.ConfigProductId, e.SectionName, e.ConfigSectionId }, "XFKGEMCONFIGSECTION_CONFIGPROD");

                entity.Property(e => e.ConfigSectionId).HasColumnName("ConfigSectionID");

                entity.Property(e => e.ConfigProductId).HasColumnName("ConfigProductID");

                entity.Property(e => e.SectionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConfigProduct)
                    .WithMany(p => p.GemConfigSections)
                    .HasForeignKey(d => d.ConfigProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemConfigSection_gemConfigProd");
            });

            modelBuilder.Entity<GemConfigSectionMetaDatum>(entity =>
            {
                entity.HasKey(e => e.ConfigSectionMetaDataId)
                    .HasName("XPKgemConfigSectionMetaData");

                entity.ToTable("gemConfigSectionMetaData");

                entity.HasIndex(e => new { e.ConfigSectionId, e.ConfigMetaDataId, e.ConfigSectionMetaDataId }, "XIE1GEMCONFIGSECTIONMETADATA");

                entity.Property(e => e.ConfigSectionMetaDataId).HasColumnName("ConfigSectionMetaDataID");

                entity.Property(e => e.ConfigDefaultValue)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigMetaDataId).HasColumnName("ConfigMetaDataID");

                entity.Property(e => e.ConfigSectionId).HasColumnName("ConfigSectionID");

                entity.Property(e => e.Version)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConfigMetaData)
                    .WithMany(p => p.GemConfigSectionMetaData)
                    .HasForeignKey(d => d.ConfigMetaDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemConfSectMetDat_ConfigMetDat");

                entity.HasOne(d => d.ConfigSection)
                    .WithMany(p => p.GemConfigSectionMetaData)
                    .HasForeignKey(d => d.ConfigSectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemConfSectMetData_gemConfSect");
            });

            modelBuilder.Entity<GemConfigUser>(entity =>
            {
                entity.HasKey(e => e.ConfigUserId)
                    .HasName("XPKgemConfigUser");

                entity.ToTable("gemConfigUser");

                entity.HasIndex(e => new { e.UserName, e.ConfigUserId }, "XIE1GEMCONFIGUSER");

                entity.Property(e => e.ConfigUserId).HasColumnName("ConfigUserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemConfigValue>(entity =>
            {
                entity.HasKey(e => e.ConfigValueId)
                    .HasName("XPKgemConfigValue");

                entity.ToTable("gemConfigValue");

                entity.HasIndex(e => new { e.ConfigSectionMetaDataId, e.ConfigUserId }, "XIE1GEMCONFIGVALUE");

                entity.Property(e => e.ConfigValueId).HasColumnName("ConfigValueID");

                entity.Property(e => e.Changed).HasColumnType("datetime");

                entity.Property(e => e.ConfigSectionMetaDataId).HasColumnName("ConfigSectionMetaDataID");

                entity.Property(e => e.ConfigUserId).HasColumnName("ConfigUserID");

                entity.Property(e => e.ConfigValue)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.HasOne(d => d.ConfigSectionMetaData)
                    .WithMany(p => p.GemConfigValues)
                    .HasForeignKey(d => d.ConfigSectionMetaDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemConValue_gemConSectMetDat");

                entity.HasOne(d => d.ConfigUser)
                    .WithMany(p => p.GemConfigValues)
                    .HasForeignKey(d => d.ConfigUserId)
                    .HasConstraintName("gemConfigValue_gemConfigUser");
            });

            modelBuilder.Entity<GemCounter>(entity =>
            {
                entity.HasKey(e => new { e.Module, e.Counter })
                    .HasName("PK__GEM_COUN__8019E98C6E0D6785");

                entity.ToTable("GEM_COUNTER");

                entity.Property(e => e.Module)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MODULE");

                entity.Property(e => e.Counter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COUNTER");

                entity.Property(e => e.Counterlength).HasColumnName("COUNTERLENGTH");

                entity.Property(e => e.Counterprefix)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("COUNTERPREFIX");

                entity.Property(e => e.Countersuffix)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("COUNTERSUFFIX");

                entity.Property(e => e.ValOfCount).HasColumnName("VAL_OF_COUNT");
            });

            modelBuilder.Entity<GemDmsdoclink>(entity =>
            {
                entity.HasKey(e => e.DoclinkId)
                    .HasName("XPKgem_DMSDocLink");

                entity.ToTable("GEM_DMSDOCLINK");

                entity.HasIndex(e => e.DmsdocId, "XAK1gem_dmsdoclink")
                    .IsUnique();

                entity.HasIndex(e => e.HandelseIdSplittbar, "XFKgemDMSDocLink_HandelseIdSpl");

                entity.Property(e => e.DoclinkId).HasColumnName("doclink_id");

                entity.Property(e => e.DmsdocId)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("dmsdoc_id");

                entity.Property(e => e.Filetype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("filetype");

                entity.Property(e => e.Usecount).HasColumnName("usecount");

                entity.HasOne(d => d.HandelseIdSplittbarNavigation)
                    .WithMany(p => p.GemDmsdoclinks)
                    .HasForeignKey(d => d.HandelseIdSplittbar)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gemDMSDocLink_arkHandelse");
            });

            modelBuilder.Entity<GemDmsdoclinkOld>(entity =>
            {
                entity.HasKey(e => e.DoclinkId)
                    .HasName("PK__GEM_DMSD__72E3343830AD52EA");

                entity.ToTable("GEM_DMSDOCLINK_OLD");

                entity.HasIndex(e => e.DmsdocId, "XAK1gem_dmsdoclink")
                    .IsUnique();

                entity.Property(e => e.DoclinkId)
                    .ValueGeneratedNever()
                    .HasColumnName("doclink_id");

                entity.Property(e => e.DmsdocId)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("dmsdoc_id");

                entity.Property(e => e.Filetype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("filetype");

                entity.Property(e => e.Usecount).HasColumnName("usecount");
            });

            modelBuilder.Entity<GemHiss>(entity =>
            {
                entity.HasKey(e => e.IndividInventarieId)
                    .HasName("XPKgemHiss");

                entity.ToTable("gemHiss");

                entity.Property(e => e.IndividInventarieId).ValueGeneratedNever();

                entity.HasOne(d => d.IndividInventarie)
                    .WithOne(p => p.GemHiss)
                    .HasForeignKey<GemHiss>(d => d.IndividInventarieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemIndividInventarie_gemHiss");
            });

            modelBuilder.Entity<GemIndividInventarie>(entity =>
            {
                entity.HasKey(e => e.IndividInventarieId)
                    .HasName("XPKgemIndividInventarie");

                entity.ToTable("gemIndividInventarie");

                entity.HasIndex(e => e.ArtikelId, "XFKgemIndividInventarie_babArtikel");

                entity.Property(e => e.Beteckning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.GemIndividInventaries)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("babArtikel_gemIndividInventarie");
            });

            modelBuilder.Entity<GemKommun>(entity =>
            {
                entity.HasKey(e => e.KomKod)
                    .HasName("XPKGEM_KOMMUN");

                entity.ToTable("GEM_KOMMUN");

                entity.HasIndex(e => e.Kommun, "XAK1GEM_KOMMUN")
                    .IsUnique();

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Kommun)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasMany(d => d.Namnds)
                    .WithMany(p => p.KomKods)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArkNamndKommun",
                        l => l.HasOne<ArkNamnd>().WithMany().HasForeignKey("NamndId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkNamnd_Kommun_arkNamnd"),
                        r => r.HasOne<GemKommun>().WithMany().HasForeignKey("KomKod").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("arkNamnd_Kommun_GEM_KOMMUN"),
                        j =>
                        {
                            j.HasKey("KomKod", "NamndId").HasName("XPKarkNamnd_Kommun");

                            j.ToTable("arkNamnd_Kommun");

                            j.HasIndex(new[] { "NamndId", "KomKod" }, "XFKARKNAMND_KOMMUN_ARKNAMND");

                            j.IndexerProperty<string>("KomKod").HasMaxLength(4).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<GemKommunV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GEM_KOMMUN_V1");

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Kommun)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemKommunikationTyp>(entity =>
            {
                entity.HasKey(e => e.KomTypId)
                    .HasName("XPKgemKommunikationTyp");

                entity.ToTable("gemKommunikationTyp");

                entity.HasIndex(e => e.Beskrivning, "XAK1gemKommunikationTyp")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KomTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemObjekt>(entity =>
            {
                entity.HasKey(e => e.ObjektId)
                    .HasName("XPKgemObjekt");

                entity.ToTable("gemObjekt");

                entity.HasIndex(e => new { e.ObjektTypId, e.TypId }, "XAK1gemObjekt")
                    .IsUnique()
                    .HasFilter("([TypId]<>(0))");

                entity.HasIndex(e => new { e.ObjektTypId, e.Beskrivning, e.KomKod }, "XAK2gemObjekt")
                    .IsUnique()
                    .HasFilter("([ObjektTypId]<>(3) AND [ObjektTypId]<>(6) AND [ObjektTypId]<>(10) AND [ObjektTypId]<>(12) AND [ObjektTypId]<>(50) AND [ObjektTypId]<>(51))");

                entity.HasIndex(e => new { e.ObjektTypId, e.TypUuid }, "XAK3gemObjekt_cTypUUID")
                    .IsUnique()
                    .HasFilter("([TypUUID] IS NOT NULL)");

                entity.HasIndex(e => new { e.Beskrivning, e.TypUuid }, "XAK4gemObjekt_cBelAdr")
                    .IsUnique()
                    .HasFilter("([ObjektTypId]=(3))");

                entity.HasIndex(e => new { e.TypId, e.ObjektTypId, e.ObjektId }, "XFKGEMOBJEKT_GEMOBJEKTTYP");

                entity.HasIndex(e => new { e.ObjektTypId, e.Beskrivning }, "XIEgemObjekt_Beskrivning")
                    .HasFilter("([ObjektTypId]=(6))");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TypId).HasColumnType("numeric(9, 0)");

                entity.Property(e => e.TypUuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("TypUUID");

                entity.Property(e => e.XmlForhandsGranska)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.KomKodNavigation)
                    .WithMany(p => p.GemObjekts)
                    .HasForeignKey(d => d.KomKod)
                    .HasConstraintName("gemObjekt_gem_Kommun");

                entity.HasOne(d => d.ObjektTyp)
                    .WithMany(p => p.GemObjekts)
                    .HasForeignKey(d => d.ObjektTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemObjekt_gemObjektTyp");
            });

            modelBuilder.Entity<GemObjektTyp>(entity =>
            {
                entity.HasKey(e => e.ObjektTypId)
                    .HasName("XPKgemObjektTyp");

                entity.ToTable("gemObjektTyp");

                entity.HasIndex(e => e.Beskrivning, "XAK1gemObjektTyp")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemPersOrg>(entity =>
            {
                entity.HasKey(e => e.PersOrgId)
                    .HasName("XPKgemPersOrg");

                entity.ToTable("gemPersOrg");

                entity.HasIndex(e => new { e.PersOrgNr, e.FsKundnr }, "XIEgemPersOrg_PersOrgNr_KundNr");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.BestallarIdent)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.FakturaIdent)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.FsKundnr)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Fs_Kundnr");

                entity.Property(e => e.Motpart)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PersOrgNr)
                    .HasMaxLength(33)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDat).HasColumnType("datetime");

                entity.Property(e => e.XmlForhandsGranska)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersOrgTyp)
                    .WithMany(p => p.GemPersOrgs)
                    .HasForeignKey(d => d.PersOrgTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrg_gemPersOrgTyp");

                entity.HasOne(d => d.RefPersOrg)
                    .WithMany(p => p.InverseRefPersOrg)
                    .HasForeignKey(d => d.RefPersOrgId)
                    .HasConstraintName("gemPersOrg_PersOrg_RefPersOrg");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.GemPersOrgs)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrg_Handlaggare_UpdSign");
            });

            modelBuilder.Entity<GemPersOrgAdress>(entity =>
            {
                entity.HasKey(e => e.PersOrgId)
                    .HasName("XPKgemPersOrgAdress");

                entity.ToTable("gemPersOrgAdress");

                entity.Property(e => e.PersOrgId).ValueGeneratedNever();

                entity.Property(e => e.Attention)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.CoAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.GatuAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.Land)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PostNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.PostOrt)
                    .HasMaxLength(27)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDat).HasColumnType("datetime");

                entity.HasOne(d => d.PersOrg)
                    .WithOne(p => p.GemPersOrgAdress)
                    .HasForeignKey<GemPersOrgAdress>(d => d.PersOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgAdress_gemPersOrg");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.GemPersOrgAdresses)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgAdress_Handl_UpdSign");
            });

            modelBuilder.Entity<GemPersOrgAttention>(entity =>
            {
                entity.HasKey(e => e.PersOrgAttentionId)
                    .HasName("XPKgemPersOrgAttention");

                entity.ToTable("gemPersOrgAttention");

                entity.HasIndex(e => new { e.PersOrgId, e.Attention, e.Persnr }, "XAK1gemPersOrgAttention")
                    .IsUnique();

                entity.HasIndex(e => new { e.PersOrgId, e.Persnr }, "XAK2gemPersOrgAttention")
                    .IsUnique()
                    .HasFilter("([ArAktiv]=(1) AND [PersNr] IS NOT NULL)");

                entity.HasIndex(e => e.PersOrgId, "XFKGEMPERSORGATTENTION_PERSORG");

                entity.HasIndex(e => e.Persnr, "XIEgemPersOrgAttention_PersNr");

                entity.Property(e => e.Attention)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.Persnr)
                    .HasMaxLength(33)
                    .IsUnicode(false)
                    .HasColumnName("PERSNR");

                entity.Property(e => e.Referens)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDat).HasColumnType("datetime");

                entity.HasOne(d => d.PersOrg)
                    .WithMany(p => p.GemPersOrgAttentions)
                    .HasForeignKey(d => d.PersOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgAttention_gemPersOrg");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.GemPersOrgAttentions)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgAtt_Handl_UpdSign");
            });

            modelBuilder.Entity<GemPersOrgBehorighet>(entity =>
            {
                entity.HasKey(e => e.PersOrgBehorighetId)
                    .HasName("XPKgemPersOrgBehorighet");

                entity.ToTable("gemPersOrgBehorighet");

                entity.HasIndex(e => new { e.PersOrgId, e.Rollid }, "XAK1gemPersOrgBehorighet")
                    .IsUnique();

                entity.HasIndex(e => e.PersOrgId, "XFKGEMPERSORGBEHORIGHET_PERORG");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BehorighetsNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GodkandAv)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GodkandTillDatum).HasColumnType("datetime");

                entity.Property(e => e.IntygsDatum).HasColumnType("datetime");

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.HasOne(d => d.PersOrgBehorighetNiva)
                    .WithMany(p => p.GemPersOrgBehorighets)
                    .HasForeignKey(d => d.PersOrgBehorighetNivaId)
                    .HasConstraintName("gemPersOrgBeh_gemPerOrgBehNiva");

                entity.HasOne(d => d.PersOrg)
                    .WithMany(p => p.GemPersOrgBehorighets)
                    .HasForeignKey(d => d.PersOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgBehorighet_gemPerOrg");

                entity.HasOne(d => d.Roll)
                    .WithMany(p => p.GemPersOrgBehorighets)
                    .HasForeignKey(d => d.Rollid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgBeh_gemPersOrgRoll");
            });

            modelBuilder.Entity<GemPersOrgBehorighetNiva>(entity =>
            {
                entity.HasKey(e => e.PersOrgBehorighetNivaId)
                    .HasName("XPKgemPersOrgBehorighetNiva");

                entity.ToTable("gemPersOrgBehorighetNiva");

                entity.HasIndex(e => e.BehNiva, "XAK1gemPersOrgBehorighetNiva")
                    .IsUnique();

                entity.Property(e => e.BehNiva)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemPersOrgKommunikation>(entity =>
            {
                entity.HasKey(e => e.PersorgKomunikationTypId)
                    .HasName("XPKgemPersOrg_Kommunikation");

                entity.ToTable("gemPersOrg_Kommunikation");

                entity.HasIndex(e => new { e.PersOrgId, e.PersOrgAttentionId, e.KomTypId, e.Beskrivning }, "XAK1gemPersOrg_Kommunikation")
                    .IsUnique();

                entity.HasIndex(e => e.PersOrgAttentionId, "XFKGEMPERSORG_KOMMUNIKATION_AT");

                entity.HasIndex(e => e.PersOrgId, "XFKGEMPERSORG_KOMM_GEMPERSORG");

                entity.HasIndex(e => new { e.KomTypId, e.Beskrivning }, "XIE1GEMPERSORG_KOMMUNIKATION");

                entity.Property(e => e.PersorgKomunikationTypId).HasColumnName("Persorg_KomunikationTypId");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.KomTyp)
                    .WithMany(p => p.GemPersOrgKommunikations)
                    .HasForeignKey(d => d.KomTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrg_Komm_gemKommTyp");

                entity.HasOne(d => d.PersOrgAttention)
                    .WithMany(p => p.GemPersOrgKommunikations)
                    .HasForeignKey(d => d.PersOrgAttentionId)
                    .HasConstraintName("gemPersOrg_Kommunikation_Att");

                entity.HasOne(d => d.PersOrg)
                    .WithMany(p => p.GemPersOrgKommunikations)
                    .HasForeignKey(d => d.PersOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrg_Komm_gemPersOrg");
            });

            modelBuilder.Entity<GemPersOrgRoll>(entity =>
            {
                entity.HasKey(e => e.Rollid)
                    .HasName("XPKgemPersOrgRoll");

                entity.ToTable("gemPersOrgRoll");

                entity.HasIndex(e => e.Roll, "XAK1gemPersOrgRoll")
                    .IsUnique();

                entity.HasIndex(e => new { e.RutinKodId, e.ArAktiv }, "XFKGEMPERSORGROLL_ARKRUTINKOD");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Roll)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Slutdatum).HasColumnType("datetime");

                entity.HasOne(d => d.RutinKod)
                    .WithMany(p => p.GemPersOrgRolls)
                    .HasForeignKey(d => d.RutinKodId)
                    .HasConstraintName("gemPersOrgRoll_arkRutinKod");
            });

            modelBuilder.Entity<GemPersOrgTyp>(entity =>
            {
                entity.HasKey(e => e.PersOrgTypId)
                    .HasName("XPKgemPersOrgTyp");

                entity.ToTable("gemPersOrgTyp");

                entity.HasIndex(e => e.PersOrgTyp, "XAK1gemPersOrgTyp")
                    .IsUnique();

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PersOrgTyp)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemPersOrgVersion>(entity =>
            {
                entity.HasKey(e => e.PersOrgVersionId)
                    .HasName("XPKgemPersOrgVersion");

                entity.ToTable("gemPersOrgVersion");

                entity.HasIndex(e => new { e.PersOrgId, e.PersOrgVersion }, "XAK1gemPersOrgVersion")
                    .IsUnique();

                entity.HasIndex(e => new { e.PersOrgId, e.UpdDatum }, "XFKGEMPERSORGVERSION_PERSORG");

                entity.Property(e => e.BesokAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.CoAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.EfterNamn)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ForNamn)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.GatuAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.Land)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Namn)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.PostNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.PostOrt)
                    .HasMaxLength(27)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.HasOne(d => d.PersOrg)
                    .WithMany(p => p.GemPersOrgVersions)
                    .HasForeignKey(d => d.PersOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgVersion_gemPersOrg");

                entity.HasOne(d => d.UpdSign)
                    .WithMany(p => p.GemPersOrgVersions)
                    .HasForeignKey(d => d.UpdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPersOrgVer_Handlagg_UpdSign");
            });

            modelBuilder.Entity<GemPersOrgVersionNyastV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("gemPersOrgVersion_Nyast_V1");

                entity.Property(e => e.Anteckning)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.BehorighetsNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BesokAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.CoAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.EfterNamn)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ForNamn)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FsKundnr)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Fs_Kundnr");

                entity.Property(e => e.GatuAdress)
                    .HasMaxLength(215)
                    .IsUnicode(false);

                entity.Property(e => e.GodkandAv)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GodkandTillDatum).HasColumnType("datetime");

                entity.Property(e => e.IntygsDatum).HasColumnType("datetime");

                entity.Property(e => e.Land)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Namn)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.PersOrgBehAnteckning)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersOrgNr)
                    .HasMaxLength(33)
                    .IsUnicode(false);

                entity.Property(e => e.PostNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.PostOrt)
                    .HasMaxLength(27)
                    .IsUnicode(false);

                entity.Property(e => e.Referensnr)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<GemPersOrgVersionNyastV2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("gemPersOrgVersion_Nyast_V2");
            });

            modelBuilder.Entity<GemPrelRegByggnad>(entity =>
            {
                entity.HasKey(e => e.ObjektId)
                    .HasName("XPKgemPrelRegByggnad");

                entity.ToTable("gemPrelRegByggnad");

                entity.HasIndex(e => e.FastighetObjektId, "XFKgemPrelRegByg_FastObjekt");

                entity.Property(e => e.ObjektId).ValueGeneratedNever();

                entity.Property(e => e.PrelAndamal)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PrelDetaljeratAndamal)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.FastighetObjekt)
                    .WithMany(p => p.GemPrelRegByggnadFastighetObjekts)
                    .HasForeignKey(d => d.FastighetObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPrelRegByg_FastObjekt");

                entity.HasOne(d => d.Objekt)
                    .WithOne(p => p.GemPrelRegByggnadObjekt)
                    .HasForeignKey<GemPrelRegByggnad>(d => d.ObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gemPrelRegByg_Objekt");
            });

            modelBuilder.Entity<Konv240BevPamMissingHpv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevPam_MissingHPV");

                entity.Property(e => e.HandelsePersorgversionid).HasColumnName("HANDELSE_PERSORGVERSIONID");

                entity.Property(e => e.Handelseidpaminn).HasColumnName("HANDELSEIDPAMINN");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Utskickid).HasColumnName("UTSKICKID");
            });

            modelBuilder.Entity<Konv240BevPamNsMissingHpv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevPamNS_MissingHPV");

                entity.Property(e => e.HandelsePersorgversionid).HasColumnName("HANDELSE_PERSORGVERSIONID");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Utskickid).HasColumnName("UTSKICKID");
            });

            modelBuilder.Entity<Konv240BevSvarMissingHpv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevSvar_MissingHPV");

                entity.Property(e => e.HandelsePersorgversionid).HasColumnName("HANDELSE_PERSORGVERSIONID");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Utskickid).HasColumnName("UTSKICKID");
            });

            modelBuilder.Entity<Konv240BevUtsMissingFast>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevUts_MissingFast");

                entity.HasIndex(e => e.Fnr, "XIEkonv240_BevUts_MissingFast");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KomKod)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID");
            });

            modelBuilder.Entity<Konv240BevUtsMissingHandelseIdUtskick>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevUts_MissingHandelseIdUtskick");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<Konv240BevUtsMissingHpv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevUts_MissingHPV");

                entity.Property(e => e.HandelsePersorgversionid).HasColumnName("HANDELSE_PERSORGVERSIONID");

                entity.Property(e => e.Handelseidutskick).HasColumnName("HANDELSEIDUTSKICK");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Utskickid).HasColumnName("UTSKICKID");
            });

            modelBuilder.Entity<Konv240BevUtsMissingHpvroll>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("konv240_BevUts_MissingHPVRoll");

                entity.Property(e => e.HandelsePersorgversionid).HasColumnName("HANDELSE_PERSORGVERSIONID");

                entity.Property(e => e.Handelseidutskick).HasColumnName("HANDELSEIDUTSKICK");

                entity.Property(e => e.UpdDatum).HasColumnType("datetime");

                entity.Property(e => e.Utskickid).HasColumnName("UTSKICKID");
            });

            modelBuilder.Entity<OvRbArbeladrGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARBELADR_GEO_V1");

                entity.Property(e => e.Adressplats)
                    .HasMaxLength(107)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSPLATS");

                entity.Property(e => e.Adrplid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("ADRPLID");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.RadId)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArbygGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARBYG_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Andamal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ANDAMAL");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("BESKRIVNING");

                entity.Property(e => e.Detaljeratandamal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DETALJERATANDAMAL");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.KomBid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("KOM_BID");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.RadId)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArendeGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARENDE_GEOFIR_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<OvRbArendeobjektGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARENDEOBJEKT_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeobjektgeomid).HasColumnName("ARENDEOBJEKTGEOMID");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArgenomrGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARGENOMR_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Genomrid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("GENOMRID");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omradebet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OMRADEBET");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArgraevomrGeoAtgardV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARGRAEVOMR_GEO_ATGARD_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.AtgardSlutDat).HasColumnType("datetime");

                entity.Property(e => e.AtgardStartDat).HasColumnType("datetime");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Graevomrid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("GRAEVOMRID");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omradebet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OMRADEBET");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArgraevomrGeoAtgardV2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARGRAEVOMR_GEO_ATGARD_V2");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.AtgardSlutDat).HasColumnType("datetime");

                entity.Property(e => e.AtgardStartDat).HasColumnType("datetime");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Graevomrid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("GRAEVOMRID");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omradebet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OMRADEBET");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Sokande)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArgraevomrGeoAtgardV3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARGRAEVOMR_GEO_ATGARD_V3");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.AtgardSlutDat).HasColumnType("datetime");

                entity.Property(e => e.AtgardStartDat).HasColumnType("datetime");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Graevomrid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("GRAEVOMRID");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omradebet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OMRADEBET");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Sokande)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArgraevomrGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARGRAEVOMR_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Graevomrid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("GRAEVOMRID");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omradebet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OMRADEBET");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArprelbeladrGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARPRELBELADR_GEO_V1");

                entity.Property(e => e.Adressplats)
                    .HasMaxLength(107)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSPLATS");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Preladrplid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PRELADRPLID");

                entity.Property(e => e.RadId)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArprelbygGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARPRELBYG_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Andamal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ANDAMAL");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Beskrivning)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("BESKRIVNING");

                entity.Property(e => e.Detaljeratandamal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DETALJERATANDAMAL");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.PrelkomBid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PRELKOM_BID");

                entity.Property(e => e.RadId)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArpreldetplanGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARPRELDETPLAN_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Planbet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("PLANBET");

                entity.Property(e => e.Prelplanid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PRELPLANID");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArprelfastGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARPRELFAST_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Prelfnr)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("PRELFNR");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");
            });

            modelBuilder.Entity<OvRbArtillsynomrGeoV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_ARTILLSYNOMR_GEO_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omradebet)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("OMRADEBET");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Tillsynomrid)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("TILLSYNOMRID");
            });

            modelBuilder.Entity<OvRbFriHandelsGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_FRI_HANDELS_GEOFIR_V1");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handelsedatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HANDELSEDATUM");

                entity.Property(e => e.Handelseid).HasColumnName("HANDELSEID");

                entity.Property(e => e.Handelserubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSERUBRIK");

                entity.Property(e => e.Handelseslag)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAG");

                entity.Property(e => e.Handelseslagid).HasColumnName("HANDELSESLAGID");

                entity.Property(e => e.Handelseslagkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAGKOD");

                entity.Property(e => e.Handelseslagrutinid).HasColumnName("HANDELSESLAGRUTINID");

                entity.Property(e => e.Handelseslagrutinkodid).HasColumnName("HANDELSESLAGRUTINKODID");

                entity.Property(e => e.Handelsetyp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYP");

                entity.Property(e => e.Handelsetypid).HasColumnName("HANDELSETYPID");

                entity.Property(e => e.Handelsetypkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYPKOD");

                entity.Property(e => e.Handelsetyprutinid).HasColumnName("HANDELSETYPRUTINID");

                entity.Property(e => e.Handelsetyprutinkodid).HasColumnName("HANDELSETYPRUTINKODID");

                entity.Property(e => e.Handelseutfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALL");

                entity.Property(e => e.Handelseutfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALLKOD");

                entity.Property(e => e.Handelseutfallsid).HasColumnName("HANDELSEUTFALLSID");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<OvRbHandelseGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_HANDELSE_GEOFIR_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handelsedatum)
                    .HasColumnType("datetime")
                    .HasColumnName("HANDELSEDATUM");

                entity.Property(e => e.Handelseid).HasColumnName("HANDELSEID");

                entity.Property(e => e.Handelserubrik)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSERUBRIK");

                entity.Property(e => e.Handelseslag)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAG");

                entity.Property(e => e.Handelseslagid).HasColumnName("HANDELSESLAGID");

                entity.Property(e => e.Handelseslagkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSESLAGKOD");

                entity.Property(e => e.Handelseslagrutinid).HasColumnName("HANDELSESLAGRUTINID");

                entity.Property(e => e.Handelseslagrutinkodid).HasColumnName("HANDELSESLAGRUTINKODID");

                entity.Property(e => e.Handelsetyp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYP");

                entity.Property(e => e.Handelsetypid).HasColumnName("HANDELSETYPID");

                entity.Property(e => e.Handelsetypkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSETYPKOD");

                entity.Property(e => e.Handelsetyprutinid).HasColumnName("HANDELSETYPRUTINID");

                entity.Property(e => e.Handelsetyprutinkodid).HasColumnName("HANDELSETYPRUTINKODID");

                entity.Property(e => e.Handelseutfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALL");

                entity.Property(e => e.Handelseutfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HANDELSEUTFALLKOD");

                entity.Property(e => e.Handelseutfallsid).HasColumnName("HANDELSEUTFALLSID");

                entity.Property(e => e.HradId).HasColumnName("HRAD_ID");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<OvRbHuvudbeslutGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_HUVUDBESLUT_GEOFIR_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Beslutarmindreavvikelse).HasColumnName("BESLUTARMINDREAVVIKELSE");

                entity.Property(e => e.Beslutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("BESLUTDATUM");

                entity.Property(e => e.Beslutgiltigtilldatum)
                    .HasColumnType("datetime")
                    .HasColumnName("BESLUTGILTIGTILLDATUM");

                entity.Property(e => e.Beslutinstans)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTINSTANS");

                entity.Property(e => e.Beslutinstansardelegat).HasColumnName("BESLUTINSTANSARDELEGAT");

                entity.Property(e => e.Beslutinstanskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTINSTANSKOD");

                entity.Property(e => e.Beslutnr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTNR");

                entity.Property(e => e.Beslututfall)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTUTFALL");

                entity.Property(e => e.Beslututfallkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BESLUTUTFALLKOD");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<OvRbHvdhandlaggGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_HVDHANDLAGG_GEOFIR_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Handlaggarearaktiv).HasColumnName("HANDLAGGAREARAKTIV");

                entity.Property(e => e.Handlaggareid).HasColumnName("HANDLAGGAREID");

                entity.Property(e => e.Handlaggarenamn)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("HANDLAGGARENAMN");

                entity.Property(e => e.Handlaggaresignatur)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("HANDLAGGARESIGNATUR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<OvRbUHvdbeslGeofirV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OV_RB_U_HVDBESL_GEOFIR_V1");

                entity.Property(e => e.Alder).HasColumnName("ALDER");

                entity.Property(e => e.Arendegrupp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPP");

                entity.Property(e => e.Arendegruppid).HasColumnName("ARENDEGRUPPID");

                entity.Property(e => e.Arendegruppkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEGRUPPKOD");

                entity.Property(e => e.Arendeid).HasColumnName("ARENDEID");

                entity.Property(e => e.Arendekalla)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("ARENDEKALLA");

                entity.Property(e => e.Arendeklass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASS");

                entity.Property(e => e.Arendeklassid).HasColumnName("ARENDEKLASSID");

                entity.Property(e => e.Arendeklasskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEKLASSKOD");

                entity.Property(e => e.Arendemening)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ARENDEMENING");

                entity.Property(e => e.Arendeslag)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAG");

                entity.Property(e => e.Arendeslagid).HasColumnName("ARENDESLAGID");

                entity.Property(e => e.Arendeslagkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESLAGKOD");

                entity.Property(e => e.Arendestatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUS");

                entity.Property(e => e.Arendestatuskod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ARENDESTATUSKOD");

                entity.Property(e => e.Arendetyp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYP");

                entity.Property(e => e.Arendetypid).HasColumnName("ARENDETYPID");

                entity.Property(e => e.Arendetypkod)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ARENDETYPKOD");

                entity.Property(e => e.Arinomplan).HasColumnName("ARINOMPLAN");

                entity.Property(e => e.Arsammanhbebygg).HasColumnName("ARSAMMANHBEBYGG");

                entity.Property(e => e.Cfdfnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CFDFNR");

                entity.Property(e => e.Diarie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIARIE");

                entity.Property(e => e.Diarieid).HasColumnName("DIARIEID");

                entity.Property(e => e.Diarieprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIARIEPREFIX");

                entity.Property(e => e.Dnr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DNR");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENHET");

                entity.Property(e => e.Enhetkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENHETKOD");

                entity.Property(e => e.Fastighet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FASTIGHET");

                entity.Property(e => e.Fbetnr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("FBETNR");

                entity.Property(e => e.Fnr).HasColumnName("FNR");

                entity.Property(e => e.Komkod)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KOMKOD")
                    .IsFixedLength();

                entity.Property(e => e.Namnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMND");

                entity.Property(e => e.Namndkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAMNDKOD");

                entity.Property(e => e.Omr).HasColumnName("OMR");

                entity.Property(e => e.OmrMapid)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("OMR_MAPID");

                entity.Property(e => e.Punkttyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PUNKTTYP");

                entity.Property(e => e.RadId).HasColumnName("RAD_ID");

                entity.Property(e => e.Slutdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("SLUTDATUM");

                entity.Property(e => e.Startdatum)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATUM");

                entity.Property(e => e.Trakt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TRAKT");

                entity.Property(e => e.Xkoord).HasColumnName("XKOORD");

                entity.Property(e => e.Ykoord).HasColumnName("YKOORD");
            });

            modelBuilder.Entity<OvkInspectionInterval>(entity =>
            {
                entity.HasKey(e => e.InspectionIntervalId)
                    .HasName("XPOvkInspectionInterval");

                entity.ToTable("ovkInspectionInterval");

                entity.Property(e => e.InspectionIntervalId).ValueGeneratedNever();

                entity.Property(e => e.InspectionInterval)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OvkVentilationSystem>(entity =>
            {
                entity.HasKey(e => e.VentilationSystemId)
                    .HasName("XPOvkVentilationSystem");

                entity.ToTable("ovkVentilationSystem");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstallationDate).HasColumnType("datetime");

                entity.Property(e => e.InternalBuildingName)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.OvkVentilationSystems)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OvkVentilationSystem_GemObjekt");

                entity.HasOne(d => d.InspectionInterval)
                    .WithMany(p => p.OvkVentilationSystems)
                    .HasForeignKey(d => d.InspectionIntervalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OvkVentilationSystem_OvkInspectionInterval");

                entity.HasOne(d => d.VentilationSystemType)
                    .WithMany(p => p.OvkVentilationSystems)
                    .HasForeignKey(d => d.VentilationSystemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OvkVentilationSystem_OvkVentilationSystemType");
            });

            modelBuilder.Entity<OvkVentilationSystemType>(entity =>
            {
                entity.HasKey(e => e.VentilationSystemTypeId)
                    .HasName("XPOvkVentilationSystemType");

                entity.ToTable("ovkVentilationSystemType");

                entity.Property(e => e.VentilationSystemTypeId).ValueGeneratedNever();

                entity.Property(e => e.VentilationSystemType)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_test");

                entity.Property(e => e.Slask)
                    .HasMaxLength(10)
                    .HasColumnName("slask")
                    .IsFixedLength();

                entity.Property(e => e.Test1)
                    .HasMaxLength(10)
                    .HasColumnName("test")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TkcGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_GROUP");

                entity.Property(e => e.IsExternalGroup)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_EXTERNAL_GROUP");

                entity.Property(e => e.ObjectGuid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OBJECT_GUID")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PermNodeId).HasColumnName("PERM_NODE_ID");
            });

            modelBuilder.Entity<TkcLinkConstraint>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_LINK_CONSTRAINT");

                entity.Property(e => e.PermLinkId).HasColumnName("PERM_LINK_ID");

                entity.Property(e => e.PredicateId).HasColumnName("PREDICATE_ID");
            });

            modelBuilder.Entity<TkcMeaning>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_MEANING");

                entity.Property(e => e.MeaningId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MEANING_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
            });

            modelBuilder.Entity<TkcObjectType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_OBJECT_TYPE");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.IsDependent)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_DEPENDENT");

                entity.Property(e => e.IsDomain)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("IS_DOMAIN");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ObjectTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OBJECT_TYPE_ID");

                entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
            });

            modelBuilder.Entity<TkcObjectTypeAttribute>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_OBJECT_TYPE_ATTRIBUTE");

                entity.Property(e => e.AttributeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTRIBUTE_ID");

                entity.Property(e => e.ColumnId).HasColumnName("COLUMN_ID");

                entity.Property(e => e.MeaningId).HasColumnName("MEANING_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ObjectTypeId).HasColumnName("OBJECT_TYPE_ID");

                entity.Property(e => e.TableId).HasColumnName("TABLE_ID");
            });

            modelBuilder.Entity<TkcOperation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_OPERATION");

                entity.Property(e => e.AttributeId).HasColumnName("ATTRIBUTE_ID");

                entity.Property(e => e.ObjectTypeId).HasColumnName("OBJECT_TYPE_ID");

                entity.Property(e => e.OperationTemplateId)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("OPERATION_TEMPLATE_ID");

                entity.Property(e => e.PermNodeId).HasColumnName("PERM_NODE_ID");
            });

            modelBuilder.Entity<TkcOperationMeaning>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_OPERATION_MEANING");

                entity.Property(e => e.MeaningId).HasColumnName("MEANING_ID");

                entity.Property(e => e.PermNodeId).HasColumnName("PERM_NODE_ID");
            });

            modelBuilder.Entity<TkcPackage>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_PACKAGE");

                entity.Property(e => e.ClntObjectFactoryClassName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLNT_OBJECT_FACTORY_CLASS_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PackageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PACKAGE_ID");

                entity.Property(e => e.ProviderObjectFactoryType)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PROVIDER_OBJECT_FACTORY_TYPE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.SrvObjectFactoryClassName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SRV_OBJECT_FACTORY_CLASS_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<TkcPermLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_PERM_LINK");

                entity.Property(e => e.EndPermNodeId).HasColumnName("END_PERM_NODE_ID");

                entity.Property(e => e.PermLinkId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PERM_LINK_ID");

                entity.Property(e => e.StartPermNodeId).HasColumnName("START_PERM_NODE_ID");
            });

            modelBuilder.Entity<TkcPermNode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_PERM_NODE");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");

                entity.Property(e => e.PermNodeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PERM_NODE_ID");

                entity.Property(e => e.PermNodeType)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("PERM_NODE_TYPE");
            });

            modelBuilder.Entity<TkcPredicate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_PREDICATE");

                entity.Property(e => e.MeaningId).HasColumnName("MEANING_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PredicateId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PREDICATE_ID");

                entity.Property(e => e.PredicateOperator)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("PREDICATE_OPERATOR");
            });

            modelBuilder.Entity<TkcRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_ROLE");

                entity.Property(e => e.PermNodeId).HasColumnName("PERM_NODE_ID");
            });

            modelBuilder.Entity<TkcUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TKC_USER");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ObjectGuid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OBJECT_GUID")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PermNodeId).HasColumnName("PERM_NODE_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}