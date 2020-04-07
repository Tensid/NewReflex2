using System.Text.Json.Serialization;

namespace Reflex.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CaseSource
    {
        AGS,
        ByggR,
        Ecos
    }
}
