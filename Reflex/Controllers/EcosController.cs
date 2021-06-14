using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;
using Reflex.Data.Models;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EcosController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EcosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IEnumerable<EcosConfig> Get()
        {
            return _applicationDbContext.EcosConfigs;
        }

        [HttpGet("{id}")]
        public EcosConfig Get(Guid id)
        {
            return _applicationDbContext.EcosConfigs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post(EcosConfig ecosConfig)
        {
            ecosConfig.Id = Guid.NewGuid();
            await _applicationDbContext.AddAsync(ecosConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Put(EcosConfig ecosConfig)
        {
            _applicationDbContext.EcosConfigs.Update(ecosConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var config = _applicationDbContext.EcosConfigs.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.EcosConfigs.Remove(config);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
