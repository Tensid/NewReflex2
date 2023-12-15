namespace ByggrDb
{
    public partial class ArkHandelseSlag
    {
        public ArkHandelseSlag()
        {
            ArkHandelseFordefinierads = new HashSet<ArkHandelseFordefinierad>();
            ArkHandelseHandelseNavigations = new HashSet<ArkHandelse>();
            ArkHandelseHandelseSlags = new HashSet<ArkHandelse>();
            ArkHandelseUtfalls = new HashSet<ArkHandelseUtfall>();
        }

        public int HandelseSlagId { get; set; }
        public int HandelseTypId { get; set; }
        public string HandelseSlag { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int? RutinKodId { get; set; }
        public bool ArAktiv { get; set; }
        public int InUt { get; set; }
        public int? MilstolpeId { get; set; }

        public virtual ArkHandelseTyp HandelseTyp { get; set; } = null!;
        public virtual ArkMilstolpe? Milstolpe { get; set; }
        public virtual ArkRutinKod? RutinKod { get; set; }
        public virtual ICollection<ArkHandelseFordefinierad> ArkHandelseFordefinierads { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseHandelseNavigations { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelseHandelseSlags { get; set; }
        public virtual ICollection<ArkHandelseUtfall> ArkHandelseUtfalls { get; set; }
    }
}