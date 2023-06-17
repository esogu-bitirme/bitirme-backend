using DataAccess.Abstract;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using Entities.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Image Add(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges(); 
            return image;
        }

        public bool Delete(int id)
        {
            var deleteImage = GetById(id);
            _context.Images.Remove(deleteImage);
            _context.SaveChanges();
            return true;
            
        }

        public List<Image> GetAll()
        {
            try
            {
                return _context.Images.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Image GetById(int id)
        {
            try
            {
                Image image =_context.Images.Find(id);
                if (image == null)
                {
                    throw new EntityNotFoundException("Image not found with id "+id.ToString()+" !");
                }
                return image;
            }
            catch (Exception exception) { throw exception; }
        }

        public Image Update(Image image)
        {
            using (var context = new ApplicationDbContext()) {
                try
                {
                    context.Images.Update(image);
                    context.SaveChanges();
                    return image;
                }
                catch (Exception exception) { throw exception; }
            }
            
        }
    }
}
