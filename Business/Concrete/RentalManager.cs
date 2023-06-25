using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (DateTime.Now.Hour == 22)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
            }
            else
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(Messages.RentalListed);
            }
            else
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
           
        }

        public IResult Update(Rental rental)
        {
            if (DateTime.Now.Hour == 22)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }
    }
}
