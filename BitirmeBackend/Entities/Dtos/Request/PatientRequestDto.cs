using Entities.Dtos.Request;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Dtos.Request
{
    public class PatientRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tckn { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public UserRequestDto User { get; set; }

    }
}
