using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var item in result)
            {
                if (item.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalError);
                }
                else
                {
                    _rentalDal.Add(rental);                    
                }                
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (DateTime.Now.Hour == 11)
            {
               return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                 return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 11)
            {
               return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<RentalDetailDto>>(Messages.RentalListed);
            }
           
        }

        public IResult Update(Rental rental)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
        }
    }
}
