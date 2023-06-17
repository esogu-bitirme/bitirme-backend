using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities.Dtos.Request;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public ImageController(IMapper mapper,IImageService imageService)
        {
            _mapper = mapper;
            _imageService = imageService;
            
        }

        [HttpGet]

        public IActionResult GetAllImages() {
            try
            {
                var records = _mapper.Map<List<ImageDto>>(_imageService.GetAll());
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetImage(int id) {
            try
            {
                var record = _mapper.Map<ImageDto>(_imageService.GetById(id));
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
        public IActionResult AddImage(ImageDto image)
        {
            try
            {
                var imageRequest = _mapper.Map<Image>(image);
                Image imageResponse = _imageService.Add(imageRequest);
                ImageDto imageResponseDto = _mapper.Map<ImageDto>(imageResponse);
                return Ok(imageResponseDto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            try
            {
                _imageService.Delete(id);
                return Ok("Image successfully deleted with id "+id+"!");
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
        public IActionResult UpdateImage(ImageUpdateRequestDto image)
        {

            try
            {
                var imageRequest = _mapper.Map<Image>(image);
                Image imageResponse = _imageService.Update(imageRequest);
                ImageDto updatedImage = _mapper.Map<ImageDto>(imageResponse);
                return Ok(updatedImage);
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
