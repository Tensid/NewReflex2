using System;
using System.Linq;
using System.Threading.Tasks;
using FbService.Contracts;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        private readonly IRepository _repository;

        public MapController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("fnr")]
        public async Task<string> GetFnrFromPosition(string lat, string lon, string srid, string distance, Guid configId)
        {
            var proxy = _repository.GetFbProxy(configId);
            var result = await proxy.GetFnrsFromPosition(lat, lon, srid, distance);
            return result.FirstOrDefault();
        }

        [HttpGet("geometry")]
        public Task<string> GetGeometryFromFnr(string fnr, Guid configId)
        {
            return _repository.GetFbProxy(configId).GetGeometryFromFnr(fnr);
        }

        [HttpGet("estateName")]
        public async Task<string> GetEstateName(string fnr, Guid configId)
        {
            var proxy = _repository.GetFbProxy(configId);
            var result = (await proxy.GetEstate(fnr))?.EstateName ?? "Kunde inte hämta fastighet";
            return result;
        }

        [HttpGet("estatePosition")]
        public Task<Position> GetEstatePosition(string fnr, Guid configId)
        {
            if (string.IsNullOrEmpty(fnr))
                return null;

            return _repository.GetFbProxy(configId).GetEstatePosition(fnr);
        }
    }
}
