using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data;

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

            if (query != null && query.Length >= 3)
            {
                var fbProxy = _repository.GetFbProxy(configId);
                var estateTask = fbProxy.SearchEstates(query);
                var addressTask = fbProxy.SearchAddresses(query);

                await Task.WhenAll(estateTask, addressTask);

                var estates = await estateTask;
                var addresses = await addressTask;
                searchResults.AddRange(estates
                    .OrderBy(estate => estate.EstateName)
                    .Select(estate => new SearchResult
                    {
                        EstateId = estate.EstateId,
                        EstateName = estate.EstateName
                    }));
                searchResults.AddRange(addresses
                    .OrderBy(address => address.AddressText)
                    .Select(address => new SearchResult
                    {
                        EstateName = address.AddressText,
                        EstateId = address.Estate.EstateId,
                        AddressName = address.AddressText
                    }));
            }

            return searchResults.Take(10).ToArray();
        }

        public class SearchResult
        {
            public string EstateId { get; set; }
            public string EstateName { get; set; }
            public string AddressName { get; set; }
        }
    }
}
