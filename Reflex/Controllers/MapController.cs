using System.Linq;
using System.Threading.Tasks;
using FbService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        private readonly FbService.IFbService _fbService;

        public MapController(FbService.IFbService fbService)
        {
            _fbService = fbService;
        }

        [HttpGet("fnr")]
        public async Task<string> GetFnrFromPosition(string lat, string lon, string srid, string distance)
        {
            var result = await _fbService.GetFnrsFromPosition(lat, lon, srid, distance);
            return result.FirstOrDefault();
        }

        [HttpGet("geometry")]
        public Task<string> GetGeometryFromFnr(string fnr)
        {
            return _fbService.GetGeometryFromFnr(fnr);
        }

        [HttpGet("estateName")]
        public async Task<string> GetEstateName(string fnr)
        {
            var result = (await _fbService.GetEstate(fnr))?.EstateName ?? "Kunde inte hämta fastighet";
            return result;
        }

        [HttpGet("estatePosition")]
        public Task<Position> GetEstatePosition(string fnr)
        {
            if (string.IsNullOrEmpty(fnr))
                return null;

            return _fbService.GetEstatePosition(fnr);
        }
    }
}
