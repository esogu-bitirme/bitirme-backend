using Business.Abstract;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.Enums;

namespace Business.Concrete
{
    public class DoctorPatientService : IDoctorPatientService
    {
        private IDoctorPatientRepository _doctorPatientRepository;
        public DoctorPatientService(IDoctorPatientRepository doctorPatientRepository)
        {
            _doctorPatientRepository = doctorPatientRepository;
        }
        public bool Add(int doctorId, int patientId)
        {
            DoctorPatient doctorPatient = new DoctorPatient();
            doctorPatient.PatientId = patientId;
            doctorPatient.DoctorId = doctorId;
            doctorPatient.CreateDate = DateTime.Now;
            doctorPatient.UpdateDate = DateTime.Now;
            _doctorPatientRepository.Add(doctorPatient);
            return true;
        }

        public bool Delete(int doctorId, int patientId)
        {
            return _doctorPatientRepository.Delete(doctorId, patientId);
        }

    }
}
