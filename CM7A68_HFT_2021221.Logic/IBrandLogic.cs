using CM7A68_HFT_2021221.Models;
using System.Collections.Generic;

namespace CM7A68_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand brand);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand brand);
        IEnumerable<KeyValuePair<string, string>> BremboUserBrands();
        IEnumerable<KeyValuePair<string, string>> BrandsWithElectricCars();
        IEnumerable<KeyValuePair<string, string>> BrandWithTheMost4CylinderCar();
    }
}