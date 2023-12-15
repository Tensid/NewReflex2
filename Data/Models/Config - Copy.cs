using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{
    public class RolesClaim
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]       
            public Guid Id { get; set; }
            public Guid RoleId { get; set; }
            public string ClaimType { get; set; }
            public string ClaimValue { get; set; }       
    }
}
