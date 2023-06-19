using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using Entities.Modals;
using Entities;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        List<Doctor> GetAll();

        Doctor GetById(int id);
        public Doctor GetByUserId(int userId);

        Doctor Add(Doctor doctor);

        Doctor Update(Doctor doctor);

        bool Delete(int id);
    }
}
