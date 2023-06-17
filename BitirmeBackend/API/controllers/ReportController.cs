using AutoMapper;
using Business.Abstract;
using Entities.Dtos;
using Entities.Dtos.Request;
using Entities.Exceptions;
using Entities.Modals;
using Entities.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;
        public ReportController(IMapper mapper,IReportService reportService)
        {
            _mapper = mapper;
            _reportService = reportService;
            
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

    }
}
