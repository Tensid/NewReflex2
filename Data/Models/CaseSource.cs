using System.Text.Json.Serialization;

namespace Reflex.Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CaseSource
    {
        AGS,
        ByggR,
        Ecos,
        iipax
    }
}
