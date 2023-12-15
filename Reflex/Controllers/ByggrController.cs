using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;
using ReflexByggrService;

namespace Reflex.Controllers
{
    ////[Authorize(Policy = Policies.IsAdmin)]
    [ApiController]
    [Route("api/[controller]")]
    public class ByggrController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepository _repository;
        private readonly ByggrServiceFactory _byggrService;

        public ByggrController(ApplicationDbContext applicationDbContext, IRepository repository, ByggrServiceFactory byggrService)
        {
            _applicationDbContext = applicationDbContext;
            _repository = repository;
            _byggrService = byggrService;
        }

        [HttpGet]
        public IEnumerable<ByggrConfig> Get()
        {
            return _applicationDbContext.ByggrConfigs;
        }

        [HttpGet("documentTypes")]
        public async Task<IEnumerable<SelectOption>> GetDocumentTypes()
        {
            try
            {
                var options = (await _byggrService.Create(Guid.Empty).GetDocumentTypes()).OrderByDescending(x => x.ArAktiv).ThenBy((x)=> x.Beskrivning)
                    .Select(x => new SelectOption { Value = x.Typ, Label = x.Beskrivning, Active = x.ArAktiv });
                return options;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("roles")]
        public async Task<IEnumerable<SelectOption>> GetRoles()
        {
            try
            {
                var options = (await _byggrService.Create(Guid.Empty).GetRoles()).OrderByDescending(x => x.ArAktiv).ThenBy((x) => x.Beskrivning)
                    .Select(x => new SelectOption { Value = x.RollKod, Label = x.Beskrivning, Active = x.ArAktiv });
                return options;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public ByggrConfig Get(Guid id)
        {
            return _applicationDbContext.ByggrConfigs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post(ByggrConfig byggrConfig)
        {
            await _repository.CreateByggr(byggrConfig);
        }

        [HttpPut]
        public async Task Put(ByggrConfig byggrConfig)
        {
            _applicationDbContext.ByggrConfigs.Update(byggrConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var config = _applicationDbContext.ByggrConfigs.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.ByggrConfigs.Remove(config);
            await _applicationDbContext.SaveChangesAsync();
        }

        public class SelectOption
        {
            public string Value { get; set; }
            public string Label { get; set; }
            public bool Active { get; set; }
        }
    }
}
