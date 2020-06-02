using System;
using System.Text.Json.Serialization;

namespace FbService.QuickType.AgareInskrivenInskrivenagareuuid
{
    public class AgareInskrivenInskrivenagareuuid
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

        [JsonPropertyName("uuidFastighet")]
        public Guid? UuidFastighet { get; set; }

        [JsonPropertyName("typAvAganderatt")]
        public string TypAvAganderatt { get; set; }

        [JsonPropertyName("uuidAganderatt")]
        public Guid? UuidAganderatt { get; set; }

        [JsonPropertyName("akt")]
        public string Akt { get; set; }

        [JsonPropertyName("identitetsnummer")]
        public string Identitetsnummer { get; set; }

        [JsonPropertyName("uuidInskrivenPerson")]
        public Guid? UuidInskrivenPerson { get; set; }

        [JsonPropertyName("inskrivetEfternamn")]
        public string InskrivetEfternamn { get; set; }

        [JsonPropertyName("inskrivetFornamn")]
        public string InskrivetFornamn { get; set; }

        [JsonPropertyName("gallandeEfternamn")]
        public string GallandeEfternamn { get; set; }

        [JsonPropertyName("gallandeMellannamn")]
        public object GallandeMellannamn { get; set; }

        [JsonPropertyName("gallandeFornamn")]
        public string GallandeFornamn { get; set; }

        [JsonPropertyName("inskrivetOrganisationsnamn")]
        public string InskrivetOrganisationsnamn { get; set; }

        [JsonPropertyName("gallandeOrganisationsnamn")]
        public string GallandeOrganisationsnamn { get; set; }

        [JsonPropertyName("juridiskForm")]
        public string JuridiskForm { get; set; }

        [JsonPropertyName("andelTaljare")]
        public long? AndelTaljare { get; set; }

        [JsonPropertyName("andelNamnare")]
        public long? AndelNamnare { get; set; }
    }
}
