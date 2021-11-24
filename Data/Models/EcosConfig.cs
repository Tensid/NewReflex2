using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public class EcosConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public string Name { get; set; }
        public bool HideConfidentialCases { get; set; }
        public bool HideConfidentialDocuments{ get; set; }
    }
}
