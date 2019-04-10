﻿using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.MockRepo
{
    public class CarMockRepository : ICarRepository
    {
        private static List<Car> _cars;
        static CarMockRepository()
        {
            _cars = new List<Car>

        {
            new Car
            {
                CarId = 1,
                Body = "SUV",
                Year = 2013,
                Mileage = 0,
                ExColor = "Black",
                IntColor = "Tan",
                Transmission = "Automatic",
                Type = "New",
                MSRP = 5,
                Price = 10000,
                ImageFileName = "Car1.PNG",
                MakeId = 1,
                ModelId = 1,
                isFeatured = true,
                isSold = false,
                VIN = "1000"
            },
            new Car
            {
                CarId = 2,
                Body = "Sedan",
                Year = 2015,
                Mileage = 0,
                ExColor = "Black",
                IntColor = "Tan",
                Transmission = "Manual",
                Type = "New",
                MSRP = 5,
                Price = 10000,
                ImageFileName = "Car2.PNG",
                MakeId = 1,
                ModelId = 2,
                isFeatured = true,
                isSold = false,
                VIN = "1000"
            },
            new Car
            {
                CarId = 3,
                Body = "Sedan",
                Year = 2015,
                Mileage = 0,
                ExColor = "Red",
                IntColor = "Rainbow",
                Transmission = "Manual",
                Type = "New",
                MSRP = 5,
                Price = 10000,
                ImageFileName = "Car2.PNG",
                MakeId = 3,
                ModelId = 1,
                isFeatured = false,
                isSold = false,
                VIN = "1000"
            },
            new Car
            {
                CarId = 4,
                Body = "Sedan",
                Year = 2015,
                Mileage = 0,
                ExColor = "Red",
                IntColor = "Rainbow",
                Transmission = "Manual",
                Type = "Used",
                MSRP = 5,
                Price = 10000,
                ImageFileName = "Car2.PNG",
                MakeId = 3,
                ModelId = 1,
                isFeatured = false,
                isSold = false,
                VIN = "1001"
            },
            new Car
            {
                CarId = 5,
                Body = "SUV",
                Year = 2010,
                Mileage = 10000,
                ExColor = "Black",
                IntColor = "Tan",
                Transmission = "Automatic",
                Type = "Used",
                MSRP = 5,
                Price = 10,
                ImageFileName = "Car1.PNG",
                MakeId = 2,
                ModelId = 1,
                isFeatured = false,
                isSold = true,
                VIN = "1000"
            },
            new Car
            {
                CarId = 6,
                Body = "Sedan",
                Year = 2000,
                Mileage = 0,
                ExColor = "Red",
                IntColor = "Rainbow",
                Transmission = "Manual",
                Type = "Used",
                MSRP = 5,
                Price = 10000,
                ImageFileName = "Car2.PNG",
                MakeId = 3,
                ModelId = 1,
                isFeatured = false,
                isSold = false,
                VIN = "1000"
            },
        };
            }

        public Car Create(Car car)
        {
            int id = _cars.Max(c => c.CarId) + 1;
            _cars.Add(car);

            return car;
        }

        public void Delete(int id)
        {
            Car car = _cars.FirstOrDefault(c => c.CarId == id);
            _cars.Remove(car);
        }

        public IEnumerable<Car> GetAllFeatures()
        {
            return _cars.Where(c => c.isFeatured == true);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.CarId == id);
        }

        public IEnumerable<Car> GetAllNotSold()
        {
            return _cars.Where(c => c.isSold == false);
        }

        //public IEnumerable<Car> GetNewCars(string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100)
        //{
        //    //instantiate make and model repos

        //    //3 embedded if statements
        //    //return _cars.Where()
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Car> GetUsedCars(string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Car> GetNotSoldCars(string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Car> Search(string searchType, string searchText, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 2000, int maxYear = 2100)
        {
            ModelMockRepo modelRepo = new ModelMockRepo();
            MakeMockRepo makeRepo = new MakeMockRepo();
            IEnumerable<Car> vehicles = new List<Car>();

            switch (searchType)
            {
                case "New":
                case "Used":
                    vehicles = GetAllCars().Where(c => c.Type == searchType).Where(c => c.isSold == false);
                    break;
                case "All":
                    vehicles = GetAllCars().Where(c => c.isSold == false);
                    break;
                default:
                    break;
            }

            List<Car> found = new List<Car>();

            int year = 0;
            int.TryParse(searchText, out year);

            foreach(var car in vehicles)
            {
                car.Make = makeRepo.GetById(car.MakeId);
                car.Model = modelRepo.GetById(car.ModelId);

                if (car.Year >= minYear && car.Year <= maxYear && car.Price >= minPrice && car.Price <= maxPrice)
                {
                    if (searchText != "hamster")
                    {
                        if (car.Year == year || car.Make.MakeName.ToLower().Contains(searchText.ToLower()) || car.Model.ModelName.ToLower().Contains(searchText.ToLower()))
                        {
                            found.Add(car);
                        }
                    }
                    else
                    {
                        found.Add(car);
                    }
                }
            }

            return found;
        }

        public Car Update(Car car)
        {
            Car update = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(update);
            _cars.Add(car);

            return car;
        }

        public void ChangeToSold(int id)
        {
            throw new NotImplementedException();
        }
    }
}