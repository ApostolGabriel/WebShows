using SpectacoleWeb.Export;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Business_Logic
{
    public class TicketService
    {
        public readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _unitOfWork.Tickets.GetAll();
        }

        public async Task<Ticket> GetById(int id)
        {

            return await _unitOfWork.Tickets.Get(id);
        }

        public async Task Add(Ticket ticket)
        {
            try
            {
                Show show = _unitOfWork.Shows.GetShowsByTitle(ticket.Show).FirstOrDefault();
                if (show != null)
                {
                    if (show.Seats > 0)
                    {
                        await _unitOfWork.Tickets.Add(ticket);
                        show.Seats--;
                        _unitOfWork.Shows.Update(show);
                    }
                    else
                    {
                        throw new Exception("No more tickets");
                    }
                }
                else
                {
                    throw new Exception("Invalid show");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Argument null");
                throw;
            }
        }


        public async Task<IEnumerable<Ticket>?> GetByShowAndDate(string show, DateTime date1, DateTime date2)
        {
            var shows = await _unitOfWork.Shows.GetAll();

            foreach (var sh in shows)
            {
                if(sh.Title == show && sh.DateTime.CompareTo(date1) > 0 && sh.DateTime.CompareTo(date2) < 0)
                {

                    return await _unitOfWork.Tickets.GetTicketsByShow(sh.Title);
                }
            }

            return null;
        }

        public string Export(string type)
        {
            List<Ticket> list = _unitOfWork.Tickets.FindAll();
            Exporter<Ticket> exp = ExporterFactory<Ticket>.Create(type);
            return exp.Export(list);
        }
    }
}
