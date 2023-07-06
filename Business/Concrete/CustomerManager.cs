using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
       
        public IResult Add(Customer customer)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
        }

        public IResult Delete(Customer customer)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
            }
            
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id), Messages.ColorListed);
            }
        }

        public IResult Update(Customer customer)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
        }
    }
}
