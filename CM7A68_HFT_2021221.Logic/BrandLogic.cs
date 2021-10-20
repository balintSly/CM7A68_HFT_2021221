using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM7A68_HFT_2021221.Repository;
using CM7A68_HFT_2021221.Models;

namespace CM7A68_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepo brandRepo;
        public BrandLogic(IBrandRepo brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        public void Create(Brand brand)
        {
            if (brand.Name.Length == 0)
            {
                throw new ArgumentException("The brand does not have a name.");
            }
            if (brand.ID < 0)
            {
                throw new ArgumentException("Invalid brand ID.");
            }
            brandRepo.Create(brand);
        }
        public void Delete(int id)
        {
            try
            {
                brandRepo.Delete(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no brand with the following ID: " + id);
            }

        }
        public Brand Read(int id)
        {
            try
            {
                return brandRepo.Read(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no brand with the following ID: " + id);
            }
        }
        public void Update(Brand brand)
        {
            try
            {
                Read(brand.ID);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            brandRepo.Update(brand);
        }
        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }
        public IEnumerable<KeyValuePair<string, string>> BremboUserBrands()
        {
            return from x in brandRepo.ReadAll()
                   where x.Cars.Any(x => x.CarParts.Any(x => x.Part.Brand == "Brembo"))
                   select new KeyValuePair<string, string>("Brand", x.Name); 
        }
        public IEnumerable<KeyValuePair<string, string>> BrandsWithElectricCars()
        {
            return from x in brandRepo.ReadAll()
                   where x.Cars.Any(x => x.Cylinder_capacity == 0)
                   select new KeyValuePair<string, string>("Brand", x.Name);
        }
        public IEnumerable<KeyValuePair<string, string>> BrandWithTheMost4CylinderCar()
        {
            return (from x in brandRepo.ReadAll()
                    orderby x.Cars.Count(x => x.Cylinder_number == 4) descending
                    select new KeyValuePair<string, string>("Brand", x.Name)).Take(1);
        }

    }
}
