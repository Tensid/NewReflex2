using FbService.Contracts;
using FbService.QuickType.AgareAdressPersonorganisationsnummer;
using FbService.QuickType.AgareInskrivenPersonorganisationsnummer;
using FbService.QuickType.AgareSearchLagfarenagareFastighetFnr;
using FbService.QuickType.BefolkningFolkbokforingPid;
using FbService.QuickType.BefolkningSearchFolkbokfordFastighetFnr;
using FbService.QuickType.BefolkningSenasteadressPid;
using FbService.QuickType.FastighetInfoFnr;
using FbService.QuickType.FastighetKoordinatFnr;
using FbService.QuickType.FastighetSearchBelagenhetsadress;
using FbService.QuickType.FastighetSearchEnkelbeteckningSorterad;
using FbService.QuickType.FastighetSearchFranPunkt;
using Reflex.SettingsService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Estate = FbService.Contracts.Estate;

namespace FbService.Provider
{
    public class FbProvider : IFbProvider
    {
        private readonly HttpClient _httpClient;
        private static string _userConnection;

        public FbProvider(ISystemSettingsService systemSettingsService, HttpClient httpClient)
        {
            var settings = systemSettingsService.GetFbSettings();
            _httpClient = httpClient;
            if (settings == null)
                return;
            _httpClient.BaseAddress = new Uri(settings.FbServiceUrl);
            _userConnection = $"Database={settings.FbServiceDatabase}&User={settings.FbServiceUser}&Password={settings.FbServicePassword}";
        }

        private class EstateComparer : IComparer<Estate>
        {
            private readonly string _searchText;
            public EstateComparer(string searchText)
            {
                _searchText = searchText;
            }

            public int Compare(Estate x, Estate y)
            {
                var xname = x.EstateName;
                var yname = y.EstateName;

                // #1: Starts with searchText
                var startx = xname.StartsWith(_searchText);
                var starty = yname.StartsWith(_searchText);
                if (startx && !starty)
                    return -1;
                if (!startx && starty)
                    return 1;

                // #2: Contains a word that starts with searchText
                var spacex = xname.Contains(" " + _searchText);
                var spacey = yname.Contains(" " + _searchText);
                if (spacex && !spacey)
                    return -1;
                if (!spacex && spacey)
                    return 1;

                // #3: Earliest occurence of searchText
                var stpos = xname.IndexOf(_searchText, StringComparison.CurrentCultureIgnoreCase) -
                        yname.IndexOf(_searchText, StringComparison.CurrentCultureIgnoreCase);
                if (stpos != 0)
                    return stpos;

                var xbet = xname.Substring(0, xname.LastIndexOf(' '));
                var ybet = yname.Substring(0, yname.LastIndexOf(' '));

                // #4: Same name -> sort by first digit
                if (xbet == ybet)
                {
                    var xnums = xname.Substring(xbet.Length).Split(new[] { ':' });
                    var ynums = yname.Substring(ybet.Length).Split(new[] { ':' });

                    for (var i = 0; i < xnums.Length && i < ynums.Length; i++)
                    {
                        if (xnums[i] == ynums[i]) continue;
                        //int xnum;
                        var xIsNum = int.TryParse(xnums[i], NumberStyles.Number, CultureInfo.InvariantCulture, out var xnum);
                        var yIsNum = int.TryParse(ynums[i], NumberStyles.Number, CultureInfo.InvariantCulture, out var ynum);

                        if (xIsNum && !yIsNum)
                            return -1;
                        if (!xIsNum && yIsNum)
                            return 1;
                        if (!xIsNum && !yIsNum) // Both are non-numerical and non-identical --> string sort
                            break;
                        if (ynum != xnum)
                            return xnum - ynum;
                    }
                }

                // #Final: Culture sensitive string sort
                return string.Compare(x.EstateName, y.EstateName, StringComparison.CurrentCultureIgnoreCase);
            }
        }

        public async Task<Estate[]> SearchEstates(string searchText)
        {
            var response = await _httpClient.GetAsync($"fastighet/search/enkelbeteckning/sorterad?Beteckning={searchText}&{_userConnection}");
            var fastighetSearch = JsonSerializer.Deserialize<FastighetSearchEnkelbeteckningSorterad>(await response.Content.ReadAsStringAsync());

            var estates = new List<Estate>();
            if (fastighetSearch != null && fastighetSearch.Data?.Length > 0)
            {
                estates.AddRange(fastighetSearch.Data.Select(f => new Estate { EstateId = f.Fnr.ToString(CultureInfo.InvariantCulture), EstateName = f.Beteckning }));
                estates.Sort(new EstateComparer(searchText));
            }

            return estates.ToArray();
        }

        public async Task<Address[]> SearchAddresses(string searchText)
        {
            var response = await _httpClient.GetAsync($"fastighet/search/belagenhetsadress/{searchText}?{_userConnection}");
            var belagenhetsadress = JsonSerializer.Deserialize<FastighetSearchBelagenhetsadress>(await response.Content.ReadAsStringAsync());

            if (belagenhetsadress == null || belagenhetsadress.Data.Length <= 0)
                return new Address[0];

            var list = (from datum in belagenhetsadress.Data
                        select new Address
                        {
                            AddressText = datum.Belagenhetsadress,
                            Estate = new Estate
                            {
                                EstateName = "",
                                EstateId = datum.Grupp.FirstOrDefault()?.Fnr.ToString()
                            }
                        }).ToList();

            return list.ToArray();
        }

        public async Task<Estate> GetEstate(string estateId)
        {
            int[] fnr = { int.Parse(estateId) };
            var fastighetInfo = await GetEstateInfo(fnr);

            var searchResult = fastighetInfo.Data.Select(f => new Estate
            {
                EstateName = f.Beteckning,
                EstateId = f.Fnr.ToString()
            }).ToList();

            if (searchResult.Any())
            {
                var f = searchResult.First();
                return new Estate { EstateId = f.EstateId.ToString(CultureInfo.InvariantCulture), EstateName = f.EstateName };
            }
            return null;
        }

        private async Task<FastighetInfoFnr> GetEstateInfo(IEnumerable fnr)
        {
            var response = await _httpClient.PostAsync($"fastighet/info/fnr?{_userConnection}",
                new StringContent(JsonSerializer.Serialize(fnr), Encoding.UTF8, "application/json-patch+json"));

            return JsonSerializer.Deserialize<FastighetInfoFnr>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Position> GetEstatePosition(string fnr)
        {
            var response = await _httpClient.PostAsync($"fastighet/koordinat/fnr?{_userConnection}",
                new StringContent($"[{fnr}]", Encoding.UTF8, "application/json-patch+json"));
            var fastighetKoordinatFnr = JsonSerializer.Deserialize<FastighetKoordinatFnr>(await response.Content.ReadAsStringAsync());

            return new Position
            {
                NorthingKoordinat = fastighetKoordinatFnr?.Data.First().Grupp.First().Sweref99TmNorthingKoordinat.ToString(CultureInfo.InvariantCulture),
                EastingKoordinat = fastighetKoordinatFnr?.Data.First().Grupp.First().Sweref99TmEastingKoordinat.ToString(CultureInfo.InvariantCulture)
            };
        }

        public async Task<IEnumerable<string>> GetFnrsFromPosition(string lat, string lon, string srid, string avstand, bool completelyInside = false)
        {
            var response = await _httpClient.GetAsync(
                $"fastighet/search/franPunkt/{lat}/{lon}/{srid}/{avstand}?CompletelyInside={completelyInside}&{_userConnection}");

            var fastighetSearchFranPunkt = JsonSerializer.Deserialize<FastighetSearchFranPunkt>(await response.Content.ReadAsStringAsync());
            return fastighetSearchFranPunkt.Data.Select(x => x.Fnr.ToString());
        }

        public async Task<string> GetGeometryFromFnr(string fnr)
        {
            var response = await _httpClient.PostAsync($"fastighet/yta/fnr?{_userConnection}",
                new StringContent($"[{fnr}]", Encoding.UTF8, "application/json-patch+json"));

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<KidPerson>> KidPersonsByFnr(string estateId)
        {
            var response = await _httpClient.GetAsync($"befolkning/search/folkbokford/fastighet/fnr/{estateId}?{_userConnection}");
            var befolkningSearch = JsonSerializer.Deserialize<BefolkningSearchFolkbokfordFastighetFnr>(await response.Content.ReadAsStringAsync());

            var pids = befolkningSearch.Data.Select(x => x.Pid);
            var kidResult = await KidResult(pids);
            return kidResult;
        }

        private async Task<IEnumerable<KidPerson>> KidResult(IEnumerable<int> pids)
        {
            var response = await _httpClient.PostAsync($"befolkning/folkbokforing/pid?{_userConnection}",
                new StringContent(JsonSerializer.Serialize(pids), Encoding.UTF8, "application/json-patch+json"));
            var befolkningFolkbokforingPid = JsonSerializer.Deserialize<BefolkningFolkbokforingPid>(await response.Content.ReadAsStringAsync());

            var bspResponse = await _httpClient.PostAsync($"befolkning/senasteadress/pid?{_userConnection}",
                new StringContent(JsonSerializer.Serialize(pids), Encoding.UTF8, "application/json-patch+json"));
            var befolkningSenasteadressPid = JsonSerializer.Deserialize<BefolkningSenasteadressPid>(await bspResponse.Content.ReadAsStringAsync());

            var result = from bfpDatum in befolkningFolkbokforingPid.Data
                         join bspDatum in befolkningSenasteadressPid.Data on bfpDatum.Pid equals bspDatum.Pid
                         select new KidPerson
                         {
                             Sex = bfpDatum.Kon,
                             PersonId = bfpDatum.Identitetsnummer,
                             Firstname = bfpDatum.Fornamn ?? "",
                             Middlename = bfpDatum.Mellannamn ?? "",
                             Familyname = bfpDatum.Efternamn ?? "",
                             Age = (DateTime.Today.Year - Convert.ToInt32(bfpDatum.Identitetsnummer.Remove(4))).ToString(),
                             Address = bspDatum.Grupp.First().Utdelningsadress2,
                             PostalArea = bspDatum.Grupp.First().Postort,
                             LandParcel = ""
                         };

            return result;
        }

        public async Task<IEnumerable<Task<Owner>>> GetOwners(IEnumerable<string> fnrs)
        {
            var response = await _httpClient.PostAsync($"agare/search/lagfarenAgare/fastighet/fnr?{_userConnection}",
                new StringContent(JsonSerializer.Serialize(fnrs), Encoding.UTF8, "application/json"));
            var agareSearchLagfarenagareFastighetFnr = JsonSerializer.Deserialize<AgareSearchLagfarenagareFastighetFnr>(await response.Content.ReadAsStringAsync());
            var ids = agareSearchLagfarenagareFastighetFnr.Data.SelectMany(x => x.Grupp.Select(y => y.Identitetsnummer));
            var owners = await OwnersResult(ids, fnrs);
            return owners;
        }

        private async Task<IEnumerable<Task<Owner>>> OwnersResult(IEnumerable<string> ids, IEnumerable<string> fnrs)
        {
            fnrs = fnrs.ToList();
            var response = await _httpClient.PostAsync($"agare/inskriven/personOrganisationsNummer?{_userConnection}",
                new StringContent(JsonSerializer.Serialize(ids), Encoding.UTF8, "application/json"));

            var agareInskrivenPersonorganisationsnummer = JsonSerializer.Deserialize<AgareInskrivenPersonorganisationsnummer>(await response.Content.ReadAsStringAsync());

            var owners = agareInskrivenPersonorganisationsnummer.Data.Where(x=>fnrs.ToList().Contains(x.Fnr.ToString())).AsParallel().Select(async x =>
            {
                var fastighetResult = (await GetEstateInfo(new[] { x.Fnr })).Data.FirstOrDefault();

                response = await _httpClient.PostAsync($"agare/adress/personOrganisationsNummer?{_userConnection}",
                    new StringContent(JsonSerializer.Serialize(new[] { x.Identitetsnummer }), Encoding.UTF8, "application/json"));

                var agareAdressPersonorganisationsnummer = JsonSerializer.Deserialize<AgareAdressPersonorganisationsnummer>(await response.Content.ReadAsStringAsync()).Data?.FirstOrDefault();

                return new Owner
                {
                    UuIdEstate = x.UuidFastighet.ToString(),
                    Fnr = x.Fnr.ToString(),
                    EstateName = fastighetResult?.Beteckning,
                    Status = fastighetResult?.Status,
                    CountyCode = fastighetResult?.KommunKod.Substring(0, 2),
                    MunicipalityCode = fastighetResult?.KommunKod.Substring(2, 2),
                    Municipality = fastighetResult?.Kommun,
                    Share = x.AndelTaljare + "/" + x.AndelNamnare,
                    Name = string.IsNullOrEmpty(x?.GallandeOrganisationsnamn?.ToString()) ? $"{x.GallandeFornamn} {x.GallandeEfternamn}"
                        : x.GallandeOrganisationsnamn,
                    StreetAddress = agareAdressPersonorganisationsnummer?.Utdelningsadress2,
                    PostalCode = agareAdressPersonorganisationsnummer?.Postnummer,
                    PostalArea = agareAdressPersonorganisationsnummer?.Postort
                };
            });
            return owners;
        }
    }
}
