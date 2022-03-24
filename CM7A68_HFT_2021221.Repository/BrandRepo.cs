using System;
using CM7A68_HFT_2021221.Models;
using CM7A68_HFT_2021221.Data;
using System.Linq;

namespace CM7A68_HFT_2021221.Repository
{
    public class BrandRepo : IBrandRepo
    {
        CarDBContext db;
        public BrandRepo(CarDBContext db)
        {
            this.db = db;
        }
        public void Create(Brand brand)
        {
            brand.ID = ReadAll().Count() + 1;
            db.Brands.Add(brand);
            db.SaveChanges();
        }
        public Brand Read(int ID)
        {
            return db.Brands.FirstOrDefault(x => x.ID == ID);
        }
        public IQueryable<Brand> ReadAll()
        {
            return db.Brands;
        }
        public void Delete(int ID)
        {
            var todelete = Read(ID);
            db.Brands.Remove(todelete);
            db.SaveChanges();
        }
        public void Update(Brand brand)
        {
            var oldbrand = Read(brand.ID);
            oldbrand.Name = brand.Name;
            oldbrand.Cars = brand.Cars.Select(x=>x).ToList();
            //oldbrand.Cars = brand.Cars; ;
            db.SaveChanges();
        }

    }
}
