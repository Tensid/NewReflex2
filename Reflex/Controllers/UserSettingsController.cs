using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data.Models;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserSettingsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserSettingsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<UserSettings> GetUserSettings()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(id);

            return new UserSettings { DefaultConfigId = user?.DefaultConfigId ?? null, DefaultTab = user?.DefaultTab ?? Tab.Cases };
        }

        [HttpPut]
        public async Task<UserSettings> UpdateUserSettings(UserSettings userSettings)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(id);
            user.DefaultTab = userSettings.DefaultTab;
            user.DefaultConfigId = userSettings.DefaultConfigId;
            await _userManager.UpdateAsync(user);

            return userSettings;
        }

        public class UserSettings
        {
            public Tab DefaultTab { get; set; }
            public Guid? DefaultConfigId { get; set; }
        }
    }
}
