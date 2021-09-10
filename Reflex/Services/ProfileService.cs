using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Reflex.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Reflex.Services
{
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
            var nameClaims = context.Subject.FindAll(JwtClaimTypes.Name);
            var preferredUserNameClaims = context.Subject.FindAll(JwtClaimTypes.PreferredUserName);
            var user = await _userManager.GetUserAsync(context.Subject);
            var configClaims = (await _userManager.GetClaimsAsync(user)).Where(x => x.Type == "config");

            context.IssuedClaims.AddRange(roleClaims);
            context.IssuedClaims.AddRange(nameClaims);
            context.IssuedClaims.AddRange(preferredUserNameClaims);
            context.IssuedClaims.AddRange(configClaims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
