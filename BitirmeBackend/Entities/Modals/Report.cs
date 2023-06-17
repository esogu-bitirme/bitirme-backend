using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
