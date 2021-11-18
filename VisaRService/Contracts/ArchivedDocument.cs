using System.Collections.Generic;

namespace VisaRService.Contracts
{
    public class ArchivedDocument
    {
        public string Title { get; set; }
        public string PhysicalDocumentId { get; set; }
        public string Secrecy { get; set; }
        public string PulPersonalSecrecy { get; set; }
        public string OtherSecrecy { get; set; }
        public IEnumerable<Doc> Docs { get; set; }
        public bool UnavailableDueToSecrecy { get; set; }
    }
    public class Doc
    {
        public string Title { get; set; }
        public string Secrecy { get; set; }
        public string PulPersonalSecrecy { get; set; }
        public string OtherSecrecy { get; set; }
        public IEnumerable<File> Files { get; set; }
        public bool UnavailableDueToSecrecy { get; set; }
    }

    public class File
    {
        public string Title { get; set; }
        public string PhysicalDocumentId { get; set; }
        public string Secrecy { get; set; }
        public string PulPersonalSecrecy { get; set; }
        public string OtherSecrecy { get; set; }
        public bool UnavailableDueToSecrecy { get; set; }
    }
}
