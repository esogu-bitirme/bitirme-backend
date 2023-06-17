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
    public interface IDoctorPatientService
    {
        bool Add(int doctorId,int patientId);
        bool Delete(int doctorId, int patientId);
    }
}
