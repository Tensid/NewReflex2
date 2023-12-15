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
using Sokigo.SBWebb.ApplicationServices;
using Sokigo.SBWebb.Authentication.Roles;
using Sokigo.SBWebb.Authentication;
using static Reflex.Controllers.UsersController;
using Reflex.Data;

namespace Reflex.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Policy = Policies.IsAdmin)]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepository _repository;

        public RolesController(ApplicationDbContext applicationDbContext, IRolesService rolesService, IRepository repository)
        {
            _applicationDbContext = applicationDbContext;
            _rolesService = rolesService;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Role> GetRoles()
        {

            //koppla  configclaims mot roller som med användare men roller istälölet
            


            var roles = _rolesService.GetRoles();
            var reflexUsers = new List<Role>();
            foreach (var role in roles)
            {
                //var roles = await _userManager.GetRolesAsync(applicationUser);
                var rolesClaims = _applicationDbContext.RolesClaims.ToList();
                var configPermissions = rolesClaims.Where(x => x.ClaimType == "config")
                    .Select(x => new ConfigPermission
                    {
                        Name = _repository.GetConfig(Guid.Parse(x.ClaimValue)).Name,
                        Id = x.ClaimValue
                    }).OrderBy(x => x.Name);

                reflexUsers.Add(
                    new Role
                    {
                        Id = role.Id,
                        Name = role.Name,
                        //UserName = applicationUser.UserName,
                        //Roles = roles,
                        ConfigPermissions = configPermissions,
                        //IsEmailConfirmed = applicationUser.EmailConfirmed
                    });
            }
            return reflexUsers;            
        }


        [HttpPut("configPermissions")]
        public IActionResult UpdateConfigPermissions(IEnumerable<UpdateConfigPermissionsRequest> requests)
        {
            foreach (var request in requests)
            {
                //var role = _rolesService.GetRoles().FirstOrDefault(x => x.Id == request.RoleId);
                var role = _rolesService.GetRoles().FirstOrDefault(x => x.Id == request.RoleId);
                if (role != null)
                {
                    //var claims = await _userManager.GetClaimsAsync(user);
                    var claims = _applicationDbContext.RolesClaims;
                    //await _userManager.RemoveClaimsAsync(user, claims.Where(claim => claim.Type == "config"));
                    _applicationDbContext.RolesClaims.RemoveRange(claims.Where(claim => claim.ClaimType == "config"));
                    _applicationDbContext.RolesClaims.AddRange(
                        request.ConfigPermissions.Select(config =>
                        new RolesClaim { Id = new Guid(),RoleId = role.Id, ClaimValue = config.Id, ClaimType = "config" })
                        );
                    //.RemoveRange(x => x.);
                    _applicationDbContext.SaveChanges();


                    //await _userManager.AddClaimsAsync(user, request.ConfigPermissions
                    //    .Select(config => new Claim("config", config.Id)));
                    //_logger.LogInformation($"Konfigurationsbehörigheter uppdaterade för användare med id '{user.Id}'.");
                }
            }
            return NoContent();
        }

        public class Role: ApplicationRole
        {
            public IEnumerable<ConfigPermission> ConfigPermissions { get; set; }
        }

        public class ConfigPermission
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class UpdateConfigPermissionsRequest
        {
            public Guid RoleId { get; set; }
            public IEnumerable<ConfigPermission> ConfigPermissions { get; set; }
        }       
    }
}
