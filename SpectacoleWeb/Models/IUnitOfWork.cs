namespace SpectacoleWeb.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IShowRepository Shows { get; }
        ITicketRepository Tickets { get; }
        IUserRepository Users { get; }
        IIdentityUserRepository IdentityUsers { get; }
        Task<int> Complete();
    }
}
