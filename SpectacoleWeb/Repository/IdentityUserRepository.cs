using Microsoft.AspNetCore.Identity;
using SpectacoleWeb.Areas.Identity.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Repository
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        protected readonly SpectacoleWebIdentityDbContext _context;

        public IdentityUserRepository(SpectacoleWebIdentityDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ICollection<IdentityUserRole<string>> GetUserRoles()
        {
            return _context.UserRoles.ToList();
        }
    }
}
