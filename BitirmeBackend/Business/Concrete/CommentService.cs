using Business.Abstract;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.Concrete
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }
        public Comment Add(Comment comment)
        {
            comment.CreateDate = DateTime.Now;
            comment.UpdateDate = DateTime.Now;
            return _commentRepository.Add(comment);
        }

        public bool Delete(int id)
        {
            return _commentRepository.Delete(id);
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();    
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Comment> GetAllByReportId(int reportId)
        {
            return _commentRepository.GetAllByReportId(reportId);
        }

        public Comment Update(Comment comment)
        {
            comment.UpdateDate = DateTime.Now;
            Comment currentComment = _commentRepository.GetById(comment.Id);
            comment.CreateDate = currentComment.CreateDate;
            return _commentRepository.Update(comment);
        }
    }
}
