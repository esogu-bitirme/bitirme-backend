using Business.Abstract;
using Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.Concrete
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;
        public ImageService(IImageRepository imageRepository) {
            _imageRepository = imageRepository;
        }
        public Image Add(Image image)
        {
            image.CreateDate = DateTime.Now;
            image.UpdateDate = DateTime.Now;
            return _imageRepository.Add(image);
        }

        public bool Delete(int id)
        {
            return _imageRepository.Delete(id);
        }

        public List<Image> GetAll()
        {
            return _imageRepository.GetAll();    
        }

        public Image GetById(int id)
        {
            return _imageRepository.GetById(id);
        }

        public Image Update(Image image)
        {
            image.UpdateDate = DateTime.Now;
            Image currentImage = _imageRepository.GetById(image.Id);
            image.CreateDate = currentImage.CreateDate;
            return _imageRepository.Update(image);
        }

        public async Task<List<Image>> GetByReportId(int reportId)
        {
            return await _imageRepository.GetByReportId(reportId);
        }
    }
}
