using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Response
{
    public class UserResponseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }

    }
}
