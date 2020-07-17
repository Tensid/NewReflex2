using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;
using Reflex.Models;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AgsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AgsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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
            await _applicationDbContext.AgsConfigs.AddAsync(agsConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Put(AgsConfig agsConfig)
        {
            _applicationDbContext.AgsConfigs.Update(agsConfig);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
