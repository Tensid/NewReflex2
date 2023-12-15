namespace ByggrDb
{
    public partial class GemConfigUser
    {
        public GemConfigUser()
        {
            GemConfigValues = new HashSet<GemConfigValue>();
        }

        public int ConfigUserId { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<GemConfigValue> GemConfigValues { get; set; }
    }
}