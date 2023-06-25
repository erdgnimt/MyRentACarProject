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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }

        public IResult Delete(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.RentalListed);
            }
            else
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
        }

        public IResult Update(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            else
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
        }
    }
}
