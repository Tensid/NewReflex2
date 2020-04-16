using FbService.Contracts;
using FbService.QuickType.BefolkningFolkbokforingPid;
using FbService.QuickType.BefolkningSearchFolkbokfordFastighetFnr;
using FbService.QuickType.BefolkningSenasteadressPid;
using FbService.QuickType.FastighetInfo;
using FbService.QuickType.FastighetKoordinatFnr;
using FbService.QuickType.FastighetSearchBelagenhetsadress;
using FbService.QuickType.FastighetSearchEnkelbeteckningSorterad;
using FbService.QuickType.FastighetSearchFranPunkt;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VisaRService.Contracts;

namespace FbService.Provider
{
    public class FbProvider
    {
        private static string _baseUri;
        private static string _userConnection;

        public FbProvider(ConfigItem config)
        {
            _baseUri = config.FbServiceUrl;
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

        public Estate[] SearchEstates(string searchText)
        {
            var list = new List<Estate>();
            var client = new RestClient($"{_baseUri}/fastighet/search/enkelbeteckning/sorterad?Beteckning={searchText}&{_userConnection}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            var fastighetSearch = JsonConvert.DeserializeObject<FastighetSearchEnkelbeteckningSorterad>(response.Content);

            if (fastighetSearch != null && fastighetSearch.Data?.Length > 0)
            {
                list.AddRange(fastighetSearch.Data.Select(f => new Estate { EstateId = f.Fnr.ToString(CultureInfo.InvariantCulture), EstateName = f.Beteckning }));
            }

            list.Sort(new EstateComparer(searchText));

            return list.ToArray();
        }

        public Address[] SearchAddress(string searchText)
        {
            var client = new RestClient($"{_baseUri}/fastighet/search/belagenhetsadress/{searchText}?{_userConnection}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            var belagenhetsadress = JsonConvert.DeserializeObject<FastighetSearchBelagenhetsadress>(response.Content);

            if (belagenhetsadress == null || belagenhetsadress.Data.Length <= 0)
                return new Address[0];

            var fnr = belagenhetsadress.Data.Select(x => x.Grupp.First().Fnr).ToArray();
            var estates = GetEstateInfo(fnr).Data;

            var list = (from datum in belagenhetsadress.Data
                        join estate in estates on datum.Grupp.First().Fnr.ToString() equals estate.Fnr.ToString()
                        select new Address
                        {
                            AddressText = datum.Belagenhetsadress,
                            Estate = new Estate
                            {
                                EstateName = estate.Beteckning,
                                EstateId = estate.Fnr.ToString()
                            }
                        }).ToList();

            return list.ToArray();
        }

        public Estate GetEstate(string estateId)
        {
            int[] fnr = { int.Parse(estateId) };
            var fastighetInfo = GetEstateInfo(fnr);

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

        private FastighetInfoFnr GetEstateInfo(IEnumerable fnr)
        {
            var client = new RestClient($"{_baseUri}/Fastighet/info/fnr?{_userConnection}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(fnr), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var fastighetInfoFnr = JsonConvert.DeserializeObject<FastighetInfoFnr>(response.Content);

            return fastighetInfoFnr;
        }

        internal Position GetEstatePosition(string fnr)
        {
            var client = new RestClient($"{_baseUri}/Fastighet/koordinat/fnr?{_userConnection}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json-patch+json");
            request.AddParameter("undefined", $"[{fnr}]", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var fastighetKoordinatFnr = JsonConvert.DeserializeObject<FastighetKoordinatFnr>(response.Content);

            var position = new Position
            {
                NorthingKoordinat = fastighetKoordinatFnr?.Data.First().Grupp.First().Sweref99TmNorthingKoordinat.ToString(),
                EastingKoordinat = fastighetKoordinatFnr?.Data.First().Grupp.First().Sweref99TmEastingKoordinat.ToString()
            };
            return position;
        }

        internal string[] GetFnrFromPosition(string lat, string lon, string srid, string avstand, bool completelyInside = false)
        {
            var client = new RestClient($"{_baseUri}/fastighet/search/franPunkt/{lat}/{lon}/{srid}/{avstand}?CompletelyInside={completelyInside}&{_userConnection}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            var fastighetSearchFranPunkt = JsonConvert.DeserializeObject<FastighetSearchFranPunkt>(response.Content);
            string[] fnr = fastighetSearchFranPunkt.Data.Select(x => x.Fnr).ToArray();
            return fnr;
        }

        internal string GetGeometryFromFnr(string fnr)
        {
            var client = new RestClient($"{_baseUri}/Fastighet/yta/fnr?{_userConnection}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json-patch+json");
            request.AddParameter("undefined", $"[{fnr}]", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        internal IEnumerable<KidPerson> KidPersonsByFnr(string estateId)
        {
            var client = new RestClient($"{_baseUri}/befolkning/search/folkbokford/fastighet/fnr/{estateId}?{_userConnection}");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            var befolkningSearch = JsonConvert.DeserializeObject<BefolkningSearchFolkbokfordFastighetFnr>(response.Content);

            var pids = befolkningSearch.Data.Select(x => x.Pid);
            var kidResult = KidResult(pids);
            return kidResult;
        }

        private IEnumerable<KidPerson> KidResult(IEnumerable<int> pids)
        {
            var client = new RestClient($"{_baseUri}/Befolkning/folkbokforing/pid?{_userConnection}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json-patch+json");
            request.AddParameter("undefined", JsonConvert.SerializeObject(pids), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var befolkningFolkbokforingPid = JsonConvert.DeserializeObject<BefolkningFolkbokforingPid>(response.Content);

            var bspClient = new RestClient($"{ _baseUri }/Befolkning/senasteadress/pid?{_userConnection}");
            var bspRequest = new RestRequest(Method.POST);
            bspRequest.AddHeader("Accept", "application/json");
            bspRequest.AddHeader("Content-Type", "application/json-patch+json");
            bspRequest.AddParameter("undefined", JsonConvert.SerializeObject(pids), ParameterType.RequestBody);
            IRestResponse bspResponse = bspClient.Execute(bspRequest);
            var befolkningSenasteadressPid = JsonConvert.DeserializeObject<BefolkningSenasteadressPid>(bspResponse.Content);

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
