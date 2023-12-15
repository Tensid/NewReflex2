namespace ByggrDb
{
    public partial class ArkHandelseBeslutNr
    {
        public int DiarieId { get; set; }
        public int Ar { get; set; }
        public int Nummer { get; set; }

        public virtual ArkDiarie Diarie { get; set; } = null!;
    }
}