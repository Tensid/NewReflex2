using System.Linq;
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
        private readonly IUserUtils _userUtils;
        public HasConfigPermissionHandler(ApplicationDbContext context, IUserUtils userUtils)
        {
            _context = context;
            _userUtils = userUtils;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasConfigPermissionRequirement requirement)
        {
            if (context.Resource is not HttpContext httpContext)
                return Task.CompletedTask;

            context.Succeed(requirement);

            var isAdmin = context.User.HasClaim(x => x.Value == "Admin");
            if (isAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            //_userUtils.CurrentUser.Claims
            

            var endpoint = httpContext.GetEndpoint();
            var configId = httpContext.Request.Query["configId"];

            var hasPermission = context.User.HasClaim(x => x.Value == configId);

            //_context.RolesClaims.Any(x=>x.)

            if (hasPermission)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}