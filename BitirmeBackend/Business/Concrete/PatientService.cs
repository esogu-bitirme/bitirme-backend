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
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        private readonly SecurityService _securityService;
        public PatientService(IPatientRepository patientRepository, SecurityService securityService)
        {
            _patientRepository = patientRepository;
            _securityService = securityService;
        }
        public Patient Add(Patient patient)
        {
            patient.CreateDate = DateTime.Now;
            patient.UpdateDate = DateTime.Now;
            patient.User.CreateDate = DateTime.Now;
            patient.User.UpdateDate = DateTime.Now;
            patient.User.Password = _securityService.HashPassword(patient.User.Password);
            patient.User.UserType = UserType.PATIENT;
            return _patientRepository.Add(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public List<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient Update(Patient patient)
        {
            patient.UpdateDate = DateTime.Now;
            Patient currentPatient = _patientRepository.GetById(patient.Id);
            patient.User = currentPatient.User;
            patient.CreateDate = currentPatient.CreateDate;
            return _patientRepository.Update(patient);
        }

        public List<Patient> GetByDoctorUserId(int doctorUserId)
        {
            return _patientRepository.GetByDoctorUserId(doctorUserId);
        }
    }
}
