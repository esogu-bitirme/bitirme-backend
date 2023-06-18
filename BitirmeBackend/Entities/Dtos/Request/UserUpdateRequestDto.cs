using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Request
{
    public class UserUpdateRequestDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
