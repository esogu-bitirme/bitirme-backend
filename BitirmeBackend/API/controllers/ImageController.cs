using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities.Dtos.Request;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Entities.Dtos.Response;

namespace API.Controllers
{
    [Route("api/image")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IReportService _reportService;

        public ImageController(IMapper mapper, IImageService imageService, IReportService reportService)
        {
            _mapper = mapper;
            _imageService = imageService;
            _reportService = reportService;
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

        [HttpGet("report/{reportId}")]
        [ProducesResponseType(typeof(List<ImageDto>), 200)]
        [ProducesResponseType(typeof(NoContentResult), 204)]
        [ProducesResponseType(typeof(int), 500)]
        public async Task<IActionResult> GetImageByReportId(int reportId)
        {
            try
            {
                var report = _reportService.GetById(reportId);
                var images = await _imageService.GetByReportId(reportId);

                if (!images.Any())
                    return NoContent();

                var mappedReportImages = _mapper.Map<List<ImageDto>>(images);
                return Ok(mappedReportImages);
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

        [HttpPost("save-image")]
        public async Task<IActionResult> SaveImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Geçersiz dosya");
                }

                // Resmin kaydedileceği klasör yolunu belirleyin
                string folderPath = "images";

                // Resmin adını ve yolunu oluşturun
                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string filePath = Path.Combine(folderPath, uniqueFileName);

                // Klasörü oluşturun (varsa zaten mevcut)
                Directory.CreateDirectory(folderPath);

                // Resmi kopyalayın ve kaydedin
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok("Resim başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Resim kaydedilirken bir hata oluştu");
            }
        }

    }
}
