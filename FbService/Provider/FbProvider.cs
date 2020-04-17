﻿using FbService.Contracts;
using FbService.QuickType.BefolkningFolkbokforingPid;
using FbService.QuickType.BefolkningSearchFolkbokfordFastighetFnr;
using FbService.QuickType.BefolkningSenasteadressPid;
using FbService.QuickType.FastighetInfo;
using FbService.QuickType.FastighetKoordinatFnr;
using FbService.QuickType.FastighetSearchBelagenhetsadress;
using FbService.QuickType.FastighetSearchEnkelbeteckningSorterad;
using FbService.QuickType.FastighetSearchFranPunkt;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VisaRService.Contracts;

namespace FbService.Provider
{
    public class FbProvider
    {
        private readonly HttpClient _httpClient;
        private static string _userConnection;

        public FbProvider(ConfigItem config)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(config.FbServiceUrl) };
            _httpClient = httpClient;

            _userConnection = $"Database={config.FbServiceDatabase}&User={config.FbServiceUser}&Password={config.FbServicePassword}";
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
            var fastighetSearch = JsonConvert.DeserializeObject<FastighetSearchEnkelbeteckningSorterad>(await response.Content.ReadAsStringAsync());

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
            var belagenhetsadress = JsonConvert.DeserializeObject<FastighetSearchBelagenhetsadress>(await response.Content.ReadAsStringAsync());

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
                new StringContent(JsonConvert.SerializeObject(fnr), Encoding.UTF8, "application/json-patch+json"));
            var fastighetInfoFnr = JsonConvert.DeserializeObject<FastighetInfoFnr>(await response.Content.ReadAsStringAsync());

            return fastighetInfoFnr;
        }

        internal async Task<Position> GetEstatePosition(string fnr)
        {
            var response = await _httpClient.PostAsync($"fastighet/koordinat/fnr?{_userConnection}",
                new StringContent($"[{fnr}]", Encoding.UTF8, "application/json-patch+json"));
            var fastighetKoordinatFnr = JsonConvert.DeserializeObject<FastighetKoordinatFnr>(await response.Content.ReadAsStringAsync());

            var position = new Position
            {
                NorthingKoordinat = fastighetKoordinatFnr?.Data.First().Grupp.First().Sweref99TmNorthingKoordinat.ToString(),
                EastingKoordinat = fastighetKoordinatFnr?.Data.First().Grupp.First().Sweref99TmEastingKoordinat.ToString()
            };
            return position;
        }

        internal async Task<IEnumerable<string>> GetFnrsFromPosition(string lat, string lon, string srid, string avstand, bool completelyInside = false)
        {
            var response = await _httpClient.GetAsync(
                $"fastighet/search/franPunkt/{lat}/{lon}/{srid}/{avstand}?CompletelyInside={completelyInside}&{_userConnection}");

            var fastighetSearchFranPunkt = JsonConvert.DeserializeObject<FastighetSearchFranPunkt>(await response.Content.ReadAsStringAsync());
            return fastighetSearchFranPunkt.Data.Select(x => x.Fnr.ToString());
        }

        internal async Task<string> GetGeometryFromFnr(string fnr)
        {
            var response = await _httpClient.PostAsync($"fastighet/yta/fnr?{_userConnection}",
                new StringContent($"[{fnr}]", Encoding.UTF8, "application/json-patch+json"));

            return await response.Content.ReadAsStringAsync();
        }

        internal async Task<IEnumerable<KidPerson>> KidPersonsByFnr(string estateId)
        {
            var response = await _httpClient.GetAsync($"befolkning/search/folkbokford/fastighet/fnr/{estateId}?{_userConnection}");
            var befolkningSearch = JsonConvert.DeserializeObject<BefolkningSearchFolkbokfordFastighetFnr>(await response.Content.ReadAsStringAsync());

            var pids = befolkningSearch.Data.Select(x => x.Pid);
            var kidResult = await KidResult(pids);
            return kidResult;
        }

        private async Task<IEnumerable<KidPerson>> KidResult(IEnumerable<int> pids)
        {
            var response = await _httpClient.PostAsync($"befolkning/folkbokforing/pid?{_userConnection}",
                new StringContent(JsonConvert.SerializeObject(pids), Encoding.UTF8, "application/json-patch+json"));
            var befolkningFolkbokforingPid = JsonConvert.DeserializeObject<BefolkningFolkbokforingPid>(await response.Content.ReadAsStringAsync());

            var bspResponse = await _httpClient.PostAsync($"befolkning/senasteadress/pid?{_userConnection}",
                new StringContent(JsonConvert.SerializeObject(pids), Encoding.UTF8, "application/json-patch+json"));
            var befolkningSenasteadressPid = JsonConvert.DeserializeObject<BefolkningSenasteadressPid>(await bspResponse.Content.ReadAsStringAsync());

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
    }
}
