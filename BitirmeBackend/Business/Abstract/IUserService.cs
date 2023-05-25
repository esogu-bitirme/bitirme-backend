using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using Entities.Modals;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        User Add(User user);

        User Update(User user);

        bool Delete(int id);

    }
}
