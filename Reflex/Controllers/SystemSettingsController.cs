using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data.Models;
using Reflex.Services;
using Reflex.SettingsService;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SystemSettingsController : ControllerBase
    {
        private readonly ILogger<SystemSettingsController> _logger;
        private readonly ISystemSettingsService _systemSettingsService;

        public SystemSettingsController(ILogger<SystemSettingsController> logger, ISystemSettingsService systemSettingsService)
        {
            _logger = logger;
            _systemSettingsService = systemSettingsService;
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpGet("fb")]
        public FbSettings GetFbSettings()
        {
            return _systemSettingsService.GetFbSettings();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPut("fb")]
        public void UpdateFbSettings(FbSettings fbSettings)
        {
            _systemSettingsService.UpdateFbSettings(fbSettings);
        }

        [HttpGet("fb-webb")]
        public FbWebbSettings GetFbWebbSettings()
        {
            return _systemSettingsService.GetFbWebbSettings();
        }

        [HttpGet("misc")]
        public MiscSettings GetMiscSettings()
        {
            return _systemSettingsService.GetMiscSettings();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPut("misc")]
        public void UpdateMiscSettings(MiscSettings miscSettings)
        {
            _systemSettingsService.UpdateMiscSettings(miscSettings);
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpGet("byggr")]
        public ByggrSettings GetByggrSettings()
        {
            return _systemSettingsService.GetByggrSettings();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPut("byggr")]
        public void UpdateByggrSettings(ByggrSettings settings)
        {
            _systemSettingsService.UpdateByggrSettings(settings);
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpGet("ags")]
        public AgsSettings GetAgsSettings()
        {
            return _systemSettingsService.GetAgsSettings();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPut("ags")]
        public void UpdateAgsSettings(AgsSettings settings)
        {
            _systemSettingsService.UpdateAgsSettings(settings);
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpGet("ecos")]
        public EcosSettings GetEcosSettings()
        {
            return _systemSettingsService.GetEcosSettings();
        }

        [Authorize(Policy = Policies.IsAdmin)]
        [HttpPut("ecos")]
        public void UpdateEcosSettings(EcosSettings settings)
        {
            _systemSettingsService.UpdateEcosSettings(settings);
        }
    }
}
