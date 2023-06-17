﻿using Business.Abstract;
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
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public Doctor Add(Doctor doctor)
        {
            doctor.CreateDate = DateTime.Now;
            doctor.UpdateDate = DateTime.Now;
            doctor.User.UserType = UserType.DOCTOR;
            return _doctorRepository.Add(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public Doctor Update(Doctor doctor)
        {
            doctor.UpdateDate = DateTime.Now;
            Doctor currentDoctor = _doctorRepository.GetById(doctor.Id);
            doctor.User = currentDoctor.User;
            doctor.CreateDate = currentDoctor.CreateDate;
            return _doctorRepository.Update(doctor);
        }
    }
}