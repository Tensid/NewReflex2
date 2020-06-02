using System.Text.Json.Serialization;

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
        [JsonPropertyName("identitetsnummer")]
        public string Identitetsnummer { get; set; }

        [JsonPropertyName("adresstyp")]
        public string Adresstyp { get; set; }

        [JsonPropertyName("coAdress")]
        public object CoAdress { get; set; }

        [JsonPropertyName("utdelningsadress1")]
        public object Utdelningsadress1 { get; set; }

        [JsonPropertyName("utdelningsadress2")]
        public string Utdelningsadress2 { get; set; }

        [JsonPropertyName("utdelningsadress3")]
        public object Utdelningsadress3 { get; set; }

        [JsonPropertyName("utdelningsadress4")]
        public object Utdelningsadress4 { get; set; }

        [JsonPropertyName("postnummer")]
        public string Postnummer { get; set; }

        [JsonPropertyName("postort")]
        public string Postort { get; set; }

        [JsonPropertyName("land")]
        public object Land { get; set; }
    }
}
