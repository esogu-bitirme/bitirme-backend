using AutoMapper;
using Business.Abstract;
using Entities.Dtos;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/report")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;
        private readonly IPatientService _patientService;
        public ReportController(IMapper mapper, IReportService reportService, IPatientService patientService)
        {
            _mapper = mapper;
            _reportService = reportService;
            _patientService = patientService;
        }

        [HttpGet]

        public IActionResult GetAllReports() {
            try
            {
                var records = _mapper.Map<List<ReportResponseDto>>(_reportService.GetAll());
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetReport(int id) {
            try
            {
                var record = _mapper.Map<ReportResponseDto>(_reportService.GetById(id));
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
        public IActionResult AddReport(ReportRequestDto report)
        {
            try
            {
                var reportRequest = _mapper.Map<Report>(report);
                Report reportResponse = _reportService.Add(reportRequest);
                ReportResponseDto reportResponseDto = _mapper.Map<ReportResponseDto>(reportResponse);
                return Ok(reportResponseDto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReport(int id)
        {
            try
            {
                _reportService.Delete(id);
                return Ok("Report successfully deleted with id "+id+"!");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateReport(ReportUpdateRequestDto report)
        {

            try
            {
                var reportRequest = _mapper.Map<Report>(report);
                Report reportResponse = _reportService.Update(reportRequest);
                ReportResponseDto updatedReport = _mapper.Map<ReportResponseDto>(reportResponse);
                return Ok(updatedReport);
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

        [HttpGet("patient/{patientId}")]
        [ProducesResponseType(typeof(ReportResponseDto), 200)]
        [ProducesResponseType(typeof(NoContentResult), 204)]
        [ProducesResponseType(typeof(int), 500)]
        public async Task<IActionResult> GetPatientReports(int patientId)
        {
            var patient = _patientService.GetById(patientId);
            var patientReports = await _reportService.GetByPatientId(patient.Id);

            if(!patientReports.Any())
                return NoContent();

            var mappedPatientReports = _mapper.Map<List<ReportResponseDto>>(patientReports);
            return Ok(mappedPatientReports);
        }

        [HttpGet("myreports")]
        [ProducesResponseType(typeof(ReportResponseDto), 200)]
        [ProducesResponseType(typeof(NoContentResult), 204)]
        [ProducesResponseType(typeof(int), 500)]
        public async Task<IActionResult> GetMyPatientReports()
        {
            var userId = HttpContext.User.FindFirst("userId")?.Value;
            if (userId is null)
                throw new EntityNotFoundException("User id not found within http context!");

            int userIdInt = int.Parse(userId);

            var patient = _patientService.GetByUserId(userIdInt);
            var patientReports = await _reportService.GetByPatientId(patient.Id);

            if (!patientReports.Any())
                return NoContent();

            var mappedPatientReports = _mapper.Map<List<ReportResponseDto>>(patientReports);
            return Ok(mappedPatientReports);
        }

    }
}
