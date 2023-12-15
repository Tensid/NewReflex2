namespace ByggrDb
{
    public partial class ArkHandlingTyp
    {
        public ArkHandlingTyp()
        {
            ArkHandelseFordefinierads = new HashSet<ArkHandelseFordefinierad>();
            ArkHandlings = new HashSet<ArkHandling>();
            ArkMittByggeKods = new HashSet<ArkMittByggeKod>();
        }

        public int HandlingTypId { get; set; }
        public string HandlingTyp { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }
        public int? SortOrdn { get; set; }
        public bool? SkaArkiveras { get; set; }

        public virtual ICollection<ArkHandelseFordefinierad> ArkHandelseFordefinierads { get; set; }
        public virtual ICollection<ArkHandling> ArkHandlings { get; set; }
        public virtual ICollection<ArkMittByggeKod> ArkMittByggeKods { get; set; }
    }
}