using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IProxyService _proxyService;
        private readonly ApplicationDbContext _context;
        private readonly FbService.IFbService _fbService;

        public SearchController(ILogger<SearchController> logger, IProxyService proxyService, ApplicationDbContext context, FbService.IFbService fbService)
        {
            _logger = logger;
            _proxyService = proxyService;
            _context = context;
            _fbService = fbService;
        }

        [Authorize(Policy = Policies.HasConfigPermission)]
        public async Task<IEnumerable<SearchResult>> Get(string query, Guid configId)
        {
            var searchResults = new List<SearchResult>();

            if (query != null && query.Length >= 3)
            {
                var config = _context.Configs.Include(x => x.ByggrConfigs).Include(x => x.EcosConfigs).First(x => x.Id == configId);
                var byggrTasks = new List<Task<VisaRService.Contracts.Case>>();
                var ecosTasks = new List<Task<VisaRService.Contracts.Case>>();

                var estateTask = _fbService.SearchEstates(query);
                var addressTask = _fbService.SearchAddresses(query);

                try
                {
                    foreach (var byggrConfig in config.ByggrConfigs)
                    {
                        var byggrProxy = _proxyService.GetProxy(CaseSource.ByggR, byggrConfig.Id);
                        byggrTasks.Add(byggrProxy.GetCase(query));
                    }

                    foreach (var ecosConfig in config.EcosConfigs)
                    {
                        var ecosProxy = _proxyService.GetProxy(CaseSource.Ecos, ecosConfig.Id);
                        ecosTasks.Add(ecosProxy.SearchCase(query));
                    }

                    await Task.WhenAll(estateTask, addressTask);
                }
                catch
                {
                    // ignored
                }

                var estates = await estateTask;
                var addresses = await addressTask;
                searchResults.AddRange(estates
                    .OrderBy(estate => estate.EstateName)
                    .Select(estate => new SearchResult
                    {
                        DisplayName = estate.EstateName,
                        Value = estate.EstateId,
                        EstateName = estate.EstateName,
                        Source = "FB",
                        Type = "Fastighet"
                    }));
                searchResults.AddRange(addresses
                    .OrderBy(address => address.AddressText)
                    .Select(address => new SearchResult
                    {
                        DisplayName = address.AddressText,
                        Value = address.Estate.EstateId,
                        AddressName = address.AddressText,
                        Source = "FB",
                        Type = "Adress"
                    }));

                await Task.WhenAll(byggrTasks);
                var byggrCases = (await Task.WhenAll(byggrTasks.Where(task => task.Status == TaskStatus.RanToCompletion)).ConfigureAwait(false))
                    .Where(x => x != null);
                foreach (var byggrCase in byggrCases)
                {
                    searchResults.Add(new SearchResult
                    {
                        DisplayName = byggrCase.CaseId,
                        Value = byggrCase.CaseId,
                        Source = "ByggR",
                        Type = "Ärende",
                        CaseSourceId = byggrCase.CaseSourceId
                    });
                }

                await Task.WhenAll(ecosTasks);
                var ecosCases = (await Task.WhenAll(ecosTasks.Where(task => task.Status == TaskStatus.RanToCompletion)).ConfigureAwait(false))
                    .Where(x => x != null);
                foreach (var ecosCase in ecosCases)
                {
                    searchResults.Add(new SearchResult
                    {
                        DisplayName = ecosCase.Dnr,
                        Value = ecosCase.CaseId,
                        Source = "Ecos",
                        Type = "Ärende",
                        CaseSourceId = ecosCase.CaseSourceId
                    });
                }
            }

            if (query != null && query.Length >= 1 && int.TryParse(query, out _))
            {
                var config = _context.Configs.Include(x => x.AgsConfigs).First(x => x.Id == configId);
                var agsTasks = new List<Task<VisaRService.Contracts.Case>>();

                try
                {
                    foreach (var agsConfig in config.AgsConfigs)
                    {
                        var agsProxy = _proxyService.GetProxy(CaseSource.AGS, agsConfig.Id);
                        agsTasks.Add(agsProxy.GetCase(query));
                    }
                    await Task.WhenAll(agsTasks);
                }
                catch
                {
                    // ignored
                }

                var agsCases = (await Task.WhenAll(agsTasks.Where(task => task.Status == TaskStatus.RanToCompletion)).ConfigureAwait(false))
                    .Where(x => x != null);
                foreach (var agsCase in agsCases)
                {
                    searchResults.Add(new SearchResult
                    {
                        DisplayName = agsCase.CaseId,
                        Value = agsCase.CaseId,
                        Source = "AGS",
                        Type = "Ärende",
                        CaseSourceId = agsCase.CaseSourceId
                    });
                }
            }

            if (query != null && query.Length >= 3)
            {
                var config = _context.Configs.Include(x => x.IipaxConfigs).First(x => x.Id == configId);
                var iipaxTasks = new List<Task<VisaRService.Contracts.Case>>();

                try
                {
                    foreach (var iipaxConfig in config.IipaxConfigs)
                    {
                        var iipaxProxy = _proxyService.GetProxy(CaseSource.iipax, iipaxConfig.Id);
                        iipaxTasks.Add(iipaxProxy.SearchCase(query));
                    }
                    await Task.WhenAll(iipaxTasks);
                }
                catch
                {
                    // ignored
                }

                var iipaxCases = (await Task.WhenAll(iipaxTasks.Where(task => task.Status == TaskStatus.RanToCompletion)).ConfigureAwait(false))
                    .Where(x => x != null);
                foreach (var iipaxCase in iipaxCases)
                {
                    searchResults.Add(new SearchResult
                    {
                        DisplayName = iipaxCase.Title,
                        Value = iipaxCase.CaseId,
                        Source = "iipax",
                        Type = "Ärende",
                        CaseSourceId = iipaxCase.CaseSourceId
                    });
                }
            }

            return searchResults.Take(10).ToArray();
        }

        public class SearchResult
        {
            public string EstateName { get; set; }
            public string AddressName { get; set; }
            public string DisplayName { get; set; }
            public string Source { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
            public Guid CaseSourceId { get; set; }
        }
    }
}
