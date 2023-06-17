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
    public class DoctorPatientRepository : IDoctorPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorPatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public DoctorPatient Add(DoctorPatient doctorPatient)
        {
            _context.DoctorPatients.Add(doctorPatient);
            _context.SaveChanges();
            return doctorPatient;
        }
        public bool Delete(int doctorId, int patientId)
        {
            DoctorPatient deleteDoctorPatient = _context.DoctorPatients.Where(x => x.DoctorId == doctorId && x.PatientId == patientId).FirstOrDefault();
            _context.DoctorPatients.Remove(deleteDoctorPatient);
            _context.SaveChanges();
            return true;

        }
    }
}
