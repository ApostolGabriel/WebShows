using Microsoft.AspNetCore.Identity;

namespace SpectacoleWeb.Models
{
    public class MyViewModel
    {
        public ICollection<ApplicationUser> Users;
        public ICollection<IdentityUserRole<string>> Roles;

        public MyViewModel(ICollection<ApplicationUser> users, ICollection<IdentityUserRole<string>> roles)
        {
            Users = users;
            Roles = roles;
        }
    }
}
