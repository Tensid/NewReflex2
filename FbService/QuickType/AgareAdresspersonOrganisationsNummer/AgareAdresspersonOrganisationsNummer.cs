using Newtonsoft.Json;

namespace FbService.QuickType.AgareAdressPersonorganisationsnummer
{
    /// <summary>
    /// Hämta adresser för ägare från lista med person-/organisationsnummer
    ///
    /// POST
    ///
    /// {{baseUrl}}/Agare/adress/personOrganisationsNummer?Database=<string>&User=<string>&Password=<string>
    ///
    /// Max 500 person-/organisationsnummer kan skickas per anrop
    /// </summary>
    public class AgareAdressPersonorganisationsnummer
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
        [JsonProperty("identitetsnummer", NullValueHandling = NullValueHandling.Ignore)]
        public string Identitetsnummer { get; set; }

        [JsonProperty("adresstyp", NullValueHandling = NullValueHandling.Ignore)]
        public string Adresstyp { get; set; }

        [JsonProperty("coAdress")]
        public object CoAdress { get; set; }

        [JsonProperty("utdelningsadress1")]
        public object Utdelningsadress1 { get; set; }

        [JsonProperty("utdelningsadress2", NullValueHandling = NullValueHandling.Ignore)]
        public string Utdelningsadress2 { get; set; }

        [JsonProperty("utdelningsadress3")]
        public object Utdelningsadress3 { get; set; }

        [JsonProperty("utdelningsadress4")]
        public object Utdelningsadress4 { get; set; }

        [JsonProperty("postnummer", NullValueHandling = NullValueHandling.Ignore)]
        public string Postnummer { get; set; }

        [JsonProperty("postort", NullValueHandling = NullValueHandling.Ignore)]
        public string Postort { get; set; }

        [JsonProperty("land")]
        public object Land { get; set; }
    }
}
