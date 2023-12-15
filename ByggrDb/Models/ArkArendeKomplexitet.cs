namespace ByggrDb
{
    public partial class ArkArendeKomplexitet
    {
        public ArkArendeKomplexitet()
        {
            ArkArendes = new HashSet<ArkArende>();
        }

        public short ArendeKomplexitetId { get; set; }
        public int FargR { get; set; }
        public int FargG { get; set; }
        public int FargB { get; set; }
        public int FargA { get; set; }
        public bool ArAktiv { get; set; }

        public virtual ICollection<ArkArende> ArkArendes { get; set; }
    }
}