using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }

        }
        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }

        }
        [SecuredOperation("car.getall")]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
            }

        }

        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.CarListed);
            }

        }

        public IDataResult<List<CarDetailDto>>GetCarDetails()
        {
            if (DateTime.Now.Hour == 11)
            {
               return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
            }

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                 return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarListed);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarListed);
            }
        }

        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 11)
            {
               return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

        }
    }
}
