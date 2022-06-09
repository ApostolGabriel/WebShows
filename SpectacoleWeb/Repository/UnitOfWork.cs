using SpectacoleWeb.Areas.Identity.Data;
using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SpectacoleWebContext _context;
        private readonly SpectacoleWebIdentityDbContext _identityDbContext;
        public IShowRepository Shows { get; }
        public IUserRepository Users { get; }
        public ITicketRepository Tickets { get; }
        public IIdentityUserRepository IdentityUsers { get; }

        public UnitOfWork(SpectacoleWebContext context, SpectacoleWebIdentityDbContext identityContext)
        {
            _context = context;
            _identityDbContext = identityContext;  
            Shows = new ShowRepository(context);
            Users = new UserRepository(context);
            Tickets = new TicketRepository(context);
            IdentityUsers = new IdentityUserRepository(identityContext);
        }

        public UnitOfWork(SpectacoleWebContext context, SpectacoleWebIdentityDbContext identityContext, IShowRepository shows, IUserRepository users, ITicketRepository tickets, IIdentityUserRepository identityUserRepository)
        {
            _context = context;
            _identityDbContext = identityContext;
            Shows = shows;
            Users = users;
            Tickets = tickets;
            IdentityUsers = identityUserRepository;
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }


    }
}
