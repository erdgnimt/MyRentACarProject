using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }

        }

        public IResult Delete(Brand brand)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
               return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            else
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
            }
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.BrandListed);
            }
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 11)
            {
               return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            
        }
    }
}
