using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; 
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
              new Car{CarId=1,BrandId=1,CarName="Focus", ColorId=1,ModelYear="2011",DailyPrice=180000,Description="Sedan"},
              new Car{CarId=2,BrandId=3,CarName="Clio", ColorId=1,ModelYear="2017",DailyPrice=230000,Description="Sedan"},
              new Car{CarId=3,BrandId=3,CarName="Megane", ColorId=2,ModelYear="2010",DailyPrice=170000,Description="Sedan"},
              new Car{CarId=4,BrandId=4,CarName="A180", ColorId=1,ModelYear="2008",DailyPrice=350000,Description="Hatchback"},
              new Car{CarId=5,BrandId=6,CarName="Leon", ColorId=1,ModelYear="2019",DailyPrice=230000,Description="Sedan"},
              new Car{CarId=6,BrandId=5,CarName="i20", ColorId=1,ModelYear="2017",DailyPrice=210000,Description="Hatchback"},
              new Car{CarId=7,BrandId=2,CarName="Passat", ColorId=2,ModelYear="2008",DailyPrice=260000,Description="Sedan"},
              new Car{CarId=8,BrandId=2,CarName="Caddy", ColorId=1,ModelYear="2013",DailyPrice=300000,Description="Staion Vagon"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteToCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(deleteToCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            var getById = _cars.Where(c => c.CarId == carId).ToList();
            return getById;
            
        }

        public void Update(Car car)
        {
            var updateToCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            updateToCar.CarId = car.CarId;
            updateToCar.CarName = car.CarName;
            updateToCar.ColorId = car.ColorId;
            updateToCar.BrandId = car.BrandId;
            updateToCar.DailyPrice = car.DailyPrice;
            updateToCar.Description = car.Description;
        }
    }
}
