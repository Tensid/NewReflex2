namespace ByggrDb
{
    public partial class ArkBevakning
    {
        public int BevakningId { get; set; }
        public int BevaknTypId { get; set; }
        public string? Anteckning { get; set; }

        public virtual ArkBevakningsTyp BevaknTyp { get; set; } = null!;
        public virtual ArkNotifiering Bevakning { get; set; } = null!;
    }
}