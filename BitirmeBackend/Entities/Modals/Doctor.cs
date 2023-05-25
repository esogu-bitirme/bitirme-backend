using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities
{
    public class Doctor
    {
        [Key] 
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [Index(IsUnique = true)]
        public int Tckn { get; set; }

        [Index(IsUnique = true)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OfficeNo { get; set; }
        public string Branch { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}
