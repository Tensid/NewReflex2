using FbService.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FbService.Provider
{
    public interface IFbProvider
    {
        Task<Estate> GetEstate(string estateId);
        Task<Position> GetEstatePosition(string fnr);
        Task<IEnumerable<string>> GetFnrsFromPosition(string lat, string lon, string srid, string avstand, bool completelyInside = false);
        Task<string> GetGeometryFromFnr(string fnr);
        Task<IEnumerable<Task<Owner>>> GetOwners(IEnumerable<string> fnrs);
        Task<IEnumerable<KidPerson>> KidPersonsByFnr(string estateId);
        Task<Address[]> SearchAddresses(string searchText);
        Task<Estate[]> SearchEstates(string searchText);
    }
}
