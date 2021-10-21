using System;
using CM7A68_HFT_2021221.Data;
using System.Linq;
using System.Collections.Generic;

namespace CM7A68_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started.");
            CarDBContext db = new CarDBContext();

            // brembo márkát alkalmazó márkák (3 tábla) BENT
            IEnumerable<KeyValuePair <string,string>> BremboUserBrands = from x in db.Brands
                                   where x.Cars.Any(x => x.CarParts.Any(x => x.Part.Brand == "Brembo"))
                                   select new KeyValuePair<string, string>( "Brand",x.Name);

            //elektromos autót forgalmazó márkák (2 tábla) BENT
            IEnumerable<KeyValuePair<string, string>> BrandsWithElectricCars = from x in db.Brands
                                         where x.Cars.Any(x => x.Cylinder_capacity == 0)
                                         select new KeyValuePair<string, string>("Brand",x.Name);

            //3 legtöbb alkatrésszel kompatibilis autó (2 tábla) BENT
            //.Take(3).Select(x =>new {x.Brand.Name, x.Model, Parts=x.CarParts.ToArray().Length});
            //select new KeyValuePair<string,List<string>>("Car", new List<string>() { x.Brand.Name, x.Model, x.CarParts.ToArray().Length.ToString() })).Take(3);
            IEnumerable<KeyValuePair<string, List<KeyValuePair<string,string>>>> Top3CarsWithTheMostCompatibleParts = (from x in db.Cars
                                                      orderby x.CarParts.ToArray().Length descending
                                                      select new KeyValuePair<string,List<KeyValuePair<string, string>>>("Car", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Brand", x.Brand.Name ), new KeyValuePair<string, string>("Model", x.Model), new KeyValuePair<string, string>("Part_Number",x.CarParts.ToArray().Length.ToString()) })).Take(3);
            //legtöbb 4 hengeres autóval rendelkező márka (2 tábla) BENT
            //select x).Take(1).Select(x=>x.Name);
            IEnumerable<KeyValuePair<string, string>> BrandWithTheMost4CylinderCar = (from x in db.Brands
                                                orderby x.Cars.Count(x => x.Cylinder_number == 4) descending
                                                select new KeyValuePair<string, string>("Brand", x.Name)).Take(1);

            //átlagos hengerűrtartalom márkák szerint csoportosítva BENT
            // select new
            //{
            //    Brand = g.Key,
            //                               AvgCylinderCap = g.Average(x => x.Cylinder_capacity)
            //                           };

            IEnumerable<KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>> AvgCylinderCapBrands = from x in db.Cars
                                       group x by x.Brand.Name into g
                                       select new KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>
                                       ("Brand",new KeyValuePair<string, KeyValuePair<string, double>>(g.Key, new KeyValuePair<string, double>("AvgCylCap",Math.Round( g.Average(x => x.Cylinder_capacity),1))));


            var list = BrandsWithElectricCars.ToList();
            string test = list[0].Value;
            IEnumerable<KeyValuePair<string, List<KeyValuePair<string, string>>>> Top3CarsWithTheMostCompatiblePartstest = (from x in db.Cars
                                                                                                                        orderby x.CarParts.ToArray().Length descending
                                                                                                                        select new KeyValuePair<string, List<KeyValuePair<string, string>>>("Car", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Brand", x.Brand.Name), new KeyValuePair<string, string>("Model", x.Model), new KeyValuePair<string, string>("Part_Number", x.CarParts.ToArray().Length.ToString()) }));
            ;
        }
    }
}
