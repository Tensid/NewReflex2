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
        public Visibility CaseSecrecyVisibility { get; set; }
        public Visibility CasePulPersonalSecrecyVisibility { get; set; }
        public Visibility CaseOtherSecrecyVisibility { get; set; }
        public Visibility DocSecrecyVisibility { get; set; }
        public Visibility DocPulPersonalSecrecyVisibility { get; set; }
        public Visibility DocOtherSecrecyVisibility { get; set; }
        public Visibility FileSecrecyVisibility { get; set; }
        public Visibility FilePulPersonalSecrecyVisibility { get; set; }
        public Visibility FileOtherSecrecyVisibility { get; set; }
        public string[] ObjectTypes { get; set; }
    }
}