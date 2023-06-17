using Entities.Modals;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommentRepository
    {
        public List<Comment> GetAll();
        public Comment GetById(int id);
        public List<Comment> GetAllByReportId(int reportId);
        public Comment Add(Comment comment);
        public Comment Update(Comment comment);
        public bool Delete(int id);

    }
}
