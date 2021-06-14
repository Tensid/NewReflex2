using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;
using VisaRService.Contracts;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly ILogger<CasesController> _logger;
        private readonly IProxyService _proxyService;
        private readonly ApplicationDbContext _context;

        public CasesController(ILogger<CasesController> logger, IProxyService proxyService, ApplicationDbContext context)
        {
            _logger = logger;
            _proxyService = proxyService;
            _context = context;
        }

        [HttpGet("{estateId}/{estateName?}")]
        public async Task<IEnumerable<Case>> GetCases(string estateId, string estateName, Guid configId)
        {
            var cases = new List<Case>();
            var caseSources = new List<CaseSource>();

            var config = _context.Configs.Include(x => x.AgsConfigs).Include(x => x.ByggrConfigs).Include(x => x.EcosConfigs)
                .First(x => x.Id == configId);
            if (config.AgsConfigs.Count > 0)
                caseSources.Add(CaseSource.AGS);
            if (config.ByggrConfigs.Count > 0)
                caseSources.Add(CaseSource.ByggR);
            if (config.EcosConfigs.Count > 0)
                caseSources.Add(CaseSource.Ecos);

            foreach (var source in caseSources)
            {
                var caseResult = new List<Case>();
                try
                {
                    if (source == CaseSource.AGS)
                    {
                        foreach (var agsConfig in config.AgsConfigs)
                        {
                            var proxy = _proxyService.GetProxy(source, agsConfig.Id);
                            var agsCases = await proxy.GetCasesByEstate(string.IsNullOrWhiteSpace(estateId) ? estateName : estateId);
                            foreach (var c in agsCases)
                            {
                                c.CaseSourceId = agsConfig.Id;
                            }

                            caseResult.AddRange(agsCases);
                        }
                    }
                    if (source == CaseSource.ByggR)
                    {
                        foreach (var byggrConfig in config.ByggrConfigs)
                        {
                            var proxy = _proxyService.GetProxy(source, byggrConfig.Id);
                            var byggrCases = await proxy.GetCasesByEstate(estateId);
                            foreach (var c in byggrCases)
                            {
                                c.CaseSourceId = byggrConfig.Id;
                            }
                            caseResult.AddRange(byggrCases);
                        }
                    }
                    if (source == CaseSource.Ecos)
                    {
                        foreach (var ecosConfig in config.EcosConfigs)
                        {
                            var proxy = _proxyService.GetProxy(source, ecosConfig.Id);
                            var ecosCases = await proxy.GetCasesByEstate(estateId);
                            foreach (var c in ecosCases)
                            {
                                c.CaseSourceId = ecosConfig.Id;
                            }
                            caseResult.AddRange(ecosCases);
                        }
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
        public async Task<IEnumerable<Case>> GetCase(string caseId, Guid caseSourceId, CaseSource caseSource)
        {
            var proxy = _proxyService.GetProxy(caseSource, caseSourceId);
            return new List<Case> { await proxy.GetCase(caseId) };
        }

        [HttpGet("{caseId}/{source}/persons")]
        public async Task<IEnumerable<CasePerson>> GetPersonsByCase(string caseId, CaseSource source, Guid caseSourceId)
        {
            return await _proxyService.GetProxy(source, caseSourceId).GetPersonsByCase(caseId);
        }

        [HttpGet("{caseId}/{source}/preview")]
        public async Task<Preview> GetPreview(string caseId, CaseSource source, Guid caseSourceId)
        {
            return await _proxyService.GetProxy(source, caseSourceId).GetPreviewByCase(caseId);
        }

        [HttpGet("{caseId}/{source}/archivedDocuments")]
        public async Task<IEnumerable<ArchivedDocument>> GetArchivedDocuments(string caseId, CaseSource source, Guid caseSourceId)
        {
            return await _proxyService.GetProxy(source, caseSourceId).GetArchivedDocumentsByCase(caseId);
        }

        [HttpGet("{caseId}/{source}/occurences")]
        public async Task<IEnumerable<Occurence>> GetOccurences(string caseId, CaseSource source, Guid caseSourceId)
        {
            return await _proxyService.GetProxy(source, caseSourceId).GetOccurencesByCase(caseId);
        }

        [HttpGet("document")]
        public async Task<IActionResult> GetDocument(string docId, CaseSource caseSource, Guid caseSourceId)
        {
            PhysicalDocument doc;
            try
            {
                doc = await _proxyService.GetProxy(caseSource, caseSourceId).GetDocument(docId);

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
