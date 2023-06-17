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
    public interface IReportRepository
    {
        List<Report> GetAll();
        Report GetById(int id);
        Report Add(Report report);
        Report Update(Report report);
        bool Delete(int id);
        Task<List<Report>> GetByPatientId(int patientId);
    }
}
