namespace ByggrDb
{
    public partial class GemHiss
    {
        public int IndividInventarieId { get; set; }

        public virtual GemIndividInventarie IndividInventarie { get; set; } = null!;
    }
}