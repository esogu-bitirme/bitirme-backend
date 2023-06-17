using Entities.Enums;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Dtos.Request
{
    public class ReportUpdateRequestDto
    {
        int Id { get; set; }
        public Status Status { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }

    }
}
