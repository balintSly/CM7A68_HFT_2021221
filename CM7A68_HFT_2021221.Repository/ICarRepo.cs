using CM7A68_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace CM7A68_HFT_2021221.Repository
{
    public interface ICarRepo
    {
        void Create(Car car);
        void Delete(int ID);
        Car Read(int ID);
        IQueryable<Car> ReadAll();
        void Update(Car car);
    }
}