using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Models;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigsController : ControllerBase
    {
        private readonly ILogger<ConfigsController> _logger;
        private readonly IRepository _repository;

        public ConfigsController(ILogger<ConfigsController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
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
                Tabs = x.Tabs,
                Visible = x.Visible
            });
        }
    }
}
