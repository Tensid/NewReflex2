namespace ByggrDb
{
    public partial class ArkFrasGrupp
    {
        public ArkFrasGrupp()
        {
            ArkFrasTyps = new HashSet<ArkFrasTyp>();
        }

        public int FrasGruppId { get; set; }
        public string FrasGruppKod { get; set; } = null!;
        public string FrasGruppBeskrivning { get; set; } = null!;
        public int DiarieId { get; set; }

        public virtual ArkDiarie Diarie { get; set; } = null!;
        public virtual ICollection<ArkFrasTyp> ArkFrasTyps { get; set; }
    }
}