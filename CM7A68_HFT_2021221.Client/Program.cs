using System;
using CM7A68_HFT_2021221.Data;
using System.Linq;
namespace CM7A68_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started.");
            CarDBContext db = new CarDBContext();

            // brembo márkát alkalmazó márkák (3 tábla)
            var BremboUserBrands = from x in db.Brands
                                   where x.Cars.Any(x => x.CarParts.Any(x => x.Part.Brand == "Brembo"))
                                   select new {x.Name};

            //elektromos autót forgalmazó márkák (2 tábla) 
            var BrandsWithElectricCars = from x in db.Brands
                                         where x.Cars.Any(x => x.Cylinder_capacity == 0)
                                         select new {x.Name};

            //3 legtöbb alkatrésszel kompatibilis autó (2 tábla) 
            var Top3CarsWithTheMostCompatibleParts = (from x in db.Cars
                                                      orderby x.CarParts.ToArray().Length descending
                                                      select x).Take(3).Select(x =>new {x.Brand.Name, x.Model, Parts=x.CarParts.ToArray().Length});

            //legtöbb 4 hengeres autóval rendelkező márka (2 tábla) 
            var BrandWithTheMost4CylinderCar = (from x in db.Brands
                                                orderby x.Cars.Count(x => x.Cylinder_number == 4) descending
                                                select x).Take(1).Select(x=>x.Name);

            //átlagos hengerűrtartalom márkák szerint csoportosítva
            var AvgCylinderCapBrands = from x in db.Cars
                                       group x by x.Brand.Name into g
                                       select new
                                       {
                                           Brand = g.Key,
                                           AvgCylinderCap = g.Average(x=>x.Cylinder_capacity)
                                       };
            

            ;

        }
    }
}
