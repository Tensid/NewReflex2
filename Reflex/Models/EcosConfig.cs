using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Models
{
    public class EcosConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid ConfigId { get; set; }
        public string ServiceUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
