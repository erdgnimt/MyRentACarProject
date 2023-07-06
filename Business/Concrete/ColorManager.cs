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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new SuccessResult(Messages.MaintenanceTime);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
           
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
            }
        }

        public IDataResult<Color> GetById(int id)
        {
            if (DateTime.Now.Hour== 11)
            {
               return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), Messages.ColorListed);
            }           
        }

        public IResult Update(Color color)
        {

            if (DateTime.Now.Hour == 11)
            {
                return new SuccessResult(Messages.MaintenanceTime);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            
        }
    }
}
