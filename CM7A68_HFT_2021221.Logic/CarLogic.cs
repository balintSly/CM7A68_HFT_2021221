using System;
using System.Collections.Generic;
using CM7A68_HFT_2021221.Models;
using CM7A68_HFT_2021221.Repository;

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
                Read(car.ID);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            carRepo.Update(car);
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
    }
}
