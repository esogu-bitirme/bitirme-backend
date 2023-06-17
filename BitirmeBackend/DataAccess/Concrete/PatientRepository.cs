﻿using DataAccess.Abstract;
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
                //Patient patient = _context.Patients.Find(id);
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

        public Patient Update(Patient patient)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Patients.Update(patient);
                    context.SaveChanges();
                    return patient;
                }
                catch (Exception exception) { throw exception; }
            }

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