using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public enum Visibility
    {
        Hide,
        Restrict,
        Show
    }

    public class IipaxConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public string Name { get; set; }
        public Visibility SecrecyVisibility { get; set; }
        public Visibility PulPersonalSecrecyVisibility { get; set; }
        public Visibility OtherSecrecyVisibility { get; set; }
        public string[] ObjectTypes { get; set; }
    }
}