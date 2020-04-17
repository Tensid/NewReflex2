using System.Collections.Generic;
using System.Threading.Tasks;
using FbService.Contracts;

namespace FbService
{
    public interface IFbService
    {
        Task<Estate> GetEstate(string estateId);

        Task<Estate[]> SearchEstates(string searchText);

        Task<Address[]> SearchAddresses(string searchText);

        Task<IEnumerable<KidPerson>> KidPersonsByFnr(string estateId);

        Task<Position> GetEstatePosition(string estateId);

        Task<IEnumerable<string>> GetFnrsFromPosition(string lat, string lon, string srid, string avstand);

        Task<string> GetGeometryFromFnr(string fnr);
    }
}
