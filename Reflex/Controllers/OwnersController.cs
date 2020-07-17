using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FbService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly ILogger<OwnersController> _logger;
        private readonly IRepository _repository;

        public OwnersController(ILogger<OwnersController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Owner>> Get(string estateId, string distance, Guid configId)
        {
            var fbProxy = _repository.GetFbProxy(configId);
            var pos = await fbProxy.GetEstatePosition(estateId);
            var fnrs = await fbProxy.GetFnrsFromPosition(pos.NorthingKoordinat, pos.EastingKoordinat, "3006", distance);

            var owners = await fbProxy.GetOwners(fnrs);
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
