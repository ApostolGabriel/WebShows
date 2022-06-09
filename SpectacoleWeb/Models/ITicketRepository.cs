namespace SpectacoleWeb.Models
{
    public interface ITicketRepository
    {
        Task<Ticket> Get(int id);
        Task<IEnumerable<Ticket>> GetAll();
        Task Add(Ticket entityTicket);

        List<Ticket> FindAll();

        Task<IEnumerable<Ticket>> GetTicketsByShow(string show);

    }
}
