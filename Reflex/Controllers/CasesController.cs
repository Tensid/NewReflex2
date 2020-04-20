using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Models;
using VisaRService.Contracts;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly ILogger<CasesController> _logger;
        private readonly IRepository _repository;

        public CasesController(ILogger<CasesController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{estateId}/{estateName?}")]
        public IEnumerable<Case> Get(string estateId, string estateName, Guid configId)
        {
            var cases = new List<Case>();
            var caseSources = _repository.GetConfig(configId)?.CaseSources;
            if (caseSources == null)
                return cases;

            foreach (var source in caseSources)
            {
                var proxy = _repository.GetProxy(source, configId);

                var caseResult = new List<Case>();
                try
                {
                    if (source == CaseSource.AGS)
                    {
                        caseResult.AddRange(proxy.GetCasesByEstate(string.IsNullOrWhiteSpace(estateId) ? estateName : estateId));
                    }
                    else
                    {
                        caseResult.AddRange(proxy.GetCasesByEstate(estateId));
                    }

                    cases.AddRange(caseResult);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }

            return cases;
        }
    }
}
