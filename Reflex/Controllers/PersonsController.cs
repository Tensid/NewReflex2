using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly FbService.IFbService _fbService;

        public PersonsController(ILogger<PersonsController> logger, FbService.IFbService fbService)
        {
            _logger = logger;
            _fbService = fbService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPersonsByRadius(string estateId, Guid configId, string distance = "0")
        {
            var persons = new List<Person>();
            if (string.IsNullOrEmpty(estateId))
                return persons;

            var pos = await _fbService.GetEstatePosition(estateId);
            var fnrs = await _fbService.GetFnrsFromPosition(pos.NorthingKoordinat, pos.EastingKoordinat, "3006", distance);
            foreach (var fnr in fnrs)
            {
                var estate = await _fbService.GetEstate(fnr);
                var kidPersons = await _fbService.KidPersonsByFnr(fnr);
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
