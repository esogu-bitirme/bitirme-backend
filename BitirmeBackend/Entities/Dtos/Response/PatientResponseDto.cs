﻿using Entities.Dtos.Response;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Dtos.Response
{
    public class PatientResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tckn { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public UserResponseDto User { get; set; }

    }
}
