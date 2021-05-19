using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reflex.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CaseTab
    {
        Preview, Occurences, Persons, Archive
    }

    public class ByggrConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid ConfigId { get; set; }
        public string[] DocumentTypes { get; set; }
        public string[] OccurenceTypes { get; set; }
        public string[] PersonRoles { get; set; }
        public ICollection<CaseTab> Tabs { get; set; }
        public bool WorkingMaterial { get; set; }
        public bool HideCasesWithSecretOccurences { get; set; }
        public string HideDocumentsWithCommentMatching { get; set; }
        public bool OnlyCasesWithoutMainDecision { get; set; }
        public DateTime? MinCaseStartDate { get; set; }
        public string ServiceUrl { get; set; }
    }
}
