namespace ByggrDb
{
    public partial class TkcUser
    {
        public int PermNodeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Password { get; set; }
        public string? ObjectGuid { get; set; }
    }
}