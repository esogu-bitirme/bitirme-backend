﻿using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Request
{
    public class DoctorUpdateRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Tckn { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OfficeNo { get; set; }
        public string Branch { get; set; }

    }
}
