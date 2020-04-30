using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Models;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IRepository _repository;

        public SearchController(ILogger<SearchController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IEnumerable<SearchResult>> Get(string query, Guid configId)
        {
            var searchResults = new List<SearchResult>();
            var config = _repository.GetConfig(configId);

            if (query != null && query.Length >= 3)
            {
                var fbProxy = _repository.GetFbProxy(configId);
                var byggrProxy = _repository.GetProxy(CaseSource.ByggR, configId);

                var estateTask = fbProxy.SearchEstates(query);
                var addressTask = fbProxy.SearchAddresses(query);
                var byggrTask = (config?.CaseSources?.Contains(CaseSource.ByggR) ?? false) ? byggrProxy.GetCase(query) : null;

                try
                {
                    await Task.WhenAll(new Task[] { estateTask, addressTask, byggrTask }.Where(x => x != null));
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

                if (byggrTask?.IsCompletedSuccessfully ?? false)
                {
                    var awaitedByggr = await byggrTask;
                    if (awaitedByggr != null)
                        searchResults.Add(new SearchResult
                        {
                            DisplayName = awaitedByggr.CaseId,
                            Value = awaitedByggr.CaseId,
                            Source = "ByggR",
                            Type = "Ärende"
                        });
                }
            }
            if (query != null && query.Length >= 1 && int.TryParse(query, out _) && (config?.CaseSources?.Contains(CaseSource.AGS) ?? false))
            {
                var agsProxy = _repository.GetProxy(CaseSource.AGS, configId);
                var agsTask = agsProxy.GetCase(query);
                var awaitedAgs = await agsTask;
                if (awaitedAgs != null)
                    searchResults.Add(new SearchResult
                    {
                        DisplayName = awaitedAgs.CaseId,
                        Value = awaitedAgs.CaseId,
                        Source = "AGS",
                        Type = "Ärende"
                    });
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
        }
    }
}
