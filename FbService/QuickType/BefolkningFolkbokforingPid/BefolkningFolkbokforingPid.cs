﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var befolkningFolkbokforingPid = BefolkningFolkbokforingPid.FromJson(jsonString);

using System.Text.Json.Serialization;

namespace FbService.QuickType.BefolkningFolkbokforingPid
{
    public class BefolkningFolkbokforingPid
    {
        [JsonPropertyName("statusKod")]
        public long? StatusKod { get; set; }

        [JsonPropertyName("statusMeddelande")]
        public string StatusMeddelande { get; set; }

        [JsonPropertyName("fel")]
        public string[] Fel { get; set; }

        [JsonPropertyName("data")]
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("pid")]
        public int Pid { get; set; }

        [JsonPropertyName("identitetsnummer")]
        public string Identitetsnummer { get; set; }

        [JsonPropertyName("identitetsnummertyp")]
        public string Identitetsnummertyp { get; set; }

        [JsonPropertyName("kon")]
        public string Kon { get; set; }

        [JsonPropertyName("civilstandskod")]
        public string Civilstandskod { get; set; }

        [JsonPropertyName("civilstandsdatum")]
        public string Civilstandsdatum { get; set; }

        [JsonPropertyName("folkbokforingsdatum")]
        public string Folkbokforingsdatum { get; set; }

        [JsonPropertyName("avregistreringskod")]
        public string Avregistreringskod { get; set; }

        [JsonPropertyName("avregistreringsdatum")]
        public string Avregistreringsdatum { get; set; }

        [JsonPropertyName("efternamn")]
        public string Efternamn { get; set; }

        [JsonPropertyName("mellannamn")]
        public string Mellannamn { get; set; }

        [JsonPropertyName("fornamn")]
        public string Fornamn { get; set; }

        [JsonPropertyName("tilltalsnamn")]
        public string Tilltalsnamn { get; set; }

        [JsonPropertyName("fonetisktNamn")]
        public string FonetisktNamn { get; set; }

        [JsonPropertyName("kommunkod")]
        public string Kommunkod { get; set; }

        [JsonPropertyName("fodelselan")]
        public string Fodelselan { get; set; }

        [JsonPropertyName("fodelsehemort")]
        public string Fodelsehemort { get; set; }

        [JsonPropertyName("utlandskFodelseort")]
        public string UtlandskFodelseort { get; set; }

        [JsonPropertyName("fodelseland")]
        public string Fodelseland { get; set; }

        [JsonPropertyName("invandringsdatum")]
        public string Invandringsdatum { get; set; }

        [JsonPropertyName("fnr")]
        public long? Fnr { get; set; }
    }
}