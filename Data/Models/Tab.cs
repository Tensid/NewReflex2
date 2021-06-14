using System.Text.Json.Serialization;

namespace Reflex.Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Tab
    {
        Search, Map, Cases, Population, Property
    }
}
