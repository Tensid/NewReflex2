using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Reflex.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Reflex.Services
{
    public class HasCaseSourcePermissionRequirement : IAuthorizationRequirement
    {

    }

    public class HasCaseSourcePermissionHandler : AuthorizationHandler<HasCaseSourcePermissionRequirement>
    {
        private readonly ApplicationDbContext _context;

        public HasCaseSourcePermissionHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasCaseSourcePermissionRequirement requirement)
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

            var endpoint = httpContext.GetEndpoint();
            var configId = httpContext.Request.Query["configId"].First().ToString();
            var caseSource = httpContext.Request.Query["caseSource"];
            var caseSourceId = httpContext.Request.Query["caseSourceId"].First().ToString();

            var hasConfigPermission = context.User.HasClaim(x => x.Value == configId);

            if (!hasConfigPermission)
                return Task.CompletedTask;

            var hasCaseSourcePermission = caseSource.ToString() switch
            {
                "AGS" => _context.Configs.Include(x => x.AgsConfigs).FirstOrDefault(x => x.Id.ToString() == configId).AgsConfigs.Any(x => x.Id.ToString() == caseSourceId),
                "ByggR" => _context.Configs.Include(x => x.ByggrConfigs).FirstOrDefault(x => x.Id.ToString() == configId).ByggrConfigs.Any(x => x.Id.ToString() == caseSourceId),
                "Ecos" => _context.Configs.Include(x => x.EcosConfigs).FirstOrDefault(x => x.Id.ToString() == configId).EcosConfigs.Any(x => x.Id.ToString() == caseSourceId),
                "iipax" => _context.Configs.Include(x => x.IipaxConfigs).FirstOrDefault(x => x.Id.ToString() == configId).IipaxConfigs.Any(x => x.Id.ToString() == caseSourceId),
                _ => false
            };

            if (hasCaseSourcePermission)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}