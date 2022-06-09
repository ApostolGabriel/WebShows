using Microsoft.AspNetCore.Identity;

namespace SpectacoleWeb.Models
{
    public interface IIdentityUserRepository
    {
        ICollection<ApplicationUser> GetUsers();
        ICollection<IdentityUserRole<string>> GetUserRoles();
    }
}
