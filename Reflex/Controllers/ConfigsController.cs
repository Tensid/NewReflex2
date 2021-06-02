using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Models;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigsController : ControllerBase
    {
        private readonly ILogger<ConfigsController> _logger;
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _context;

        public ConfigsController(ILogger<ConfigsController> logger, IRepository repository, ApplicationDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Config> GetConfigs()
        {
            return _repository.GetConfigs().Select(x => new Config
            {
                CaseSources = x.CaseSources,
                CsmUrl = x.CsmUrl,
                Description = x.Description,
                FbWebbBoendeUrl = x.FbWebbBoendeUrl,
                FbWebbLagenhetUrl = x.FbWebbLagenhetUrl,
                FbWebbByggnadUrl = x.FbWebbByggnadUrl,
                FbWebbByggnadUsrUrl = x.FbWebbByggnadUsrUrl,
                FbWebbFastighetUrl = x.FbWebbFastighetUrl,
                FbWebbFastighetUsrUrl = x.FbWebbFastighetUsrUrl,
                Id = x.Id,
                Map = x.Map,
                Name = x.Name,
                Tabs = x.Tabs
            });
        }

        [HttpGet("full")]
        public IEnumerable<Config> GetFullConfigs()
        {
            return _repository.GetConfigs().Select(x => x).ToList();
        }

        [HttpGet("{id}")]
        public Config GetConfig(Guid id)
        {
            return _repository.GetConfig(id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.DeleteConfig(id);
        }

        [HttpPost]
        public void Post(Config config)
        {
            config.Id = Guid.NewGuid();
            _repository.CreateConfig(config);
        }

        [HttpPut]
        public async Task Put(Config config)
        {
            var caseSourceItems = (CaseSource[])Enum.GetValues(typeof(CaseSource));
            var caseSources = config.CaseSources ?? (new CaseSource[] { });
            var subconfigsToDelete = config.CaseSources != null ? caseSourceItems.Except(caseSources) : caseSourceItems;

            foreach (var caseSource in caseSources)
            {
                if (caseSource == CaseSource.AGS)
                {
                    var agsConfig = await _context.AgsConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                    if (agsConfig == null)
                    {
                        await _repository.CreateAgs(new AgsConfig()
                        {
                            Id = Guid.NewGuid(),
                            ConfigId = config.Id,
                        });
                        await _context.SaveChangesAsync();
                    }
                }
                if (caseSource == CaseSource.ByggR)
                {
                    var byggrConfig = await _context.ByggrConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                    if (byggrConfig == null)
                    {
                        await _repository.CreateByggr(new ByggrConfig()
                        {
                            Id = Guid.NewGuid(),
                            ConfigId = config.Id,
                        });
                        await _context.SaveChangesAsync();
                    }
                }
                if (caseSource == CaseSource.Ecos)
                {
                    var ecosConfig = await _context.EcosConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                    if (ecosConfig == null)
                    {
                        await _repository.CreateEcos(new EcosConfig()
                        {
                            Id = Guid.NewGuid(),
                            ConfigId = config.Id,
                        });
                        await _context.SaveChangesAsync();
                    }
                }
            }
            foreach (var caseSource in subconfigsToDelete)
            {
                if (caseSource == CaseSource.AGS)
                {
                    var agsConfig = await _context.AgsConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                    if (agsConfig != null)
                    {
                        _context.AgsConfigs.Remove(agsConfig);
                        await _context.SaveChangesAsync();
                    }
                }
                if (caseSource == CaseSource.ByggR)
                {
                    var byggrConfig = await _context.ByggrConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                    if (byggrConfig != null)
                    {
                        _context.ByggrConfigs.Remove(byggrConfig);
                        await _context.SaveChangesAsync();
                    }
                }
                if (caseSource == CaseSource.Ecos)
                {
                    var ecosConfig = await _context.EcosConfigs.SingleOrDefaultAsync(m => m.ConfigId == config.Id);
                    if (ecosConfig != null)
                    {
                        _context.EcosConfigs.Remove(ecosConfig);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            _repository.UpdateConfig(config);
        }
    }
}
