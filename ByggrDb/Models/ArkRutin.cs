namespace ByggrDb
{
    public partial class ArkRutin
    {
        public ArkRutin()
        {
            ArkRutinKods = new HashSet<ArkRutinKod>();
        }

        public int RutinId { get; set; }
        public string Rutin { get; set; } = null!;
        public string Beskrivning { get; set; } = null!;
        public bool ArAktiv { get; set; }

        public virtual ICollection<ArkRutinKod> ArkRutinKods { get; set; }
    }
}