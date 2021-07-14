using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reflex.Services;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapProxyController : ControllerBase
    {
        private readonly IMapProxyService _mapProxyService;

        public MapProxyController(IMapProxyService mapProxyService)
        {
            _mapProxyService = mapProxyService;
        }

        [HttpGet("{id}")]
        public Task<Stream> Get(string id)
        {
            return _mapProxyService.ProxyRequest(Request.QueryString.ToString(), id);
        }
    }
}
