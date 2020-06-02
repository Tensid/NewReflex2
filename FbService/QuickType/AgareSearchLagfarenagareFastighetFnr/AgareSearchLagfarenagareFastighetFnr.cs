using System;
using System.Text.Json.Serialization;

namespace FbService.QuickType.AgareSearchLagfarenagareFastighetFnr
{
    /// <summary>
    /// Sök lagfarna ägare för givna fastigheter
    ///
    /// POST
    ///
    /// {{baseUrl}}/agare/search/lagfarenAgare/fastighet/fnr?Database=<string>&User=<string>&Password=<string>
    ///
    /// Max 500 fnr kan skickas per anrop
    /// </summary>
    public class AgareSearchLagfarenagareFastighetFnr
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
        [JsonPropertyName("fnr")]
        public long? Fnr { get; set; }

        [JsonPropertyName("grupp")]
        public Grupp[] Grupp { get; set; }
    }

    public class Grupp
    {
        [JsonPropertyName("identitetsnummer")]
        public string Identitetsnummer { get; set; }

        [JsonPropertyName("uuid")]
        public Guid? Uuid { get; set; }
    }
}
