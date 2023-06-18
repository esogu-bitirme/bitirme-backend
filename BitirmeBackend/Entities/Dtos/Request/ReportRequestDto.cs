using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.Response;

namespace Entities.Dtos.Request
{
    public class ReportRequestDto
    {
        public Status Status { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
