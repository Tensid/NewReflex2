using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Tab DefaultTab { get; set; }
        public Guid? DefaultConfigId { get; set; }
        [ForeignKey("DefaultConfigId")]
        public virtual Config DefaultConfig { get; set; }
    }
}
