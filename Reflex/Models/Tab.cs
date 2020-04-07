using System.Text.Json.Serialization;

namespace Reflex.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Tab
    {
        Search, Map, Cases, Population, Property
    }
}
