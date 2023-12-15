namespace ByggrDb
{
    public partial class ArkBevakningsTyp
    {
        public int BevaknTypId { get; set; }
        public string BevaknTyp { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }
    }
}