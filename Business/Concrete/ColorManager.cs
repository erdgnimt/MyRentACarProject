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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            else
            {
                return new SuccessResult(Messages.MaintenanceTime);
            }
           
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            else
            {
                return new SuccessResult(Messages.MaintenanceTime);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
            }
            else
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
        }

        public IDataResult<Color> GetById(int id)
        {
            if (DateTime.Now.Hour==22)
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), Messages.ColorListed);
            }
            else
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }           
        }

        public IResult Update(Color color)
        {

            if (DateTime.Now.Hour == 22)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            else
            {
                return new SuccessResult(Messages.MaintenanceTime);
            }
            
        }
    }
}
