namespace ByggrDb
{
    public partial class ArkFrasTyp
    {
        public ArkFrasTyp()
        {
            ArkFras = new HashSet<ArkFra>();
        }

        public int FrasTypId { get; set; }
        public int FrasGruppId { get; set; }
        public string FrasTypKod { get; set; } = null!;
        public string FrasTypBeskrivning { get; set; } = null!;

        public virtual ArkFrasGrupp FrasGrupp { get; set; } = null!;
        public virtual ICollection<ArkFra> ArkFras { get; set; }
    }
}