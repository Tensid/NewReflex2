using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Reflex.Services
{
    public class HasConfigPermissionRequirement : IAuthorizationRequirement
    {

    }

    public class HasConfigPermissionHandler : AuthorizationHandler<HasConfigPermissionRequirement>
    {
        public HasConfigPermissionHandler()
        {

        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasConfigPermissionRequirement requirement)
        {
            if (context.Resource is not HttpContext httpContext)
                return Task.CompletedTask;

            var isAdmin = context.User.HasClaim(x => x.Value == "Admin");
            if (isAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var endpoint = httpContext.GetEndpoint();
            var configId = httpContext.Request.Query["configId"];

            var hasPermission = context.User.HasClaim(x => x.Value == configId);

            if (hasPermission)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}