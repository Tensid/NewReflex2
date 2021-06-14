using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data.Models;
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

        [HttpGet("fb")]
        public FbSettings GetFbSettings()
        {
            return _systemSettingsService.GetFbSettings();
        }

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

        [HttpPut("misc")]
        public void UpdateMiscSettings(MiscSettings miscSettings)
        {
            _systemSettingsService.UpdateMiscSettings(miscSettings);
        }

        [HttpGet("byggr")]
        public ByggrSettings GetByggrSettings()
        {
            return _systemSettingsService.GetByggrSettings();
        }

        [HttpPut("byggr")]
        public void UpdateByggrSettings(ByggrSettings settings)
        {
            _systemSettingsService.UpdateByggrSettings(settings);
        }

        [HttpGet("ags")]
        public AgsSettings GetAgsSettings()
        {
            return _systemSettingsService.GetAgsSettings();
        }

        [HttpPut("ags")]
        public void UpdateAgsSettings(AgsSettings settings)
        {
            _systemSettingsService.UpdateAgsSettings(settings);
        }

        [HttpGet("ecos")]
        public EcosSettings GetEcosSettings()
        {
            return _systemSettingsService.GetEcosSettings();
        }

        [HttpPut("ecos")]
        public void UpdateEcosSettings(EcosSettings settings)
        {
            _systemSettingsService.UpdateEcosSettings(settings);
        }
    }
}
