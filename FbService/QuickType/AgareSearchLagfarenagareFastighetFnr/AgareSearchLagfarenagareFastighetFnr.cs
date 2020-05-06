using System;
using Newtonsoft.Json;

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
        [JsonProperty("fnr", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fnr { get; set; }

        [JsonProperty("grupp", NullValueHandling = NullValueHandling.Ignore)]
        public Grupp[] Grupp { get; set; }
    }

    public class Grupp
    {
        [JsonProperty("identitetsnummer", NullValueHandling = NullValueHandling.Ignore)]
        public string Identitetsnummer { get; set; }

        [JsonProperty("uuid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Uuid { get; set; }
    }
}