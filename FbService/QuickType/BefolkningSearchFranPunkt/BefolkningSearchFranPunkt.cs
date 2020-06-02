using System.Text.Json.Serialization;

namespace FbService.QuickType.BefolkningSearchFranPunkt
{
    public class BefolkningSearchFranPunkt
    {
        [JsonPropertyName("statusKod")]
        public long? StatusKod { get; set; }

        [JsonPropertyName("statusMeddelande")]
        public string StatusMeddelande { get; set; }

        [JsonPropertyName("fel")]
        public object Fel { get; set; }

        [JsonPropertyName("data")]
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("pid")]
        public int Pid { get; set; }

        [JsonPropertyName("personnummer")]
        public string Personnummer { get; set; }
    }
}
