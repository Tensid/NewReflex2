using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Models
{
    public class DefaultConfig
    {
        [Key, ForeignKey("Config")]
        public Guid ConfigId { get; set; }
    }
}
