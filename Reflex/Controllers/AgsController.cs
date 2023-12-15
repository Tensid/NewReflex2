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
    ////[Authorize(Policy = Policies.IsAdmin)]
    [ApiController]
    [Route("api/[controller]")]
    public class AgsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepository _repository;

        public AgsController(ApplicationDbContext applicationDbContext, IRepository repository)
        {
            _applicationDbContext = applicationDbContext;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<AgsConfig> Get()
        {
            return _applicationDbContext.AgsConfigs;
        }

        [HttpGet("{id}")]
        public AgsConfig Get(Guid id)
        {
            return _applicationDbContext.AgsConfigs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post(AgsConfig agsConfig)
        {
            await _repository.CreateAgs(agsConfig);
        }

        [HttpPut]
        public async Task Put(AgsConfig agsConfig)
        {
            _applicationDbContext.AgsConfigs.Update(agsConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var config = _applicationDbContext.AgsConfigs.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.AgsConfigs.Remove(config);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
