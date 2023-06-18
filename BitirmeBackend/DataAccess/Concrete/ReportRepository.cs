using DataAccess.Abstract;
using Entities.Modals;
using Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Report>> GetByPatientId(int patientId)
        {
            try
            {
                var reports = await _context.Reports.Where(x => x.PatientId.Equals(patientId)).ToListAsync();
                if (reports == null)
                {
                    throw new EntityNotFoundException($"Reports not found with patient id {patientId}!");
                }
                foreach (var report in reports)
                {
                    report.Doctor = _context.Doctors.Find(report.DoctorId);
                }
                return reports;
            }
            catch (Exception exception) { throw exception; }
        }
    }
}
