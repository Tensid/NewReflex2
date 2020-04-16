using Newtonsoft.Json;

namespace FbService.QuickType.BefolkningSearchFranPunkt
{
    public class BefolkningSearchFranPunkt
    {
        [JsonProperty("statusKod", NullValueHandling = NullValueHandling.Ignore)]
        public long? StatusKod { get; set; }

        [JsonProperty("statusMeddelande", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusMeddelande { get; set; }

        [JsonProperty("fel")]
        public object Fel { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        [JsonProperty("pid", NullValueHandling = NullValueHandling.Ignore)]
        public int Pid { get; set; }

        [JsonProperty("personnummer", NullValueHandling = NullValueHandling.Ignore)]
        public string Personnummer { get; set; }
    }
}
