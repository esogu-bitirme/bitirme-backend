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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Doctor Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            try
            {
                List<Doctor> doctors = _context.Doctors.ToList();
                foreach (Doctor doctor in doctors)
                {
                    doctor.User = _context.Users.FirstOrDefault(u => u.Id == doctor.UserId);
                }
                return doctors;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Doctor GetById(int id)
        {
            try
            {
                //Doctor doctor = _context.Doctors.Find(id);
                Doctor doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
                if (doctor == null)
                {
                    throw new EntityNotFoundException("Doctor not found with id " + id.ToString() + " !");
                }
                doctor.User = _context.Users.FirstOrDefault(u => u.Id == doctor.UserId);
                return doctor;
            }
            catch (Exception exception) { throw exception; }
        }

        public Doctor GetByUserId(int userId)
        {
            try
            {
                Doctor doctor = _context.Doctors.FirstOrDefault(d => d.UserId == userId);
                if (doctor == null)
                {
                    throw new EntityNotFoundException("Doctor not found with id " + userId.ToString() + " !");
                }
                doctor.User = _context.Users.FirstOrDefault(u => u.Id == doctor.UserId);
                return doctor;
            }
            catch (Exception exception) { throw exception; }
        }
        public Doctor Update(Doctor doctor)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Doctors.Update(doctor);
                    context.SaveChanges();
                    return doctor;
                }
                catch (Exception exception) { throw exception; }
            }

        }
        public bool Delete(int id)
        {
            Doctor deleteDoctor = GetById(id);
            _context.Doctors.Remove(deleteDoctor);
            _context.SaveChanges();
            return true;

        }
    }
}
