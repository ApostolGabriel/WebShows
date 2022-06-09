using SpectacoleWeb.Models;

namespace SpectacoleWeb.Business_Logic
{
    public class ShowService
    {
        public IUnitOfWork _unitOfWork;

        public ShowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Show>> Get()
        {
            return await _unitOfWork.Shows.GetAll();
        }

        public async Task<Show> GetById(int id)
        {

            return await _unitOfWork.Shows.Get(id);
        }

        public async Task Add(Show show)
        {
            await _unitOfWork.Shows.Add(show);
        }

        public async void Update(Show show)
        {
            _unitOfWork.Shows.Update(show);
        }

        public async void Delete(Show show)
        {
            _unitOfWork.Shows.Delete(show);
        }

        public async void Delete(int id)
        {
            var show = await _unitOfWork.Shows.Get(id);
            if (show != null)
            {
                _unitOfWork.Shows.Delete(show);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
