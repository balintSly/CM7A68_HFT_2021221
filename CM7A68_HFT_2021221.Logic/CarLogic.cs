using System;
using System.Collections.Generic;
using CM7A68_HFT_2021221.Models;
using CM7A68_HFT_2021221.Repository;
using System.Linq;

namespace CM7A68_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepo carRepo;
        public CarLogic(ICarRepo carRepo)
        {
            this.carRepo = carRepo;
        }
        public void Create(Car car)
        {
            if (car.Cylinder_capacity < 0)
            {
                throw new ArgumentException("Invalid cylinder capacity.");
            }
            if (car.Cylinder_number < 0)
            {
                throw new ArgumentException("Invalid cylinder number.");
            }
            if (car.Model.Length == 0)
            {
                throw new ArgumentException("Invalid model name.");
            }
            carRepo.Create(car);
        }
        public Car Read(int id)
        {
            try
            {
                return carRepo.Read(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no car with the following ID: " + id);
            }
        }
        public void Update(Car car)
        {
            try
            {
                 carRepo.Update(car);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
           
        }
        public IEnumerable<Car> ReadAll()
        {
            return carRepo.ReadAll();
        }
        public void Delete(int id)
        {
            try
            {
                carRepo.Delete(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no car with the following ID: " + id);
            }

        }
        public IEnumerable<KeyValuePair<string, List<KeyValuePair<string, string>>>> Top3CarsWithTheMostCompatibleParts()
        {
            return (from x in carRepo.ReadAll()
                    orderby x.CarParts.ToArray().Length descending
                    select new KeyValuePair<string, List<KeyValuePair<string, string>>>("Car", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Brand", x.Brand.Name), new KeyValuePair<string, string>("Model", x.Model), new KeyValuePair<string, string>("Part_Number", x.CarParts.ToArray().Length.ToString()) })).Take(3);
        }

        public IEnumerable<KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>> AvgCylinderCapBrands()
        {
            return from x in carRepo.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>
                   ("Brand", new KeyValuePair<string, KeyValuePair<string, double>>(g.Key, new KeyValuePair<string, double>("AvgCylCap",Math.Round( g.Average(x => x.Cylinder_capacity), 1))));
        }
    }
}
