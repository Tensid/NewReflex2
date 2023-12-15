namespace ByggrDb
{
    public partial class ArkArendeSlag
    {
        public ArkArendeSlag()
        {
            ArkArendeAtgards = new HashSet<ArkArendeAtgard>();
            ArkArendes = new HashSet<ArkArende>();
            ArkMittByggeKodSlagMappnings = new HashSet<ArkMittByggeKodSlagMappning>();
            BabMappadArtikels = new HashSet<BabMappadArtikel>();
        }

        public int ArendeSlagId { get; set; }
        public string ArendeSlag { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int ArendeTypId { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ArkArendeTyp ArendeTyp { get; set; } = null!;
        public virtual ICollection<ArkArendeAtgard> ArkArendeAtgards { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<ArkMittByggeKodSlagMappning> ArkMittByggeKodSlagMappnings { get; set; }
        public virtual ICollection<BabMappadArtikel> BabMappadArtikels { get; set; }
    }
}