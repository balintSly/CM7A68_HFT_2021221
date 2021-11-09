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
            #region manual tests
            Console.WriteLine("Program started.");
            CarDBContext db = new CarDBContext();
            CarRepo carRepo = new CarRepo(db);
            BrandRepo brandRepo = new BrandRepo(db);
            PartRepo partRepo = new PartRepo(db);
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
            Part testPart = new Part() { ID = 99, Brand = "TestPartBrand", CarParts = new List<CarPart>() , Item_number = "lol", Name = "TestStuff", Price = 5000, Weight = 50000 };
            testPart.CarParts.Add(new CarPart { Car = testcar, CarID = testcar.ID, Part = testPart, PartID = testPart.ID } );
            CarPart test = new CarPart() { Car = testcar, Part = db.Parts.ToList()[0], PartID = 1 , CarID=29};

            testcar.CarParts.Add(test);
            testbrand.Cars.Add(testcar);
            #endregion

            ;
        }
    }
}
