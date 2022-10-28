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
        public Visibility HideConfidentialCases { get; set; }
        public Visibility HideConfidentialDocuments { get; set; }
        public Guid[] DocumentTypes { get; set; }
        public Guid[] OccurrenceTypes { get; set; }
        public string[] ProcessTypes { get; set; }
    }
}
