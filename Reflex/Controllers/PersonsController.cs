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
    [Produces("application/json")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IRepository _repository;

        public PersonsController(ILogger<PersonsController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPersonsByRadius(string estateId, Guid configId, string distance = "0")
        {
            var persons = new List<Person>();
            if (string.IsNullOrEmpty(estateId))
                return persons;

            var fbProxy = _repository.GetFbProxy(configId);
            var pos = await fbProxy.GetEstatePosition(estateId);
            var fnrs = await fbProxy.GetFnrsFromPosition(pos.NorthingKoordinat, pos.EastingKoordinat, "3006", distance);
            foreach (var fnr in fnrs)
            {
                var estate = await fbProxy.GetEstate(fnr);
                var kidPersons = await fbProxy.KidPersonsByFnr(fnr);
                persons.AddRange(kidPersons.Select(p => new Person
                {
                    Firstname = p?.Firstname ?? "NAMN SAKNAS",
                    Familyname = p?.Familyname,
                    Sex = p?.Sex,
                    Age = p?.Age,
                    Address = p?.Address,
                    PostalArea = p?.PostalArea,
                    EstateName = estate.EstateName
                }));
            }

            return persons;
        }
    }

    public class Person
    {
        public string Firstname { get; set; }
        public string Familyname { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string PostalArea { get; set; }
        public string EstateName { get; set; }
    }
}
