using System;

namespace VisaRService.Contracts
{
    public class Occurence
    {
        public string Title { get; set; }
        public DateTime Arrival { get; set; }
        public Document[] Documents { get; set; }
        public bool IsSecret { get; set; }
        public bool IsWorkingMaterial { get; set; }
    }
}
