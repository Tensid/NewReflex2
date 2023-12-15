namespace ByggrDb
{
    public partial class ArkArendeKlass
    {
        public ArkArendeKlass()
        {
            ArkArendeAtgards = new HashSet<ArkArendeAtgard>();
            ArkArendes = new HashSet<ArkArende>();
            ArkMittByggeKods = new HashSet<ArkMittByggeKod>();
            BabMappadArtikels = new HashSet<BabMappadArtikel>();
        }

        public int ArendeKlassId { get; set; }
        public string ArendeKlass { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }
        public int? DiarieId { get; set; }

        public virtual ArkDiarie? Diarie { get; set; }
        public virtual ICollection<ArkArendeAtgard> ArkArendeAtgards { get; set; }
        public virtual ICollection<ArkArende> ArkArendes { get; set; }
        public virtual ICollection<ArkMittByggeKod> ArkMittByggeKods { get; set; }
        public virtual ICollection<BabMappadArtikel> BabMappadArtikels { get; set; }
    }
}