using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public class AgsConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Instance { get; set; }
        public string Department { get; set; }
        public string SearchWay { get; set; }
        public string CasePattern { get; set; }
        public string DocumentPattern { get; set; }
        public string DateField { get; set; }
        public bool EstateNameSearch { get; set; }
    }
}
