using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Sokigo.SBWebb.ApplicationServices;

namespace Reflex.Services
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {

    }

    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {

        private readonly IUserUtils _userUtils;
        private readonly IApplicationPermissions<ReflexApplication> _applicationPermissions;
        public IsAdminHandler(IUserUtils userUtils, IApplicationPermissions<ReflexApplication> applicationPermissions)
        {
            _userUtils = userUtils;
            _applicationPermissions = applicationPermissions;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            if (context.Resource is not HttpContext httpContext)
                return Task.CompletedTask;

            context.Succeed(requirement);

            var tmp = _userUtils.CurrentUser.Claims;
            var tmp2 = _applicationPermissions.HasPermission("IsAdmin");            

            var isAdmin = context.User.HasClaim(x => x.Value == "Admin");
            if (isAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}