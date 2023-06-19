﻿using System;
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
    public interface IPatientService
    {
        List<Patient> GetAll();

        Patient GetById(int id);
        Patient GetByUserId(int userId);
        public Patient GetByTckn(string tckn);
        Patient Add(Patient doctor);

        Patient Update(Patient doctor);

        bool Delete(int id);
        public List<Patient> GetByDoctorUserId(int doctorUserId);
    }
}
