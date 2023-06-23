using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //DeleteBrand(brandManager);
            //UpdateBrand(brandManager);
            //AddBrand(brandManager);
            //GetAllBrand(brandManager);
            //DeleteColor(colorManager);
            //UpdateColor(colorManager);
            //AddColor(colorManager);
            //GetAllColor(colorManager);
            //GetCarsByBrandId(carManager);            
            //GetAll(carManager);
            //GetCarDetails(carManager);
            //UpdateCar(carManager);
            //AddCar(carManager);
            //DeleteCar(carManager);
            //Console.WriteLine(brandManager.GetById(3).BrandName);
            //Console.WriteLine(carManager.GetById(2).CarName);
            //Console.WriteLine(colorManager.GetById(2).ColorName);
            Console.Read();
        }

        private static void DeleteBrand(BrandManager brandManager)
        {
            Brand brand = new Brand
            {
                BrandId = 15,
                BrandName = "Ferrari"
            };
            brandManager.Delete(brand);
            GetAllBrand(brandManager);
        }

        private static void UpdateBrand(BrandManager brandManager)
        {
            Brand brand = new Brand
            {
                BrandId = 15,
                BrandName = "Ferrari"
            };
            brandManager.Update(brand);
            GetAllBrand(brandManager);
        }

        private static void AddBrand(BrandManager brandManager)
        {
            Brand brand = new Brand
            {
                BrandName = "Mercedes"
            };
            brandManager.Add(brand);
            GetAllBrand(brandManager);
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine($"{item.BrandId}--{item.BrandName}");
            }
        }

        private static void DeleteColor(ColorManager colorManager)
        {
            Color color = new Color
            {
                ColorId = 13,
                ColorName = "Lilac"
            };
            colorManager.Delete(color);
            GetAllColor(colorManager);
        }

        private static void UpdateColor(ColorManager colorManager)
        {
            Color color = new Color
            {
                ColorId = 13,
                ColorName = "Lilac"
            };
            colorManager.Update(color);
            GetAllColor(colorManager);
        }

        private static void AddColor(ColorManager colorManager)
        {
            Color color = new Color
            {
                ColorName = "Silver"
            };
            colorManager.Add(color);

            GetAllColor(colorManager);
        }


        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine($"{item.ColorId}--{item.ColorName}");
            }
        }

        private static void DeleteCar(CarManager carManager)
        {
            Car car = new Car
            {
                CarId = 14,
                BrandId = 8,
                CarName = "S",
                ColorId = 5,
                DailyPrice = 250,
                Description = "Hatchback",
                ModelYear = "2011",

            };
            carManager.Delete(car);
            GetAll(carManager);
        }

        private static void AddCar(CarManager carManager)
        {
            Car car = new Car
            {
                BrandId = 8,
                CarName = "S",
                ColorId = 5,
                DailyPrice = 250,
                Description = "Hatchback",
                ModelYear = "2011",

            };
            carManager.Add(car);
            GetAll(carManager);
        }

        private static void UpdateCar(CarManager carManager)
        {
            Car car = new Car
            {
                CarId = 14,
                BrandId = 8,
                CarName = "S",
                ColorId = 5,
                DailyPrice = 250,
                Description = "Hatchback",
                ModelYear = "2011",

            };
            carManager.Update(car);
            GetAll(carManager);
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var item in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine($"{item.CarName}--{item.DailyPrice}");
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine($"{item.CarId}--{item.CarName}");
            }
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine($"{item.CarName}--{item.BrandName}--{item.ColorName}--{item.DailyPrice}");
            }
        }
    }
}
