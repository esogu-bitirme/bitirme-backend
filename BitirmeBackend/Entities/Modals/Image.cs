using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modals
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200), AllowNull]
        public string Description { get; set; }
        public string Path { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Report Report { get; set; }
        public int ReportId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
