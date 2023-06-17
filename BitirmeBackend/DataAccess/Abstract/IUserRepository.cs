using Entities.Modals;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User Add(User user);
        public User Update(User user);
        public bool Delete(int id);
        public User GetByUsername(string username);

    }
}
