namespace ByggrDb
{
    public partial class ArkGenerellHandling
    {
        public ArkGenerellHandling()
        {
            ArkGenerellHandlingGenerellHandlingKategoris = new HashSet<ArkGenerellHandlingGenerellHandlingKategori>();
        }

        public int GenerellHandlingId { get; set; }
        public string Titel { get; set; } = null!;
        public string FilNamn { get; set; } = null!;
        public byte[] FilData { get; set; } = null!;
        public int FilStorlek { get; set; }
        public int UpdSignId { get; set; }
        public DateTime UpdDatum { get; set; }

        public virtual ArkHandlaggare UpdSign { get; set; } = null!;
        public virtual ICollection<ArkGenerellHandlingGenerellHandlingKategori> ArkGenerellHandlingGenerellHandlingKategoris { get; set; }
    }
}