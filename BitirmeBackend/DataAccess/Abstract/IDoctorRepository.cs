using Entities.Modals;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Abstract
{
    public interface IDoctorRepository
    {
        public List<Doctor> GetAll();
        public Doctor GetById(int id);
        public Doctor Add(Doctor doctor);
        public Doctor Update(Doctor doctor);
        public bool Delete(int id);

    }
}
