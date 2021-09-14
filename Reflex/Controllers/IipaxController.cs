using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;

namespace Reflex.Controllers
{
    [Authorize(Policy = Policies.IsAdmin)]
    [ApiController]
    [Route("api/[controller]")]
    public class IipaxController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IipaxController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IEnumerable<IipaxConfig> Get()
        {
            return _applicationDbContext.IipaxConfigs;
        }

        [HttpGet("{id}")]
        public IipaxConfig Get(Guid id)
        {
            return _applicationDbContext.IipaxConfigs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post(IipaxConfig iipaxConfig)
        {
            iipaxConfig.Id = Guid.NewGuid();
            await _applicationDbContext.AddAsync(iipaxConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Put(IipaxConfig iipaxConfig)
        {
            _applicationDbContext.IipaxConfigs.Update(iipaxConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var config = _applicationDbContext.IipaxConfigs.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.IipaxConfigs.Remove(config);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
