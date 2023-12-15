namespace ByggrDb
{
    public partial class ArkVersion
    {
        public int VersionsId { get; set; }
        public string Namn { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Typ { get; set; } = null!;
        public string Produktgrupp { get; set; } = null!;
        public string Produkt { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string VersionsDat { get; set; } = null!;
        public string DatumTid { get; set; } = null!;
    }
}