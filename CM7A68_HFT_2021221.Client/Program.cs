using System;
using System.Linq;
using System.Collections.Generic;
using CM7A68_HFT_2021221.Models;


namespace CM7A68_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GUI gui = new GUI();
            #region manual tests
            //CarDBContext db = new CarDBContext();
            //CarRepo carRepo = new CarRepo(db);
            //BrandRepo brandRepo = new BrandRepo(db);
            //PartRepo partRepo = new PartRepo(db);
            //Part test = new Part() { Brand = "Test", Weight = 11, ID = 29, Name = "TestPart", Price = 111, Item_number = "AASDADasd" };
            //test.CarParts.Add(new CarPart { CarID = 1, Car = carRepo.Read(1) });

            //Part updatetest = new Part() { Brand = "TestUpdate", Weight = 99, ID = 29, Name = "UpdateTestPart", Price = 99999, Item_number = "Updatedpart" };
            //updatetest.CarParts.Add(new CarPart { CarID = 2});
            //updatetest.CarParts.Add(new CarPart { CarID = 3});

            //partRepo.Create(test);
            //partRepo.Update(updatetest);
            #endregion
            ;

        }
    }
}
