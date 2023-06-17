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
    public interface IDoctorPatientRepository
    {
        public DoctorPatient Add(DoctorPatient doctorPatient);
        public bool Delete(int doctorId,int patientId);

    }
}
