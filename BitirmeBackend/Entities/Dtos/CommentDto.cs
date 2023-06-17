using Entities.Dtos.Response;
using Entities.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Dtos
{
    public class CommentDto
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public int ReportId { get; set; }

    }
}
