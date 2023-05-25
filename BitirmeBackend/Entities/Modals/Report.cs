using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modals
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; }

        [MaxLength(50)]
        public string Diagnosis { get; set; }

        [MaxLength(200), AllowNull]
        public string Description { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
