using System;

namespace Reflex.Data.Models
{
    public class FbSettings : IFbServiceSettings, IFbWebbSettings
    {
        public Guid Id { get; set; }
        public string FbServiceDatabase { get; set; }
        public string FbServicePassword { get; set; }
        public string FbServiceUrl { get; set; }
        public string FbServiceUser { get; set; }
        public string FbWebbBoendeUrl { get; set; }
        public string FbWebbByggnadUrl { get; set; }
        public string FbWebbByggnadUsrUrl { get; set; }
        public string FbWebbFastighetUrl { get; set; }
        public string FbWebbFastighetUsrUrl { get; set; }
        public string FbWebbLagenhetUrl { get; set; }
    }

    public class FbWebbSettings : IFbWebbSettings
    {
        public string FbWebbBoendeUrl { get; set; }
        public string FbWebbLagenhetUrl { get; set; }
        public string FbWebbFastighetUrl { get; set; }
        public string FbWebbFastighetUsrUrl { get; set; }
        public string FbWebbByggnadUrl { get; set; }
        public string FbWebbByggnadUsrUrl { get; set; }
    }

    public class FbSerivceSettings : IFbServiceSettings
    {
        public string FbServiceUrl { get; set; }
        public string FbServiceDatabase { get; set; }
        public string FbServiceUser { get; set; }
        public string FbServicePassword { get; set; }
    }
}
