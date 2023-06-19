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
    public interface IPatientRepository
    {
        public List<Patient> GetAll();
        public Patient GetById(int id);
        public Patient GetByUserId(int userId);
        public Patient GetByTckn(string tckn);
        public Patient Add(Patient patient);
        public Patient Update(Patient patient);
        public bool Delete(int id);
        public List<Patient> GetByDoctorUserId(int doctorUserId);

    }
}
