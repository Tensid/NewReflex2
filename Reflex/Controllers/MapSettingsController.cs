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
    public class MapSettingsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public MapSettingsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public JsonElement GetMapSettings()
        {
            var file = Path.Combine(_env.ContentRootPath, "", "mapSettings.json");
            return JsonDocument.Parse(System.IO.File.ReadAllText(file).Replace(Environment.NewLine, "")).RootElement;
        }
    }
}
