namespace ByggrDb
{
    public partial class ArkHandelseTyp
    {
        public ArkHandelseTyp()
        {
            ArkHandelseFordefinierads = new HashSet<ArkHandelseFordefinierad>();
            ArkHandelseSlags = new HashSet<ArkHandelseSlag>();
            ArkHandelses = new HashSet<ArkHandelse>();
        }

        public int HandelseTypId { get; set; }
        public string HandelseTyp { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public int? ArendeGruppId { get; set; }
        public bool ArAktiv { get; set; }
        public int? RutinKodId { get; set; }

        public virtual ArkArendeGrupp? ArendeGrupp { get; set; }
        public virtual ArkRutinKod? RutinKod { get; set; }
        public virtual ICollection<ArkHandelseFordefinierad> ArkHandelseFordefinierads { get; set; }
        public virtual ICollection<ArkHandelseSlag> ArkHandelseSlags { get; set; }
        public virtual ICollection<ArkHandelse> ArkHandelses { get; set; }
    }
}