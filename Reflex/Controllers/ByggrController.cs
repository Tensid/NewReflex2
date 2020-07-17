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
    public class ByggrController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ByggrController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IEnumerable<ByggrConfig> Get()
        {
            return _applicationDbContext.ByggrConfigs;
        }

        [HttpGet("{id}")]
        public ByggrConfig Get(Guid id)
        {
            return _applicationDbContext.ByggrConfigs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post(ByggrConfig byggrConfig)
        {
            await _applicationDbContext.ByggrConfigs.AddAsync(byggrConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Put(ByggrConfig byggrConfig)
        {
            _applicationDbContext.ByggrConfigs.Update(byggrConfig);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
