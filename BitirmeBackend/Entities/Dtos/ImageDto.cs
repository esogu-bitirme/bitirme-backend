using Entities.Dtos.Response;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace Entities.Dtos
{
    public class ImageDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int PatientId { get; set; }
        public int ReportId { get; set; }

    }
}
