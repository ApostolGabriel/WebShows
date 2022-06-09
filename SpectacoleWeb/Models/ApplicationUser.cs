using Microsoft.AspNetCore.Identity;

namespace SpectacoleWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Name { get; set; }
    }
}
