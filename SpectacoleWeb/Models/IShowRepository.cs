namespace SpectacoleWeb.Models
{
    public interface IShowRepository : IGenericRepository<Show>
    {
        public IEnumerable<Show> GetShowsByTitle(string Title);
    }
}
