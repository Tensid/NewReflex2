using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SearchResult> Get(string query)
        {
            var searchResults = new List<SearchResult>
            {
             new SearchResult
            {
              EstateId = "1",
              EstateName = "RÖDA LYKTAN 2"
            },
             new SearchResult
            {
              EstateId = "2",
              EstateName = "RÖDA LYKTAN 3"
            },
             new SearchResult
            {
              EstateId = "3",
              EstateName = "RÖDA LYKTAN 4"
            },
             new SearchResult
            {
              EstateId = "3",
              EstateName = "FISKAREN 5"
            },
              new SearchResult
            {
              EstateId = "4",
              EstateName = "FISKAREN 1",
              AddressName = "Gatan 2"
            }
            };
            return searchResults.Where(x => x.EstateName.ToUpper().Contains(query ?? "", StringComparison.OrdinalIgnoreCase));
        }

        public class SearchResult
        {
            public string EstateId { get; set; }
            public string EstateName { get; set; }
            public string AddressName { get; set; }
        }
    }
}
