using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflex.Models
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
        public virtual ICollection<CaseSource> CaseSources { get; set; }
        public virtual ICollection<AgsConfig> AgsConfigs { get; set; }
        public virtual ICollection<ByggrConfig> ByggrConfigs { get; set; }
        public virtual ICollection<EcosConfig> EcosConfigs { get; set; }
        public string FbWebbBoendeUrl { get; set; }
        public string FbWebbLagenhetUrl { get; set; }
        public string FbWebbFastighetUrl { get; set; }
        public string FbWebbFastighetUsrUrl { get; set; }
        public string FbWebbByggnadUrl { get; set; }
        public string FbWebbByggnadUsrUrl { get; set; }
        public string FbServiceUrl { get; set; }
        public string FbServiceDatabase { get; set; }
        public string FbServiceUser { get; set; }
        public string FbServicePassword { get; set; }
        public string CsmUrl { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUserDefaultConfig { get; set; }
    }
}
