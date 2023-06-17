using Entities.Dtos.Response;
using Entities.Enums;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace Entities.Dtos
{
    public class ReportDto
    {
        public Status Status { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
