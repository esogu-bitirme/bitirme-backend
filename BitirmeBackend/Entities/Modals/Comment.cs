using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modals
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Message { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
        public Report Report { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
