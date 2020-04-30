using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Models;
using ReflexAgsService;
using ReflexByggrService;
using ReflexEcos2Service;
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
        public async Task<IEnumerable<Case>> Get(string estateId, string estateName, Guid configId)
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
                        caseResult.AddRange(await proxy.GetCasesByEstate(string.IsNullOrWhiteSpace(estateId) ? estateName : estateId));
                    }
                    else
                    {
                        caseResult.AddRange(await proxy.GetCasesByEstate(estateId));
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

        [HttpGet]
        public async Task<IEnumerable<Case>> GetCase(string id, Guid configId, CaseSource caseSource)
        {
            var proxy = _repository.GetProxy(caseSource, configId);
            return new List<Case> { await proxy.GetCase(id) };
        }

        [HttpGet("{caseId}/persons")]
        public async Task<IEnumerable<CasePerson>> GetPersonsByCase(string caseId, CaseSource caseSource, Guid configId)
        {
            return await _repository.GetProxy(caseSource, configId).GetPersonsByCase(caseId);
        }

        [HttpGet("{caseId}/preview")]
        public async Task<Preview> GetPreview(string caseId, CaseSource caseSource, Guid configId)
        {
            return await _repository.GetProxy(caseSource, configId).GetPreviewByCase(caseId);
        }

        [HttpGet("{caseId}/archivedDocuments")]
        public async Task<IEnumerable<ArchivedDocument>> GetArchivedDocuments(string caseId, CaseSource caseSource, Guid configId)
        {
            return await _repository.GetProxy(caseSource, configId).GetArchivedDocumentsByCase(caseId);
        }

        [HttpGet("{caseId}/occurences")]
        public async Task<IEnumerable<Occurence>> GetOccurences(string caseId, CaseSource caseSource, Guid configId)
        {
            return await _repository.GetProxy(caseSource, configId).GetOccurencesByCase(caseId);
        }

        [HttpGet("document")]
        public async Task<IActionResult> GetDocument(string docId, CaseSource caseSource, Guid configId)
        {
            PhysicalDocument doc;
            try
            {
                doc = caseSource switch
                {
                    CaseSource.AGS => await ((AgsService)_repository.GetProxy(CaseSource.AGS, configId)).GetPhysicalDocument(docId),
                    CaseSource.Ecos => await ((ReflexEcos2Svc)_repository.GetProxy(CaseSource.Ecos, configId)).GetDocument(docId),
                    CaseSource.ByggR => await ((ByggrService)_repository.GetProxy(CaseSource.ByggR, configId)).GetDocument(docId),
                    _ => throw new ArgumentOutOfRangeException()
                };

                if (string.IsNullOrEmpty(doc.Extension))
                {
                    var lastDot = doc.Filename.LastIndexOf(".", StringComparison.Ordinal);
                    doc.Extension = lastDot == -1 ? "" : doc.Filename.Substring(lastDot);
                }

                var stream = new MemoryStream(doc.Data);
                return File(stream, "application/octet-stream", doc.Filename);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
