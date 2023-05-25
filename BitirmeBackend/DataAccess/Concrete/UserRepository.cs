using DataAccess.Abstract;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User Add(User user)
        {

            using(var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Users.Add(user);
                applicationDbContext.SaveChanges();
            }
            return user;
        }

        public bool Delete(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deleteUser = GetById(id);
                applicationDbContext.Users.Remove(deleteUser);
                applicationDbContext.SaveChanges();
                return true;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                using (var applicationDbContext = new ApplicationDbContext())
                {
                    return applicationDbContext.Users.ToList();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User GetById(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Users.Find(id);
            }
        }

        public User Update(User user)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Users.Update(user);
                applicationDbContext.SaveChanges();
                return user;
            }
        }
    }
}
