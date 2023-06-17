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
    }
}
