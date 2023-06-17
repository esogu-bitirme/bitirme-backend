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
    public interface IAuthService
    {
        public string generateToken(User user);

    }
}
