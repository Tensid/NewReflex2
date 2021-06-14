using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reflex.Data.Models;
using Reflex.Services;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository _repository;

        public UsersController(ILogger<UsersController> logger, UserManager<ApplicationUser> userManager, IRepository repository)
        {
            _logger = logger;
            _userManager = userManager;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ReflexUser>> Get()
        {
            var users = _userManager.Users;
            var reflexUsers = new List<ReflexUser>();
            foreach (var applicationUser in users)
            {
                var roles = await _userManager.GetRolesAsync(applicationUser);

                var configPermissions = _userManager.GetClaimsAsync(applicationUser).Result.Where(x => x.Type == "config")
                    .Select(x => new ConfigPermission
                    {
                        Name = _repository.GetConfig(Guid.Parse(x.Value)).Name,
                        Id = x.Value
                    }).OrderBy(x => x.Name);

                reflexUsers.Add(
                    new ReflexUser
                    {
                        Id = applicationUser.Id,
                        UserName = applicationUser.UserName,
                        Roles = roles,
                        ConfigPermissions = configPermissions,
                        IsEmailConfirmed = applicationUser.EmailConfirmed
                    });
            }
            return reflexUsers;
        }

        [HttpPut("roles")]
        public async Task<IActionResult> UpdateRoles(IEnumerable<UpdateRolesRequest> requests)
        {
            foreach (var request in requests)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user != null)
                {
                    if (user.UserName != User.Identity.Name || (user.UserName == User.Identity.Name && requests.Count() == 1))
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        await _userManager.RemoveFromRolesAsync(user, roles);
                        var result = await _userManager.AddToRolesAsync(user, request.Roles);

                        if (result.Succeeded)
                            _logger.LogInformation($"Roller tilldelade till avändare med id '{user.Id}'.");
                        else
                            _logger.LogInformation($"Tilldelning av roller till användare med id '{user.Id}' misslyckades.");
                    }
                }
            }

            return NoContent();
        }

        [HttpPut("configPermissions")]
        public async Task<IActionResult> UpdateConfigPermissions(IEnumerable<UpdateConfigPermissionsRequest> requests)
        {
            foreach (var request in requests)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user != null)
                {
                    var claims = await _userManager.GetClaimsAsync(user);

                    await _userManager.RemoveClaimsAsync(user, claims.Where(claim => claim.Type == "config"));
                    await _userManager.AddClaimsAsync(user, request.ConfigPermissions
                        .Select(config => new Claim("config", config.Id)));
                    _logger.LogInformation($"Konfigurationsbehörigheter uppdaterade för användare med id '{user.Id}'.");
                }
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(IEnumerable<string> ids)
        {
            foreach (var id in ids)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    if (user.UserName != User.Identity.Name)
                    {
                        var result = await _userManager.DeleteAsync(user);

                        if (result.Succeeded)
                            _logger.LogInformation($"Användare borttagen med id '{user.Id}'.");
                        else
                            _logger.LogInformation($"Borttagning av användare med id '{user.Id}' misslyckades.");
                    }

                    if (user.UserName == User.Identity.Name && ids.Count() == 1)
                    {
                        var result = await _userManager.DeleteAsync(user);

                        if (result.Succeeded)
                            _logger.LogInformation($"Inloggad användare borttagen med id '{user.Id}'.");
                        else
                            _logger.LogInformation($"Borttagning av inloggad användare med id '{user.Id}' misslyckades.");
                    }
                }
            }

            return NoContent();
        }

        public class ReflexUser
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public IEnumerable<string> Roles { get; set; }
            public IEnumerable<ConfigPermission> ConfigPermissions { get; set; }
            public bool IsEmailConfirmed { get; set; }
        }

        public class ConfigPermission
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class UpdateConfigPermissionsRequest
        {
            public string UserId { get; set; }
            public IEnumerable<ConfigPermission> ConfigPermissions { get; set; }
        }

        public class UpdateRolesRequest
        {
            public string UserId { get; set; }
            public IEnumerable<string> Roles { get; set; }
        }
    }
}
