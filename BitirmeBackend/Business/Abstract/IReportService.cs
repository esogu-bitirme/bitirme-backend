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
    public interface IReportService
    {
        List<Report> GetAll();

        Report GetById(int id);

        Report Add(Report report);

        Report Update(Report report);

        bool Delete(int id);

    }
}
