using Microsoft.EntityFrameworkCore;
using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Repository
{
    public class TicketRepository : ITicketRepository
    {
        protected readonly SpectacoleWebContext _context;

        public TicketRepository(SpectacoleWebContext context)
        {
            _context = context;
        }

        public async Task Add(Ticket entityTicket)
        {
            await _context.Ticket.AddAsync(entityTicket);
        }

        public async Task<Ticket> Get(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Ticket.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByShow(string show)
        {
            return await _context.Ticket.Where(t => t.Show == show).ToListAsync();
        }

        

        public List<Ticket> FindAll()
        {
            return _context.Ticket.ToList();
        }
    }
}
