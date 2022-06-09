using SpectacoleWeb.Models;

namespace SpectacoleWeb.Business_Logic
{
    public class UserService
    {
        public IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _unitOfWork.Users.GetAll();
        }

        public async Task<User> GetById(int id)
        {

            return await _unitOfWork.Users.Get(id);
        }

        public async Task Add(User user)
        {
            user.Password = MD5Encryption.GetMd5Hash(user.Password);
            await _unitOfWork.Users.Add(user);
        }

        public async void Update(User user)
        {
            user.Password = MD5Encryption.GetMd5Hash(user.Password);
            _unitOfWork.Users.Update(user);
        }

        public async void Delete(User user)
        {
            user.Password = MD5Encryption.GetMd5Hash(user.Password);
            _unitOfWork.Users.Delete(user);
        }
    }
}
