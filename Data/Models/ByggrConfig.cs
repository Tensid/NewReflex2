using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reflex.Data.Models
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
        [JsonIgnore]
        public virtual ICollection<Config> Configs { get; set; }
        public string Name { get; set; }
        public string[] DocumentTypes { get; set; }
        public string[] OccurenceTypes { get; set; }
        public string[] PersonRoles { get; set; }
        public string[] Diarieprefixes { get; set; }
        public ICollection<CaseTab> Tabs { get; set; }
        public bool WorkingMaterial { get; set; }
        public Visibility HideConfidentialOccurences { get; set; }
        public string HideCasesWithTextMatching { get; set; }
        public string HideOccurencesWithTextMatching { get; set; }
        public string HideDocumentsWithTextMatching { get; set; }
        public string HideDocumentsWithNoteTextMatching { get; set; }
        public bool OnlyCasesWithoutMainDecision { get; set; }
        public bool OnlyActiveCases { get; set; }
        public DateTime? MinCaseStartDate { get; set; }
        public string[] Statuses { get; set; }
    }
}
