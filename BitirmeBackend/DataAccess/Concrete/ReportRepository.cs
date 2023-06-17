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
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Report Add(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges(); 
            return report;
        }

        public bool Delete(int id)
        {
            var deleteReport = GetById(id);
            _context.Reports.Remove(deleteReport);
            _context.SaveChanges();
            return true;
            
        }

        public List<Report> GetAll()
        {
            try
            {
                return _context.Reports.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Report GetById(int id)
        {
            try
            {
                Report report =_context.Reports.Find(id);
                if (report == null)
                {
                    throw new EntityNotFoundException("Report not found with id "+id.ToString()+" !");
                }
                return report;
            }
            catch (Exception exception) { throw exception; }
        }

        public Report Update(Report report)
        {
            using (var context = new ApplicationDbContext()) {
                try
                {
                    context.Reports.Update(report);
                    context.SaveChanges();
                    return report;
                }
                catch (Exception exception) { throw exception; }
            }
            
        }
    }
}
