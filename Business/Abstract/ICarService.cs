﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult <List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
