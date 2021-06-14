using System.Collections.Generic;
using System.Threading.Tasks;
using FbService.Contracts;
using FbService.Provider;

namespace FbService
{
    public class FbService : IFbService
    {
        private readonly IFbProvider _fb;

        public FbService(IFbProvider fbProvider)
        {
            _fb = fbProvider;
        }

        public Task<Estate> GetEstate(string estateId)
        {
            return _fb.GetEstate(estateId);
        }

        public Task<Estate[]> SearchEstates(string searchText)
        {
            return _fb.SearchEstates(searchText);
        }

        public Task<Address[]> SearchAddresses(string searchText)
        {
            return _fb.SearchAddresses(searchText);
        }

        public Task<IEnumerable<KidPerson>> KidPersonsByFnr(string estateId)
        {
            return _fb.KidPersonsByFnr(estateId);
        }

        public Task<Position> GetEstatePosition(string estateId)
        {
            return _fb.GetEstatePosition(estateId);
        }

        public Task<IEnumerable<string>> GetFnrsFromPosition(string lat, string lon, string srid, string avstand)
        {
            return _fb.GetFnrsFromPosition(lat, lon, srid, avstand);
        }

        public Task<string> GetGeometryFromFnr(string fnr)
        {
            return _fb.GetGeometryFromFnr(fnr);
        }

        public Task<IEnumerable<Task<Owner>>> GetOwners(IEnumerable<string> fnrs)
        {
            return _fb.GetOwners(fnrs);
        }
    }
}
