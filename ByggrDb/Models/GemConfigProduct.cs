namespace ByggrDb
{
    public partial class GemConfigProduct
    {
        public GemConfigProduct()
        {
            GemConfigSections = new HashSet<GemConfigSection>();
        }

        public int ConfigProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public virtual ICollection<GemConfigSection> GemConfigSections { get; set; }
    }
}