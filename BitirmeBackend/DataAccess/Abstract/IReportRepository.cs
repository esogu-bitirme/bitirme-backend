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
        public List<Report> GetAll();
        public Report GetById(int id);
        public Report Add(Report report);
        public Report Update(Report report);
        public bool Delete(int id);

    }
}
