﻿using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Exceptions;
using Entities.Modals;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        public DoctorController(IMapper mapper, IDoctorService doctorService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            try
            {
                var records = _mapper.Map<List<DoctorResponseDto>>(_doctorService.GetAll());
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            try
            {
                var record = _mapper.Map<DoctorResponseDto>(_doctorService.GetById(id));
                return Ok(record);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorRequestDto doctor)
        {
            try
            {
                var doctorRequest = _mapper.Map<Doctor>(doctor);
                Doctor doctorResponse = _doctorService.Add(doctorRequest);
                DoctorResponseDto doctorResponseDto = _mapper.Map<DoctorResponseDto>(doctorResponse);
                return Ok(doctorResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                _doctorService.Delete(id);
                return Ok("Doctor successfully deleted with id " + id + "!");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorUpdateRequestDto doctor)
        {
            try
            {
                var doctorRequest = _mapper.Map<Doctor>(doctor);
                Doctor doctorResponse = _doctorService.Update(doctorRequest);
                DoctorResponseDto updatedDoctor = _mapper.Map<DoctorResponseDto>(doctorResponse);
                return Ok(updatedDoctor);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}