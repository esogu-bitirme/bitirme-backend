using Entities.Dtos.Request;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Dtos.Request
{
    public class DoctorRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Tckn { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OfficeNo { get; set; }
        public string Branch { get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public UserRequestDto User { get; set; }

    }
}
