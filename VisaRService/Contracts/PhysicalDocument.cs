namespace VisaRService.Contracts
{
    public class PhysicalDocument
    {
        public byte[] Data { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string Id { get; set; }
    }
}
