namespace ByggrDb
{
    public partial class ArkFra
    {
        public int FrasId { get; set; }
        public int FrasTypId { get; set; }
        public string FrasKod { get; set; } = null!;
        public string Fras { get; set; } = null!;

        public virtual ArkFrasTyp FrasTyp { get; set; } = null!;
    }
}