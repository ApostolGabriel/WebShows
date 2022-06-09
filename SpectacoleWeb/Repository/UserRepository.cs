using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SpectacoleWebContext context) : base(context)
        {
        }
    }
}
