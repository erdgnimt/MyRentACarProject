using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        IFileHelper _fileHelper;
        public ImageManager(IImageDal imageDal, IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile formfile, Image image)
        {
            var result = BusinessRules.Run(CheckIfImageCount(image.CarId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = _fileHelper.Upload(formfile, PathConstants.ImagesPath);
            image.ImageDate = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(Image image)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(), Messages.ImageListed);
        }

        public IDataResult<List<Image>> GetImageByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfImageOfCar(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<Image>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.CarId == carId), Messages.ImageListed);
        }

        public IResult Update(IFormFile formfile, Image image)
        {
            image.ImagePath = _fileHelper.Update(formfile, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            image.ImageDate = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }
        private IResult CheckIfImageCount(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCountExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfImageOfCar(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ImageNotFound);
        }
        private IDataResult<List<Image>> GetDefaultImage(int carId)
        {
            List<Image> images = new List<Image>();
            images.Add(new Image
            { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<Image>>(images);
        }
    }
}
