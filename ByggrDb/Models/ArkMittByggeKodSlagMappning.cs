namespace ByggrDb
{
    public partial class ArkMittByggeKodSlagMappning
    {
        public decimal KodTypArendeTyp { get; set; }
        public string MittByggeKodArendeTyp { get; set; } = null!;
        public decimal KodTypAtgardsTyp { get; set; }
        public string MittByggeKodAtgardsTyp { get; set; } = null!;
        public int? ArendeSlagId { get; set; }

        public virtual ArkArendeSlag? ArendeSlag { get; set; }
        public virtual ArkMittByggeKod ArkMittByggeKod { get; set; } = null!;
        public virtual ArkMittByggeKod ArkMittByggeKodNavigation { get; set; } = null!;
    }
}