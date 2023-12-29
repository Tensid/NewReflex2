using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;
using Sokigo.SBWebb.ApplicationServices;

namespace Reflex.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[UseSystemTextJson]
    //[Produces("application/json")]
    public class ConfigsController : ControllerBase
    {
        private readonly ILogger<ConfigsController> _logger;
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserUtils _userUtils;

        public ConfigsController(ILogger<ConfigsController> logger, IRepository repository, ApplicationDbContext context, IUserUtils userUtils)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
            //_userManager = userManager;
            _userUtils = userUtils;
        }

        [HttpGet]
        [UseSystemTextJson]
        //[Produces("application/json")]
        [Authorize(Policy = Policies.IsAdmin)]
        [Authorize(Policy = Policies.HasConfigPermission)]
        public async Task<IEnumerable<Config>> GetConfigs()
        //public async Task<IActionResult> GetConfigs()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = await _userManager.FindByIdAsync(id);
            var user = _userUtils.CurrentUser;

            var configClaims = User.Claims.Where(x => x.Type == "config");
            //var isAdmin = (await _userManager.GetRolesAsync(user)).Contains("Admin");            

            var isAdmin = true;

            var result = _repository.GetConfigs().Where(x => isAdmin || configClaims.Any(y => y.Value == x.Id.ToString())).Select(x => new Config
            {
                Description = x.Description,
                Id = x.Id,
                Map = x.Map,
                Name = x.Name,
                Tabs = x.Tabs
            });
            return result;
            //return Ok(result);
            //return new JsonResult(result, new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    // Other JSON formatting options specific to this action
            //});

            //return new SystemTextJsonResult(result, new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    // Other JSON formatting options specific to this action
            //});
        }

        public class SystemTextJsonResult : IActionResult
        {
            private readonly object _value;
            private readonly JsonSerializerOptions _jsonSerializerOptions;

            public SystemTextJsonResult(object value, JsonSerializerOptions jsonSerializerOptions = null)
            {
                _value = value;
                _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
            }

            public async Task ExecuteResultAsync(ActionContext context)
            {
                var response = context.HttpContext.Response;
                response.ContentType = "application/json";
                if (_value != null)
                {
                    await JsonSerializer.SerializeAsync(response.Body, _value, _value.GetType(), _jsonSerializerOptions);
                }
            }
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpGet("formData/{id}")]
        [UseSystemTextJson]
        public ConfigFormData GetForm(Guid id)
        {
            var formData = _context.Configs.Where(x => x.Id == id).Include(x => x.AgsConfigs).Include(x => x.ByggrConfigs).Include(x => x.EcosConfigs).Include(x => x.IipaxConfigs).ToList().Select(x =>
            {
                var caseSources = x.AgsConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.AGS }).ToList();
                caseSources.AddRange(x.ByggrConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.ByggR }));
                caseSources.AddRange(x.EcosConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.Ecos }));
                caseSources.AddRange(x.IipaxConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.iipax }));

                return new ConfigFormData
                {
                    CaseSources = caseSources,
                    Description = x.Description,
                    Id = x.Id,
                    Map = x.Map,
                    Name = x.Name,
                    Tabs = x.Tabs
                };
            }).FirstOrDefault();
            return formData;
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpDelete("{id}")]
        public void DeleteConfig(Guid id)
        {
            _repository.DeleteConfig(id);
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpGet("caseSourceOptions")]
        [UseSystemTextJson]
        public IEnumerable<CaseSourceOption> GetCaseSourceOptions()
        {
            var caseSourceOptions = _context.AgsConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.AGS }).ToList();
            caseSourceOptions.AddRange(_context.ByggrConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.ByggR }));
            caseSourceOptions.AddRange(_context.EcosConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.Ecos }));
            caseSourceOptions.AddRange(_context.IipaxConfigs.Select(y => new CaseSourceOption { Value = y.Id, Label = y.Name, CaseSource = CaseSource.iipax }));

            return caseSourceOptions.ToList();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPut]
        public void UpdateConfig(ConfigFormData formData)
        {
            _context.Configs.Update(new Config
            {
                Id = formData.Id,
                Name = formData.Name,
                Description = formData.Description,
                Map = formData.Map?.ToList() ?? null,
                Tabs = formData.Tabs?.ToList() ?? null
            });
            _context.SaveChanges();

            var config = _context.Configs.Include(p => p.AgsConfigs)
                .Include(p => p.ByggrConfigs).Include(p => p.EcosConfigs).Include(p => p.IipaxConfigs)
                .Single(p => p.Id == formData.Id);
            config.AgsConfigs.Clear();
            config.ByggrConfigs.Clear();
            config.EcosConfigs.Clear();
            config.IipaxConfigs.Clear();

            foreach (var option in formData.CaseSources ?? Enumerable.Empty<CaseSourceOption>())
            {
                if (option.CaseSource == CaseSource.AGS)
                {
                    var cfg = _context.Configs
                        .Include(p => p.AgsConfigs)
                        .Single(p => p.Id == formData.Id);

                    var agsConfig = _context.AgsConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.AgsConfigs.Add(agsConfig);
                }
                if (option.CaseSource == CaseSource.ByggR)
                {
                    var cfg = _context.Configs
                        .Include(p => p.ByggrConfigs)
                        .Single(p => p.Id == formData.Id);

                    var byggrConfig = _context.ByggrConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.ByggrConfigs.Add(byggrConfig);
                }
                if (option.CaseSource == CaseSource.Ecos)
                {
                    var cfg = _context.Configs
                        .Include(p => p.EcosConfigs)
                        .Single(p => p.Id == formData.Id);

                    var ecosConfig = _context.EcosConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.EcosConfigs.Add(ecosConfig);
                }
                if (option.CaseSource == CaseSource.iipax)
                {
                    var cfg = _context.Configs
                        .Include(p => p.IipaxConfigs)
                        .Single(p => p.Id == formData.Id);

                    var iipaxConfig = _context.IipaxConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.IipaxConfigs.Add(iipaxConfig);
                }
            }
            _context.SaveChanges();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPost]
        public void CreateConfig(ConfigFormData formData)
        {
            var id = Guid.NewGuid();
            _context.Configs.Add(new Config
            {
                Id = id,
                Name = formData.Name,
                Description = formData.Description,
                Map = formData.Map?.ToList() ?? null,
                Tabs = formData.Tabs?.ToList() ?? null
            });
            _context.SaveChanges();

            foreach (var option in formData.CaseSources)
            {
                if (option.CaseSource == CaseSource.AGS)
                {
                    var cfg = _context.Configs
                        .Include(p => p.AgsConfigs)
                        .Single(p => p.Id == id);

                    var agsConfig = _context.AgsConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.AgsConfigs.Add(agsConfig);
                    _context.SaveChanges();
                }
                if (option.CaseSource == CaseSource.ByggR)
                {
                    var cfg = _context.Configs
                        .Include(p => p.ByggrConfigs)
                        .Single(p => p.Id == id);

                    var byggrConfig = _context.ByggrConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.ByggrConfigs.Add(byggrConfig);
                    _context.SaveChanges();
                }
                if (option.CaseSource == CaseSource.Ecos)
                {
                    var cfg = _context.Configs
                        .Include(p => p.EcosConfigs)
                        .Single(p => p.Id == id);

                    var ecosConfig = _context.EcosConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.EcosConfigs.Add(ecosConfig);
                    _context.SaveChanges();
                }
                if (option.CaseSource == CaseSource.iipax)
                {
                    var cfg = _context.Configs
                        .Include(p => p.IipaxConfigs)
                        .Single(p => p.Id == id);

                    var iipaxConfig = _context.IipaxConfigs
                        .Single(p => p.Id == option.Value);

                    cfg.IipaxConfigs.Add(iipaxConfig);
                    _context.SaveChanges();
                }
            }
        }
    }

    public class ConfigFormData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<string> Map { get; set; }
        public virtual IEnumerable<Tab> Tabs { get; set; }        
        public virtual IEnumerable<CaseSourceOption> CaseSources { get; set; }
    }

    public class CaseSourceOption
    {
        public Guid Value { get; set; }
        public string Label { get; set; }        
        public CaseSource CaseSource { get; set; }
    }
}
