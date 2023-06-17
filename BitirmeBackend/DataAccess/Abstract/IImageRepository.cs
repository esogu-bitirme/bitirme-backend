using Entities.Modals;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IImageRepository
    {
        public List<Image> GetAll();
        public Image GetById(int id);
        public Image Add(Image image);
        public Image Update(Image image);
        public bool Delete(int id);

    }
}
