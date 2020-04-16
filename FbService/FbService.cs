using System.Collections.Generic;
using FbService.Contracts;
using FbService.Provider;
using VisaRService.Contracts;

namespace FbService
{
    public class FbService : IFbService
    {
        private readonly FbProvider _fb;

        public FbService(ConfigItem config)
        {
            _fb = new FbProvider(config);
        }

        public Estate GetEstate(string estateId)
        {
            return _fb.GetEstate(estateId);
        }

        public Estate[] SearchEstates(string searchText)
        {
            return _fb.SearchEstates(searchText);
        }

        public Address[] SearchAddress(string searchText)
        {
            return _fb.SearchAddress(searchText);
        }

        public IEnumerable<KidPerson> KidPersonsByFnr(string estateId)
        {
            return _fb.KidPersonsByFnr(estateId);
        }

        public Position GetEstatePosition(string estateId)
        {
            return _fb.GetEstatePosition(estateId);
        }

        public string[] GetFnrFromPosition(string lat, string lon, string srid, string avstand)
        {
            return _fb.GetFnrFromPosition(lat, lon, srid, avstand);
        }

        public string GetGeometryFromFnr(string fnr)
        {
            return _fb.GetGeometryFromFnr(fnr);
        }
    }
}
