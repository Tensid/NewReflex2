using System.Collections.Generic;
using FbService.Contracts;

namespace FbService
{
    public interface IFbService
    {
        Estate GetEstate(string estateId);

        Estate[] SearchEstates(string searchText);

        Address[] SearchAddress(string searchText);

        IEnumerable<KidPerson> KidPersonsByFnr(string estateId);

        Position GetEstatePosition(string estateId);

        string[] GetFnrFromPosition(string lat, string lon, string srid, string avstand);

        string GetGeometryFromFnr(string fnr);
    }
}
