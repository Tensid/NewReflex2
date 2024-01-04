using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Reflex.Data;
using Sokigo.SBWebb.ApplicationServices;

namespace Reflex.Services
{
    public class HasConfigPermissionRequirement : IAuthorizationRequirement
    {

    }

    public class HasConfigPermissionHandler : AuthorizationHandler<HasConfigPermissionRequirement>
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationPermissions<ReflexApplication> _applicationPermissions;
        private readonly IUserUtils _userUtils;

        public HasConfigPermissionHandler(ApplicationDbContext context, IApplicationPermissions<ReflexApplication> applicationPermissions, IUserUtils userUtils)
        {
            _context = context;
            _applicationPermissions = applicationPermissions;
            _userUtils = userUtils;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasConfigPermissionRequirement requirement)
        {
            if (context.Resource is not HttpContext httpContext)
                return Task.CompletedTask;

            context.Succeed(requirement);

            //var isAdmin = context.User.HasClaim(x => x.Value == "Admin");            
            var isAdmin = _applicationPermissions.HasPermission("IsAdmin");
            if (isAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var currentUserRoleClaims = _userUtils.CurrentUser.Claims.Where(x => x.Type == ClaimTypes.Role);
            var rolesClaims = _context.RolesClaims.ToList().Where(x => currentUserRoleClaims.Any(y => y.Value == x.RoleId.ToString()));

            var endpoint = httpContext.GetEndpoint();
            var configId = httpContext.Request.Query["configId"];
            var hasPermission = rolesClaims.Any(x => x.ClaimValue == configId);

            if (hasPermission)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}