using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;
using Sokigo.SBWebb.ApplicationServices;

namespace Reflex.Controllers
{
    //[Authorize(Policy = Policies.IsAdmin)]
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserSettingsController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserUtils _userUtils;
        private readonly ApplicationDbContext _applicationDbContext;

        //public UserSettingsController(IUserUtils userUtils)
        public UserSettingsController(IUserUtils userUtils, ApplicationDbContext applicationDbContext)
        {
            _userUtils = userUtils;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<UserSettings> GetUserSettings()
        {
            //var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;            
            //var user = await _userManager.FindByIdAsync(id);

            var id = _userUtils.CurrentUser.Id;
            var user = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Id == id);

            return new UserSettings { DefaultConfigId = user?.DefaultConfigId ?? null, DefaultTab = user?.DefaultTab ?? Tab.Cases };
        }

        [HttpPut]
        public async Task<UserSettings> UpdateUserSettings(UserSettings userSettings)
        {
            //var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = await _userManager.FindByIdAsync(id);

            var id = _userUtils.CurrentUser.Id;
            var user = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            user.DefaultTab = userSettings.DefaultTab;
            user.DefaultConfigId = userSettings.DefaultConfigId;
            _applicationDbContext.Update(user);
            await _applicationDbContext.SaveChangesAsync();
            return userSettings;
        }

        public class UserSettings
        {
            public Tab DefaultTab { get; set; }
            public Guid? DefaultConfigId { get; set; }
        }
    }
}
