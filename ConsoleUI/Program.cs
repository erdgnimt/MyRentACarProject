using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car dogan = new Car()
            {
                CarId = 11,
                CarName = "Doğan",
                BrandId = 6,
                ColorId = 1,
                DailyPrice = 90000,
                Description = "Sedan",
                ModelYear = "1996"
            };
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine($"{item.CarName}--{item.DailyPrice}--{item.Description}");
            //}


            //foreach (var item in carManager.GetById(2))
            //{
            //    Console.WriteLine($"{item.CarName}--{item.DailyPrice}--{item.Description}");
            //}

            //carManager.Add(dogan);
            //Console.WriteLine("Car Added!");
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine($"{item.CarName}--{item.DailyPrice}--{item.Description}");
            //}

            //carManager.Delete(dogan);
            //Console.WriteLine("Car Deleted!");
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine($"{item.CarName}--{item.DailyPrice}--{item.Description}");
            //}           

            Console.Read();
        }
    }
}
