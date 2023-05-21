using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace DataAccess
{
    public class Doctor
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }

    }
}
