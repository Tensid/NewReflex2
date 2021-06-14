using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FbService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly ILogger<OwnersController> _logger;
        private readonly FbService.IFbService _fbService;

        public OwnersController(ILogger<OwnersController> logger, FbService.IFbService fbService)
        {
            _logger = logger;
            _fbService = fbService;
        }

        [HttpGet]
        public async Task<IEnumerable<Owner>> Get(string estateId, string distance, Guid configId)
        {
            var pos = await _fbService.GetEstatePosition(estateId);
            var fnrs = await _fbService.GetFnrsFromPosition(pos.NorthingKoordinat, pos.EastingKoordinat, "3006", distance);

            var owners = await _fbService.GetOwners(fnrs);
            return owners.Select(owner =>
            {
                var o = owner.Result;
                return new Owner
                {
                    UuIdEstate = o.UuIdEstate,
                    Fnr = o.Fnr,
                    EstateName = o.EstateName,
                    Status = o.Status,
                    CountyCode = o.CountyCode,
                    MunicipalityCode = o.MunicipalityCode,
                    Municipality = o.Municipality,
                    Share = o.Share,
                    Name = o.Name,
                    StreetAddress = o.StreetAddress,
                    PostalCode = o.PostalCode,
                    PostalArea = o.PostalArea
                };
            }).ToList();
        }
    }
}
