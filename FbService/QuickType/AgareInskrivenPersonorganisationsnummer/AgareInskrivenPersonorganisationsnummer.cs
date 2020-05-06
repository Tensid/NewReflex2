using System;
using Newtonsoft.Json;

namespace FbService.QuickType.AgareInskrivenPersonorganisationsnummer
{
    /// <summary>
    /// Hämta information om inskrivna ägare från lista med person-/organisationsnummer
    ///
    /// POST
    ///
    /// {{baseUrl}}/Agare/inskriven/personOrganisationsNummer?Database=<string>&User=<string>&Password=<string>
    ///
    /// Max 500 person-/organisationsnummer kan skickas per anrop
    /// </summary>
    public class AgareInskrivenPersonorganisationsnummer
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

        [JsonProperty("uuidFastighet", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UuidFastighet { get; set; }

        [JsonProperty("typAvAganderatt", NullValueHandling = NullValueHandling.Ignore)]
        public string TypAvAganderatt { get; set; }

        [JsonProperty("uuidAganderatt", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UuidAganderatt { get; set; }

        [JsonProperty("akt", NullValueHandling = NullValueHandling.Ignore)]
        public string Akt { get; set; }

        [JsonProperty("identitetsnummer", NullValueHandling = NullValueHandling.Ignore)]
        public string Identitetsnummer { get; set; }

        [JsonProperty("uuidInskrivenPerson", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UuidInskrivenPerson { get; set; }

        [JsonProperty("inskrivetEfternamn", NullValueHandling = NullValueHandling.Ignore)]
        public string InskrivetEfternamn { get; set; }

        [JsonProperty("inskrivetFornamn", NullValueHandling = NullValueHandling.Ignore)]
        public string InskrivetFornamn { get; set; }

        [JsonProperty("gallandeEfternamn", NullValueHandling = NullValueHandling.Ignore)]
        public string GallandeEfternamn { get; set; }

        [JsonProperty("gallandeMellannamn")]
        public object GallandeMellannamn { get; set; }

        [JsonProperty("gallandeFornamn", NullValueHandling = NullValueHandling.Ignore)]
        public string GallandeFornamn { get; set; }

        [JsonProperty("inskrivetOrganisationsnamn")]
        public object InskrivetOrganisationsnamn { get; set; }

        [JsonProperty("gallandeOrganisationsnamn")]
        public object GallandeOrganisationsnamn { get; set; }

        [JsonProperty("juridiskForm", NullValueHandling = NullValueHandling.Ignore)]
        public string JuridiskForm { get; set; }

        [JsonProperty("andelTaljare", NullValueHandling = NullValueHandling.Ignore)]
        public long? AndelTaljare { get; set; }

        [JsonProperty("andelNamnare", NullValueHandling = NullValueHandling.Ignore)]
        public long? AndelNamnare { get; set; }
    }
}
