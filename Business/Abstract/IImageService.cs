using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetImageByCarId(int carId);
        IResult Add(IFormFile file, Image image);
        IResult Delete(Image image);
        IResult Update(IFormFile file, Image image);
    }
}
