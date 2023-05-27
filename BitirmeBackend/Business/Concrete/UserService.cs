using Business.Abstract;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public User Add(User user)
        {
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

        public User Update(User user)
        {
            user.UpdateDate = DateTime.Now;
            User currentUser = _userRepository.GetById(user.Id);
            user.CreateDate = currentUser.CreateDate;
            return _userRepository.Update(user);
        }
    }
}
