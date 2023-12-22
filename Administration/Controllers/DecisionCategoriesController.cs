using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Skolskjuts.API.Data;
//using SkolskjutsService.Abstractions;

namespace Administration.Controllers
{
    [Route("api/Administration/[controller]")]
    [ApiController]
    public class DecisionCategoriesController : ControllerBase
    {
        //private readonly ISkolskjutsService _skolskjutsService;
        //private const string BaseUrl = "Admin/DecisionCategories";

        //public DecisionCategoriesController(ISkolskjutsService skolskjutsService)
        //{
        //    _skolskjutsService = skolskjutsService;
        //}

        //[HttpGet("{year}")]
        //public Task<string> GetDecisionCategories(string year)
        //{
        //    return _skolskjutsService.GetStringAsyncWithJwt($"{BaseUrl}/{year}");
        //}       
    }
}
