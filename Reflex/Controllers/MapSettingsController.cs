using System;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Reflex.Services;

namespace Reflex.Controllers
{
    //[Authorize]
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
        [UseSystemTextJson]
        public JsonElement GetMapSettings()
        {
            var file = Path.Combine(_env.ContentRootPath, "", "mapSettings.json");
            return JsonDocument.Parse(System.IO.File.ReadAllText(file).Replace(Environment.NewLine, "")).RootElement;
        }

        [HttpGet("layers")]
        [UseSystemTextJson]
        public JsonDocument GetLayers()
        {
            var file = Path.Combine(_env.ContentRootPath, "", "layers.json");
            return JsonDocument.Parse(System.IO.File.ReadAllText(file).Replace(Environment.NewLine, ""));
        }


        //[HttpGet]
        //public IActionResult GetMapSettings()
        //{
        //    var file = Path.Combine(_env.ContentRootPath, "", "mapSettings.json");
        //    var tmp = System.IO.File.ReadAllText(file).Replace(Environment.NewLine, "");
        //    return Ok(tmp);
        //}

        //[HttpGet("layers")]
        //public IActionResult GetLayers()
        //{
        //    var file = Path.Combine(_env.ContentRootPath, "", "layers.json");
        //    var tmp = System.IO.File.ReadAllText(file).Replace(Environment.NewLine, "");
        //    return Ok(tmp);
        //}
    }
}
