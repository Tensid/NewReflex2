using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Models
{
    public class AgsConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid ConfigId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Instance { get; set; }
        public string Department { get; set; }
        public string SearchWay { get; set; }
        public string CasePattern { get; set; }
        public string DocumentPattern { get; set; }
        public string DateField { get; set; }
        public bool EstateNameSearch { get; set; }
        public string ServiceUrl { get; set; }
    }
}
