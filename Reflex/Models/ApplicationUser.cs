using Microsoft.AspNetCore.Identity;

namespace Reflex.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Tab DefaultTab { get; set; }
    }
}
