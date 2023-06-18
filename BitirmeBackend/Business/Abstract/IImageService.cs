using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.Response;
using Entities.Dtos.Request;
using Entities.Modals;

namespace Business.Abstract
{
    public interface IImageService
    {
        List<Image> GetAll();

        Image GetById(int id);

        Image Add(Image image);

        Image Update(Image image);

        bool Delete(int id);
        Task<List<Image>> GetByReportId(int reportId);
    }
}
