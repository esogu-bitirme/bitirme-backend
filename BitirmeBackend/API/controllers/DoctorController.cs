using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        private readonly IDoctorPatientService _doctorPatientService;
        private readonly IPatientService _patientService;
        public DoctorController(IMapper mapper, IDoctorService doctorService, IDoctorPatientService doctorPatientService, IPatientService patientService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
            _doctorPatientService = doctorPatientService;
            _patientService = patientService;
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

        [HttpPost("patient/{doctorId}/{patientId}")]
        public IActionResult AddRelationWithPatientId(int doctorId,int patientId)
        {
            try
            {
                return Ok(_doctorPatientService.Add(doctorId, patientId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("patient/tckn/{patientTckn}")]
        public IActionResult AddRelationWithPatientTckn(string patientTckn)
        {
            try
            {
                var userId = HttpContext.User.FindFirst("userId")?.Value;
                if (userId is null)
                    throw new EntityNotFoundException("User id not found within http context!");

                int userIdInt = int.Parse(userId);

                Patient patient = _patientService.GetByTckn(patientTckn);
                Doctor doctor = _doctorService.GetByUserId(userIdInt);
                return Ok(_doctorPatientService.Add(doctor.Id, patient.Id ));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("patient/{patientId}")]
        public IActionResult DeleteRelationWithPatientId(int patientId)
        {
            try
            {
                var userId = HttpContext.User.FindFirst("userId")?.Value;
                if (userId is null)
                    throw new EntityNotFoundException("User id not found within http context!");

                int userIdInt = int.Parse(userId);

                Doctor doctor = _doctorService.GetByUserId(userIdInt);
                return Ok(_doctorPatientService.Delete(doctor.Id,patientId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}