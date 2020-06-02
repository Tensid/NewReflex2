using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<DocumentsController> _logger;
        private readonly IWebHostEnvironment _env;

        public DocumentsController(ILogger<DocumentsController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpGet("{filename}")]
        public IActionResult Get(string filename)
        {
            try
            {
                var file = Path.Combine(_env.ContentRootPath, "docs", filename);
                return File(System.IO.File.ReadAllBytes(file), "application/octet-stream", filename);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
