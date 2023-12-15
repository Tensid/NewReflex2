//using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Data.Models
{

    public class ApplicationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Tab DefaultTab { get; set; }
        public Guid? DefaultConfigId { get; set; }
        [ForeignKey("DefaultConfigId")]
        public virtual Config DefaultConfig { get; set; }
    }

    //public class ApplicationUser : Sokigo.SBWebb.Authentication.ApplicationUser
    //{
    //    public Tab DefaultTab { get; set; }
    //    public Guid? DefaultConfigId { get; set; }
    //    [ForeignKey("DefaultConfigId")]
    //    public virtual Config DefaultConfig { get; set; }
    //}
}
