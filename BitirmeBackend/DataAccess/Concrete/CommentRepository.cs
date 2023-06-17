using DataAccess.Abstract;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using Entities.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Comment Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges(); 
            return comment;
        }

        public bool Delete(int id)
        {
            var deleteComment = GetById(id);
            _context.Comments.Remove(deleteComment);
            _context.SaveChanges();
            return true;
            
        }

        public List<Comment> GetAll()
        {
            try
            {
                return _context.Comments.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Comment GetById(int id)
        {
            try
            {
                Comment comment =_context.Comments.Find(id);
                if (comment == null)
                {
                    throw new EntityNotFoundException("Comment not found with id "+id.ToString()+" !");
                }
                return comment;
            }
            catch (Exception exception) { throw exception; }
        }

        public List<Comment> GetAllByReportId(int reportId)
        {
            try
            {
                List<Comment> commentList = _context.Comments.Where(x=>x.ReportId == reportId).ToList();
                return commentList;
            }
            catch (Exception exception) { throw exception; }
        }

        public Comment Update(Comment comment)
        {
            using (var context = new ApplicationDbContext()) {
                try
                {
                    context.Comments.Update(comment);
                    context.SaveChanges();
                    return comment;
                }
                catch (Exception exception) { throw exception; }
            }
            
        }
    }
}
