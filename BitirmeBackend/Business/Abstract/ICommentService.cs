using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using Entities.Modals;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();

        Comment GetById(int id);

        public List<Comment> GetAllByReportId(int reportId);

        Comment Add(Comment comment);

        Comment Update(Comment comment);

        bool Delete(int id);

    }
}
