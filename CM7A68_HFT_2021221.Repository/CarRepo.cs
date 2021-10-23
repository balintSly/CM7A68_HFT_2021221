using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM7A68_HFT_2021221.Data;
using CM7A68_HFT_2021221.Models;

namespace CM7A68_HFT_2021221.Repository
{
    public class CarRepo : ICarRepo
    {
        CarDBContext db;
        public CarRepo(CarDBContext db)
        {
            this.db = db;
        }
        public void Create(Car car)
        {
            db.Cars.Add(car);
            foreach (var carsPart in car.CarParts)
            {
                foreach (var item in db.Parts)
                {
                    if (item.ID==carsPart.PartID)
                    {
                        item.CarParts.Add(carsPart);
                    }
                }
            }//létrehozza az alkatrészek kapcsolatát az autóval
            db.SaveChanges();
        }
        public Car Read(int ID)
        {
            return db.Cars.FirstOrDefault(x => x.ID == ID);
        }
        public IQueryable<Car> ReadAll()
        {
            return db.Cars;
        }
        public void Delete(int ID)
        {
            var todelete = Read(ID);
            db.Remove(todelete);
            foreach (var carsPart in todelete.CarParts)
            {
                foreach (var item in db.Parts)
                {
                    if (item.ID == carsPart.PartID)
                    {
                        item.CarParts.Remove(carsPart);
                    }
                }
            }//törli az alaktrészek kapcsolatát az autóval
            db.SaveChanges();
        }
        public void Update(Car car)
        {
            var oldcar = Read(car.ID);
            oldcar.BrandID = car.BrandID;
            oldcar.Cylinder_capacity = car.Cylinder_capacity;
            oldcar.Cylinder_number = car.Cylinder_number;
            oldcar.Model = car.Model;
            oldcar.Production_year = car.Production_year;
            db.SaveChanges();
        }
    }
}
