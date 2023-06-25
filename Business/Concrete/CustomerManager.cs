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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
       
        public IResult Add(Customer customer)
        {
            if (DateTime.Now.Hour == 22)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }

        public IResult Delete(Customer customer)
        {
            if (DateTime.Now.Hour == 22)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
            }
            else
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id), Messages.ColorListed);
            }
            else
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
        }

        public IResult Update(Customer customer)
        {
            if (DateTime.Now.Hour == 22)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }
    }
}
