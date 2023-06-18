using Business.Abstract;
using Entities.Modals;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly SecurityService _securityService;

        public UserService(IUserRepository userRepository, SecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }
        public User Add(User user)
        {
            string hashedPassword = _securityService.HashPassword(user.Password);
            user.Password= hashedPassword;
            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            return _userRepository.Add(user);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();    
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByEmail(string username)
        {
            return _userRepository.GetByEmail(username);
        }

        public User Update(User user)
        {
            user.UpdateDate = DateTime.Now;
            User currentUser = _userRepository.GetById(user.Id);
            user.CreateDate = currentUser.CreateDate;
            return _userRepository.Update(user);
        }

        public bool CheckPassword(string email,string password)
        {
            User user = _userRepository.GetByEmail(email);
            if (user == null) {
                throw new Exception("User not found with email "+email+" !");
            }

            return user.Password == _securityService.HashPassword(password);
        }
    }
}
