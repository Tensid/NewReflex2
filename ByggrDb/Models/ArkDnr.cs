namespace ByggrDb
{
    public partial class ArkDnr
    {
        public int DiarieId { get; set; }
        public decimal Ar { get; set; }
        public int Nummer { get; set; }

        public virtual ArkDiarie Diarie { get; set; } = null!;
    }
}