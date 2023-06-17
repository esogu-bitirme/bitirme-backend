using AutoMapper;
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
using Microsoft.AspNetCore.Authorization;
using Entities.Enums;
using Microsoft.Net.Http.Headers;
using Microsoft.SqlServer.Server;

namespace API.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;
        public PatientController(IMapper mapper, IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            try
            {
                var records = _mapper.Map<List<PatientResponseDto>>(_patientService.GetAll());
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            try
            {
                var record = _mapper.Map<PatientResponseDto>(_patientService.GetById(id));
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

        [Authorize(Roles = "DOCTOR")]
        [HttpGet("doctor")]
        public IActionResult GetPatientsWithDoctorId()
        {
            try
            {
                var userId = HttpContext.User.FindFirst("userId")?.Value;
                if (userId is null)
                    throw new EntityNotFoundException("User id not found within http context!");

                int userIdInt = int.Parse(userId);

                List<Patient> patients = _patientService.GetByDoctorUserId(userIdInt);
                var records = _mapper.Map<List<PatientResponseDto>>(patients);
                return Ok(records);
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
        public IActionResult AddPatient(PatientRequestDto patient)
        {
            try
            {
                var patientRequest = _mapper.Map<Patient>(patient);
                Patient patientResponse = _patientService.Add(patientRequest);
                PatientResponseDto patientResponseDto = _mapper.Map<PatientResponseDto>(patientResponse);
                return Ok(patientResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                _patientService.Delete(id);
                return Ok("Patient successfully deleted with id " + id + "!");
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
        public IActionResult UpdatePatient(PatientUpdateRequestDto patient)
        {
            try
            {
                var patientRequest = _mapper.Map<Patient>(patient);
                Patient patientResponse = _patientService.Update(patientRequest);
                PatientResponseDto updatedPatient = _mapper.Map<PatientResponseDto>(patientResponse);
                return Ok(updatedPatient);
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