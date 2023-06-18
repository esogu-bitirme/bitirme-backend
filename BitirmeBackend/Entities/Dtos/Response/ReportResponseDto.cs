using Entities.Enums;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace Entities.Dtos.Response
{
    public class ReportResponseDto
    {
        public Status Status { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public DoctorResponseDto Doctor { get; set; }
        public int PatientId { get; set; }

    }
}
