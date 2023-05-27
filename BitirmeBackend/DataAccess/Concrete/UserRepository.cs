using DataAccess.Abstract;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using Entities.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); 
            return user;
        }

        public bool Delete(int id)
        {
            var deleteUser = GetById(id);
            _context.Users.Remove(deleteUser);
            _context.SaveChanges();
            return true;
            
        }

        public List<User> GetAll()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User GetById(int id)
        {
            try
            {
                User user =_context.Users.Find(id);
                if (user == null)
                {
                    throw new EntityNotFoundException("User not found with id "+id.ToString()+" !");
                }
                return user;
            }
            catch (Exception exception) { throw exception; }
        }

        public User Update(User user)
        {
            using (var context = new ApplicationDbContext()) {
                try
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    return user;
                }
                catch (Exception exception) { throw exception; }
            }
            
        }
    }
}
