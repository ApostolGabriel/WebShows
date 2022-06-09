using Microsoft.AspNetCore.Identity;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Business_Logic
{
    public class IdentityUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IdentityUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _unitOfWork.IdentityUsers.GetUsers();
        }

        public ICollection<IdentityUserRole<string>> GetUserRoles()
        {
            return _unitOfWork.IdentityUsers.GetUserRoles();
        }
    }
}
