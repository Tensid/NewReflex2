using System;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactSettingsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ContactSettingsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public JsonDocument GetContactSettings()
        {
            var file = Path.Combine(_env.ContentRootPath, "", "miscSettings.json");
            return JsonDocument.Parse(System.IO.File.ReadAllText(file).Replace(Environment.NewLine, ""));
        }
    }
}
