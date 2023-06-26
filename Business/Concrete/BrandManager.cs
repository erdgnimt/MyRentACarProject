using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (DateTime.Now.Hour == 11)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            
        }

        public IResult Delete(Brand brand)
        {
            if (DateTime.Now.Hour == 11)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
            }
            
            else
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.BrandListed);
            }
            else
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 11)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            
        }
    }
}
