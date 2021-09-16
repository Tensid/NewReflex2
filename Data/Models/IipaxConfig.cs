using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public class IipaxConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public string Name { get; set; }
        public bool HideCasesWithSecrecy { get; set; }
        public bool HideCasesWithPulPersonalSecrecy { get; set; }
        public bool HideCasesWithOtherSecrecy { get; set; }
        public string[] ObjectTypes { get; set; }
    }
}