namespace ByggrDb
{
    public partial class ArkNotifieringKlass
    {
        public ArkNotifieringKlass()
        {
            ArkNotifierings = new HashSet<ArkNotifiering>();
        }

        public int NotifieringKlassId { get; set; }
        public string Beskrivning { get; set; } = null!;

        public virtual ICollection<ArkNotifiering> ArkNotifierings { get; set; }
    }
}