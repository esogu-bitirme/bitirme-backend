using Business.Abstract;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

            return user.Password == password;
        }
    }
}
