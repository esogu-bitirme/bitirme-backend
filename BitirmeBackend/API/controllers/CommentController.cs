using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        public CommentController(IMapper mapper,ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
            
        }

        [HttpGet]

        public IActionResult GetAllComments() {
            try
            {
                var records = _mapper.Map<List<CommentDto>>(_commentService.GetAll());
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetComment(int id) {
            try
            {
                var record = _mapper.Map<CommentDto>(_commentService.GetById(id));
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


        [HttpGet("/reportId/{reportId}")]
        public IActionResult GetAllCommentsWithReportId(int reportId)
        {
            try
            {
                var record = _mapper.Map<CommentDto>(_commentService.GetAllByReportId(reportId));
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
        public IActionResult AddComment(CommentDto comment)
        {
            try
            {
                var commentRequest = _mapper.Map<Comment>(comment);
                Comment commentResponse = _commentService.Add(commentRequest);
                CommentDto commentResponseDto = _mapper.Map<CommentDto>(commentResponse);
                return Ok(commentResponseDto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                _commentService.Delete(id);
                return Ok("Comment successfully deleted with id "+id+"!");
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

    }
}
