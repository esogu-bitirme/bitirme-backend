using DataAccess.Abstract;
using Entities;
using Entities.Exceptions;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Patient Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public List<Patient> GetAll()
        {
            try
            {
                List<Patient> patients = _context.Patients.ToList();
                foreach (Patient patient in patients)
                {
                    patient.User = _context.Users.FirstOrDefault(u => u.Id == patient.UserId);
                }
                return patients;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Patient GetById(int id)
        {
            try
            {
                Patient patient = _context.Patients.FirstOrDefault(d => d.Id == id);
                if (patient == null)
                {
                    throw new EntityNotFoundException("Patient not found with id " + id.ToString() + " !");
                }
                patient.User = _context.Users.FirstOrDefault(u => u.Id == patient.UserId);
                return patient;
            }
            catch (Exception exception) { throw exception; }
        }

        public Patient GetByUserId(int userId)
        {
            try
            {
                Patient patient = _context.Patients.FirstOrDefault(d => d.UserId == userId);
                if (patient == null)
                {
                    throw new EntityNotFoundException("Patient not found with id " + userId.ToString() + " !");
                }
                patient.User = _context.Users.FirstOrDefault(u => u.Id == patient.UserId);
                return patient;
            }
            catch (Exception exception) { throw exception; }
        }

        public Patient GetByTckn(string tckn)
        {
            try
            {
                Patient patient = _context.Patients.FirstOrDefault(d => d.Tckn == tckn);
                if (patient == null)
                {
                    throw new EntityNotFoundException("Patient not found with tckn " + tckn + " !");
                }
                patient.User = _context.Users.FirstOrDefault(u => u.Id == patient.UserId);
                return patient;
            }
            catch (Exception exception) { throw exception; }
        }

        public List<Patient> GetByDoctorUserId(int doctorUserId)
        {
            try
            {
                var doctor = _context.Doctors.FirstOrDefault(x=>x.UserId == doctorUserId);
                if (doctor == null)
                {
                    throw new EntityNotFoundException("Doctor not found with id " + doctorUserId.ToString() + " !");
                }

                List<DoctorPatient> relations = _context.DoctorPatients.Where(x => x.DoctorId == doctor.Id).ToList();
                List<Patient> patients = new List<Patient>();
                foreach (DoctorPatient rel in relations)
                {
                    Patient patient = _context.Patients.Find(rel.PatientId);
                    patient.User = _context.Users.Find(patient.UserId);
                    patients.Add(patient);
                }
                return patients;
            }
            catch (Exception exception) { throw exception; }
        }

        public Patient Update(Patient patient)
        {
            using var context = new ApplicationDbContext();
            try
            {
                context.Patients.Update(patient);
                context.SaveChanges();
                return patient;
            }
            catch (Exception exception) { throw exception; }

        }
        public bool Delete(int id)
        {
            Patient deletePatient = GetById(id);
            _context.Patients.Remove(deletePatient);
            _context.SaveChanges();
            return true;

        }
    }
}
