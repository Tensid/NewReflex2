using System;

namespace Reflex.Data.Models
{
    public class EcosSettings
    {
        public Guid Id { get; set; }
        public string ServiceUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
