using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Repository
{
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        public ShowRepository(SpectacoleWebContext context) : base(context)
        {
        }

        public IEnumerable<Show> GetShowsByTitle(string Title)
        {
            try
            {
                return _context.Show.Where(x => x.Title == Title).ToList();
            }
            catch (ArgumentNullException)
            {
                throw new Exception("ArgumentNull");
            }
        }
    }
}
