using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Reflex.Services
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {

    }

    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        public IsAdminHandler()
        {

        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            if (context.Resource is not HttpContext httpContext)
                return Task.CompletedTask;

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