using Business.Abstract;
using Entities.Modals;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ReportService : IReportService
    {
        private IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository) {
            _reportRepository = reportRepository;
        }
        public Report Add(Report report)
        {
            report.CreateDate = DateTime.Now;
            report.UpdateDate = DateTime.Now;
            return _reportRepository.Add(report);
        }

        public bool Delete(int id)
        {
            return _reportRepository.Delete(id);
        }

        public List<Report> GetAll()
        {
            return _reportRepository.GetAll();    
        }

        public Report GetById(int id)
        {
            return _reportRepository.GetById(id);
        }

        public Report Update(Report report)
        {
            report.UpdateDate = DateTime.Now;
            Report currentReport = _reportRepository.GetById(report.Id);
            report.CreateDate = currentReport.CreateDate;
            return _reportRepository.Update(report);
        }

        public async Task<List<Report>> GetByPatientId(int patientId)
        {
            return await _reportRepository.GetByPatientId(patientId);
        }
    }
}
