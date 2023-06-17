using AutoMapper;
using Business.Abstract;
using Entities.Dtos;
using Entities.Dtos.Request;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/report")]
    [ApiController]
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
                var records = _mapper.Map<List<ReportDto>>(_reportService.GetAll());
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
                var record = _mapper.Map<ReportDto>(_reportService.GetById(id));
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
        public IActionResult AddReport(ReportDto report)
        {
            try
            {
                var reportRequest = _mapper.Map<Report>(report);
                Report reportResponse = _reportService.Add(reportRequest);
                ReportDto reportResponseDto = _mapper.Map<ReportDto>(reportResponse);
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
                ReportDto updatedReport = _mapper.Map<ReportDto>(reportResponse);
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
        [ProducesResponseType(typeof(Report), 200)]
        [ProducesResponseType(typeof(NoContentResult), 204)]
        [ProducesResponseType(typeof(Exception), 500)]
        public async Task<IActionResult> GetPatientReports(int patientId)
        {
            var patient = _patientService.GetById(patientId);
            var patientReports = await _reportService.GetByPatientId(patient.Id);

            if(!patientReports.Any())
                return NoContent();

            var mappedPatientReports = _mapper.Map<List<ReportDto>>(patientReports);
            return Ok(mappedPatientReports);
        }

    }
}
