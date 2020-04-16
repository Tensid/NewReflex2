﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var fastighetSearch = FastighetSearch.FromJson(jsonString);

using Newtonsoft.Json;

namespace FbService.QuickType.FastighetSearchEnkelbeteckningSorterad
{
    public class FastighetSearchEnkelbeteckningSorterad
    {
        [JsonProperty("statusKod")]
        public long StatusKod { get; set; }

        [JsonProperty("statusMeddelande")]
        public string StatusMeddelande { get; set; }

        [JsonProperty("fel")]
        public string[] Fel { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        [JsonProperty("beteckning")]
        public string Beteckning { get; set; }

        [JsonProperty("kommun")]
        public string Kommun { get; set; }

        [JsonProperty("fnr")]
        public long Fnr { get; set; }

        [JsonProperty("cfdFnr")]
        public string CfdFnr { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}
