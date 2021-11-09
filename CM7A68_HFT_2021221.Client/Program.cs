using System;
using CM7A68_HFT_2021221.Data;
using System.Linq;
using System.Collections.Generic;
using CM7A68_HFT_2021221.Models;
using CM7A68_HFT_2021221.Repository;

namespace CM7A68_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started.");
            CarDBContext db = new CarDBContext();
            CarRepo carRepo = new CarRepo(db);
            BrandRepo brandRepo = new BrandRepo(db);
            Brand testbrand = new Brand() { Name = "TestBrand", ID = 29 };
            Car testcar = new Car()
            {
                ID = 29,
                Model = "TestModel",
                Brand = testbrand,
                BrandID = testbrand.ID,
                Cylinder_capacity = 2.0,
                Cylinder_number = 6,
                Production_year = 29,
                CarParts = new List<CarPart>()
                
            };
            CarPart test = new CarPart() { Car = testcar, Part = db.Parts.ToList()[0], PartID = 1 , CarID=29};
            testcar.CarParts.Add(test);
            testbrand.Cars.Add(testcar);
            brandRepo.Create(testbrand);
            //carRepo.Create(testcar);
           
            ;
        }
    }
}
