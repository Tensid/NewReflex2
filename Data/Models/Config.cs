using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public class Config
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Map { get; set; }
        public virtual ICollection<Tab> Tabs { get; set; }
        public virtual ICollection<AgsConfig> AgsConfigs { get; set; }
        public virtual ICollection<ByggrConfig> ByggrConfigs { get; set; }
        public virtual ICollection<EcosConfig> EcosConfigs { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUserDefaultConfig { get; set; }
    }
}
