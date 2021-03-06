using NUnit.Framework;
using System;
using CM7A68_HFT_2021221.Models;
using CM7A68_HFT_2021221.Repository;
using CM7A68_HFT_2021221.Logic;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace CM7A68_HFT_2021221.Test
{
    [TestFixture]
    public class TesterClass
    {
        CarLogic cl;
        BrandLogic bl;
        [SetUp]
        public void CreateDB()
        {

            ////////////////////////////////////////////////////////////////////////
            Brand volkswagen = new Brand() { ID = 1, Name = "Volkswagen" };
            Brand seat = new Brand() { ID = 2, Name = "SEAT" };
            Brand audi = new Brand() { ID = 3, Name = "Audi" };
            Brand skoda = new Brand() { ID = 4, Name = "Skoda" };
            Brand porsche = new Brand() { ID = 5, Name = "Porsche" };
            Brand lamborghini = new Brand() { ID = 6, Name = "Lamborghini" };
            Brand tesla = new Brand() { ID = 7, Name = "Tesla" };
            Brand nissan = new Brand() { ID = 8, Name = "Nissan" };
            Brand toyota = new Brand() { ID = 9, Name = "Toyota" };
            Brand suzuki = new Brand() { ID = 10, Name = "Suzuki" };
            //////////////////////////////////////////////////////////////////////
            Part part1 = new Part() { ID = 1, Brand = "Febi", Item_number = "006070789A", Name = "Brake pads", Price = 5000, Weight = 0.5 };
            Part part2 = new Part() { ID = 2, Brand = "Febi", Item_number = "806034523A", Name = "Water pipe", Price = 300, Weight = 0.5 };
            Part part3 = new Part() { ID = 3, Brand = "Brembo", Item_number = "0871HFSA23", Name = "Brake discs", Price = 20000, Weight = 20 };
            Part part4 = new Part() { ID = 4, Brand = "Continental", Item_number = "700325JS", Name = "Tire", Price = 20000, Weight = 8 };
            Part part5 = new Part() { ID = 5, Brand = "Toyo", Item_number = "00003525GF", Name = "Tire", Price = 25000, Weight = 9 };
            Part part6 = new Part() { ID = 6, Brand = "Hankook", Item_number = "8786662TTR", Name = "Tire", Price = 10000, Weight = 7 };
            Part part7 = new Part() { ID = 7, Brand = "Bosch", Item_number = "998776TZH", Name = "Battery", Price = 50000, Weight = 30 };
            Part part8 = new Part() { ID = 8, Brand = "BBS", Item_number = "6766555657TZ", Name = "Rim", Price = 80000, Weight = 30 };
            Part part9 = new Part() { ID = 9, Brand = "Bosch", Item_number = "6667677676R", Name = "Brake discs", Price = 20000, Weight = 22 };
            Part part10 = new Part() { ID = 10, Brand = "Hella", Item_number = "99998776OP", Name = "Headlights", Price = 60000, Weight = 2 };
            //////////////////////////////////////////////////////////////////////////////////
            Car volkswagen1 = new Car() { ID = 1, BrandID = volkswagen.ID, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Golf II", Production_year = 1989, Brand = volkswagen };
            Car volkswagen2 = new Car() { ID = 2, BrandID = volkswagen.ID, Cylinder_capacity = 2.0, Cylinder_number = 4, Model = "Golf III GTI", Production_year = 1995, Brand = volkswagen };
            Car seat1 = new Car() { ID = 3, BrandID = seat.ID, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Leon", Production_year = 2004, Brand = seat };
            Car audi1 = new Car() { ID = 4, BrandID = audi.ID, Cylinder_capacity = 5.2, Cylinder_number = 10, Model = "R8", Production_year = 2008, Brand = audi };
            Car skoda1 = new Car() { ID = 5, BrandID = skoda.ID, Cylinder_capacity = 1.2, Cylinder_number = 3, Model = "Fabia", Production_year = 1999, Brand = skoda };
            Car porsche1 = new Car() { ID = 6, BrandID = porsche.ID, Cylinder_capacity = 3.8, Cylinder_number = 6, Model = "911 Turbo S", Production_year = 2020, Brand = porsche };
            Car lamborghini1 = new Car() { ID = 7, BrandID = lamborghini.ID, Cylinder_capacity = 6.5, Cylinder_number = 12, Model = "Aventador", Production_year = 2011, Brand = lamborghini };
            Car tesla1 = new Car() { ID = 8, BrandID = tesla.ID, Cylinder_capacity = 0, Cylinder_number = 0, Model = "Model S Plaid", Production_year = 2020, Brand = tesla };
            Car nissan1 = new Car() { ID = 9, BrandID = nissan.ID, Cylinder_capacity = 2.6, Cylinder_number = 6, Model = "Skyline", Production_year = 1999, Brand = nissan };
            Car toyota1 = new Car() { ID = 10, BrandID = toyota.ID, Cylinder_capacity = 3.0, Cylinder_number = 6, Model = "Supra MK4", Production_year = 1992, Brand = toyota };
            Car suzuki1 = new Car() { ID = 11, BrandID = suzuki.ID, Cylinder_capacity = 1.0, Cylinder_number = 3, Model = "Swift", Production_year = 1989, Brand = suzuki };
            Car volkswagen3 = new Car() { ID = 12, BrandID = volkswagen.ID, Cylinder_capacity = 1.9, Cylinder_number = 4, Model = "Touran", Production_year = 2006, Brand = volkswagen };
            Car volkswagen4 = new Car() { ID = 13, BrandID = volkswagen.ID, Cylinder_capacity = 2.0, Cylinder_number = 4, Model = "Tiguan", Production_year = 2016, Brand = volkswagen };
            Car seat2 = new Car() { ID = 14, BrandID = seat.ID, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "Ibiza Cupra", Production_year = 2016, Brand = volkswagen };
            Car audi2 = new Car() { ID = 15, BrandID = audi.ID, Cylinder_capacity = 1.8, Cylinder_number = 4, Model = "TT", Production_year = 2000, Brand = audi };
            Car skoda2 = new Car() { ID = 16, BrandID = skoda.ID, Cylinder_capacity = 2.0, Cylinder_number = 4, Model = "Superb", Production_year = 2015, Brand = skoda };
            Car porsche2 = new Car() { ID = 17, BrandID = porsche.ID, Cylinder_capacity = 0, Cylinder_number = 0, Model = "Taycan", Production_year = 2019, Brand = porsche };
            Car lamborghini2 = new Car() { ID = 18, BrandID = lamborghini.ID, Cylinder_capacity = 4.0, Cylinder_number = 8, Model = "Urus", Production_year = 2018, Brand = lamborghini };
            Car tesla2 = new Car() { ID = 19, BrandID = tesla.ID, Cylinder_capacity = 0, Cylinder_number = 0, Model = "Model X", Production_year = 2015, Brand = tesla };
            Car nissan2 = new Car() { ID = 20, BrandID = nissan.ID, Cylinder_capacity = 3.5, Cylinder_number = 6, Model = "350Z", Production_year = 2003, Brand = nissan };
            Car toyota2 = new Car() { ID = 21, BrandID = toyota.ID, Cylinder_capacity = 1.6, Cylinder_number = 4, Model = "AE86", Production_year = 1983, Brand = toyota };
            Car suzuki2 = new Car() { ID = 22, BrandID = suzuki.ID, Cylinder_capacity = 1.4, Cylinder_number = 4, Model = "Vitara", Production_year = 2018, Brand = suzuki };
            //alkatrészt autóhoz hozzárendelni/////////////////////////////////////////////////////////////////////////////////////////////////
            volkswagen1.CarParts = new List<CarPart>() { new CarPart { CarID = 1, Car = volkswagen1, PartID = 4, Part = part4}, new CarPart { CarID = 1, Car = volkswagen1, PartID = 7, Part = part7}, new CarPart { CarID = 1, Car = volkswagen1, PartID = 10, Part = part10 }, new CarPart { CarID = 1, Car = volkswagen1, PartID = 3, Part = part3} };
            volkswagen2.CarParts = new List<CarPart>() { new CarPart { CarID = 2, Car = volkswagen2, PartID = 4, Part = part4}, new CarPart { CarID = 2, Car = volkswagen2, PartID = 7, Part = part7}, new CarPart { CarID = 2, Car = volkswagen2, PartID = 2, Part = part2} };
            seat1.CarParts = new List<CarPart>() { new CarPart { CarID = 3, Car = seat1, PartID = 5, Part = part5}, new CarPart { CarID = 3, Car = seat1, PartID = 7, Part = part7}, new CarPart { CarID = 3, Car = seat1, PartID = 8, Part = part8 }, new CarPart { CarID = 3, Car = seat1, PartID = 2, Part = part2}, new CarPart { CarID = 3, Car = seat1, PartID = 10, Part = part10 }, new CarPart { CarID = 3, Car = seat1, PartID = 1, Part = part1} };
            audi1.CarParts = new List<CarPart>() { new CarPart { CarID = 4, Car = audi1, PartID = 5, Part = part5}, new CarPart { CarID = 4, Car = audi1, PartID = 7, Part = part7}, new CarPart { CarID = 4, Car = audi1, PartID = 1, Part = part1}, new CarPart { CarID = 4, Car = audi1, PartID = 9, Part = part9 } };
            skoda1.CarParts = new List<CarPart>() { new CarPart { CarID = 5, Car = skoda1, PartID = 6, Part = part6}, new CarPart { CarID = 5, Car = skoda1, PartID = 7, Part = part7}, new CarPart { CarID = 5, Car = skoda1, PartID = 9, Part = part9 }, new CarPart { CarID = 5, Car = skoda1, PartID = 2, Part = part2} };
            porsche1.CarParts = new List<CarPart>() { new CarPart { CarID = 6, Car = porsche1, PartID = 5, Part = part5}, new CarPart { CarID = 6, Car = porsche1, PartID = 7, Part = part7}, new CarPart { CarID = 6, Car = porsche1, PartID = 3, Part = part3}, new CarPart { CarID = 6, Car = porsche1, PartID = 1, Part = part1} };
            lamborghini1.CarParts = new List<CarPart>() { new CarPart { CarID = 7, Car = lamborghini1, PartID = 5, Part = part5}, new CarPart { CarID = 7, Car = lamborghini1, PartID = 7, Part = part7}, new CarPart { CarID = 7, Car = lamborghini1, PartID = 1, Part = part1}, new CarPart { CarID = 7, Car = lamborghini1, PartID = 8, Part = part8 } };
            tesla1.CarParts = new List<CarPart>() { new CarPart { CarID = 8, Car = tesla1, PartID = 6, Part = part6}, new CarPart { CarID = 8, Car = tesla1, PartID = 3, Part = part3} };
            nissan1.CarParts = new List<CarPart>() { new CarPart { CarID = 9, Car = nissan1, PartID = 4, Part = part4}, new CarPart { CarID = 9, Car = nissan1, PartID = 7, Part = part7}, new CarPart { CarID = 9, Car = nissan1, PartID = 9, Part = part9 }, new CarPart { CarID = 9, Car = nissan1, PartID = 8, Part = part8 } };
            toyota1.CarParts = new List<CarPart>() { new CarPart { CarID = 10, Car = toyota1, PartID = 4, Part = part4}, new CarPart { CarID = 10, Car = toyota1, PartID = 7, Part = part7}, new CarPart { CarID = 10, Car = toyota1, PartID = 10, Part = part10 }, new CarPart { CarID = 10, Car = toyota1, PartID = 2, Part = part2} };
            suzuki1.CarParts = new List<CarPart>() { new CarPart { CarID = 11, Car = suzuki1, PartID = 5, Part = part5}, new CarPart { CarID = 11, Car = suzuki1, PartID = 7, Part = part7}, new CarPart { CarID = 11, Car = suzuki1, PartID = 10, Part = part10 }, new CarPart { CarID = 11, Car = suzuki1, PartID = 2, Part = part2} };
            volkswagen3.CarParts = new List<CarPart>() { new CarPart { CarID = 12, Car = volkswagen3, PartID = 6, Part = part6}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 7, Part = part7}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 1, Part = part1}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 8, Part = part8 }, new CarPart { CarID = 12, Car = volkswagen3, PartID = 2, Part = part2} };
            volkswagen4.CarParts = new List<CarPart>() { new CarPart { CarID = 13, Car = volkswagen4, PartID = 5, Part = part5}, new CarPart { CarID = 13, Car = volkswagen4, PartID = 7, Part = part7}, new CarPart { CarID = 13, Car = volkswagen4, PartID = 8, Part = part8 }, new CarPart { CarID = 13, Car = volkswagen4, PartID = 1, Part = part1} };
            seat2.CarParts = new List<CarPart>() { new CarPart { CarID = 14, Car = seat2, PartID = 4, Part = part4}, new CarPart { CarID = 14, Car = seat2, PartID = 7, Part = part7}, new CarPart { CarID = 14, Car = seat2, PartID = 10, Part = part10 } };
            audi2.CarParts = new List<CarPart>() { new CarPart { CarID = 15, Car = audi2, PartID = 6, Part = part6}, new CarPart { CarID = 15, Car = audi2, PartID = 7, Part = part7}, new CarPart { CarID = 15, Car = audi2, PartID = 2, Part = part2}, new CarPart { CarID = 15, Car = audi2, PartID = 8, Part = part8 } };
            skoda2.CarParts = new List<CarPart>() { new CarPart { CarID = 16, Car = skoda2, PartID = 4, Part = part4}, new CarPart { CarID = 16, Car = skoda2, PartID = 7, Part = part7}, new CarPart { CarID = 16, Car = skoda2, PartID = 2, Part = part2} };
            porsche2.CarParts = new List<CarPart>() { new CarPart { CarID = 17, Car = porsche2, PartID = 6, Part = part6} };
            lamborghini2.CarParts = new List<CarPart>() { new CarPart { CarID = 18, Car = lamborghini2, PartID = 4, Part = part4}, new CarPart { CarID = 18, Car = lamborghini2, PartID = 7, Part = part7} };
            tesla2.CarParts = new List<CarPart>() { new CarPart { CarID = 19, Car = tesla2, PartID = 5, Part = part5}, new CarPart { CarID = 19, Car = tesla2, PartID = 6, Part = part6}, new CarPart { CarID = 19, Car = tesla2, PartID = 2, Part = part2} };
            nissan2.CarParts = new List<CarPart>() { new CarPart { CarID = 20, Car = nissan2, PartID = 6, Part = part6}, new CarPart { CarID = 20, Car = nissan2, PartID = 7, Part = part7}, new CarPart { CarID = 20, Car = nissan2, PartID = 8, Part = part8 } };
            toyota2.CarParts = new List<CarPart>() { new CarPart { CarID = 21, Car = toyota2, PartID = 4, Part = part4}, new CarPart { CarID = 21, Car = toyota2, PartID = 7, Part = part7}, new CarPart { CarID = 21, Car = toyota2, PartID = 9, Part = part9 } };
            suzuki2.CarParts = new List<CarPart>() { new CarPart { CarID = 22, Car = suzuki2, PartID = 6, Part = part6}, new CarPart { CarID = 22, Car = suzuki2, PartID = 7, Part = part7}, new CarPart { CarID = 22, Car = suzuki2, PartID = 8, Part = part8 } };
            //alkatrészhez autót////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            part1.CarParts = new List<CarPart>() { new CarPart { CarID = 3, Car = seat1, PartID = 1, Part = part1}, new CarPart { CarID = 4, Car = audi1, PartID = 1, Part = part1}, new CarPart { CarID = 6, Car = porsche1, PartID = 1, Part = part1}, new CarPart { CarID = 7, Car = lamborghini1, PartID = 1, Part = part1}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 1, Part = part1}, new CarPart { CarID = 13, Car = volkswagen4, PartID = 1, Part = part1} };
            part2.CarParts = new List<CarPart>() { new CarPart { CarID = 2, Car = volkswagen2, PartID = 2, Part = part2}, new CarPart { CarID = 3, Car = seat1, PartID = 2, Part = part2}, new CarPart { CarID = 5, Car = skoda1, PartID = 2, Part = part2}, new CarPart { CarID = 10, Car = toyota1, PartID = 2, Part = part2}, new CarPart { CarID = 11, Car = suzuki1, PartID = 2, Part = part2}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 2, Part = part2}, new CarPart { CarID = 15, Car = audi2, PartID = 2, Part = part2}, new CarPart { CarID = 16, Car = skoda2, PartID = 2, Part = part2}, new CarPart { CarID = 19, Car = tesla2, PartID = 2, Part = part2} };
            part3.CarParts = new List<CarPart>() { new CarPart { CarID = 6, Car = porsche1, PartID = 3, Part = part3}, new CarPart { CarID = 1, Car = volkswagen1, PartID = 3, Part = part3}, new CarPart { CarID = 8, Car = tesla1, PartID = 3, Part = part3} };
            part4.CarParts = new List<CarPart>() { new CarPart { CarID = 1, Car = volkswagen1, PartID = 4, Part = part4}, new CarPart { CarID = 2, Car = volkswagen2, PartID = 4, Part = part4}, new CarPart { CarID = 9, Car = nissan1, PartID = 4, Part = part4}, new CarPart { CarID = 10, Car = toyota1, PartID = 4, Part = part4}, new CarPart { CarID = 14, Car = seat2, PartID = 4, Part = part4}, new CarPart { CarID = 16, Car = skoda2, PartID = 4, Part = part4}, new CarPart { CarID = 18, Car = lamborghini2, PartID = 4, Part = part4}, new CarPart { CarID = 21, Car = toyota2, PartID = 4, Part = part4} };
            part5.CarParts = new List<CarPart>() { new CarPart { CarID = 3, Car = seat1, PartID = 5, Part = part5}, new CarPart { CarID = 4, Car = audi1, PartID = 5, Part = part5}, new CarPart { CarID = 6, Car = porsche1, PartID = 5, Part = part5}, new CarPart { CarID = 7, Car = lamborghini1, PartID = 5, Part = part5}, new CarPart { CarID = 11, Car = suzuki1, PartID = 5, Part = part5}, new CarPart { CarID = 13, Car = volkswagen4, PartID = 5, Part = part5}, new CarPart { CarID = 19, Car = tesla2, PartID = 5, Part = part5} };
            part6.CarParts = new List<CarPart>() { new CarPart { CarID = 5, Car = skoda1, PartID = 6, Part = part6}, new CarPart { CarID = 8, Car = tesla1, PartID = 6, Part = part6}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 6, Part = part6}, new CarPart { CarID = 15, Car = audi2, PartID = 6, Part = part6}, new CarPart { CarID = 17, Car = porsche2, PartID = 6, Part = part6}, new CarPart { CarID = 19, Car = tesla2, PartID = 6, Part = part6}, new CarPart { CarID = 20, Car = nissan2, PartID = 6, Part = part6}, new CarPart { CarID = 22, Car = suzuki2, PartID = 6, Part = part6} };
            part7.CarParts = new List<CarPart>() { new CarPart { CarID = 1, Car = volkswagen1, PartID = 7, Part = part7}, new CarPart { CarID = 2, Car = volkswagen2, PartID = 7, Part = part7}, new CarPart { CarID = 3, Car = seat1, PartID = 7, Part = part7}, new CarPart { CarID = 4, Car = audi1, PartID = 7, Part = part7}, new CarPart { CarID = 5, Car = skoda1, PartID = 7, Part = part7}, new CarPart { CarID = 6, Car = porsche1, PartID = 7, Part = part7}, new CarPart { CarID = 7, Car = lamborghini1, PartID = 7, Part = part7}, new CarPart { CarID = 9, Car = nissan1, PartID = 7, Part = part7}, new CarPart { CarID = 10, Car = toyota1, PartID = 7, Part = part7}, new CarPart { CarID = 11, Car = suzuki1, PartID = 7, Part = part7}, new CarPart { CarID = 12, Car = volkswagen3, PartID = 7, Part = part7}, new CarPart { CarID = 13, Car = volkswagen4, PartID = 7, Part = part7}, new CarPart { CarID = 14, Car = seat2, PartID = 7, Part = part7}, new CarPart { CarID = 15, Car = audi2, PartID = 7, Part = part7}, new CarPart { CarID = 16, Car = skoda2, PartID = 7, Part = part7}, new CarPart { CarID = 18, Car = lamborghini2, PartID = 7, Part = part7}, new CarPart { CarID = 20, Car = nissan2, PartID = 7, Part = part7}, new CarPart { CarID = 21, Car = toyota2, PartID = 7, Part = part7}, new CarPart { CarID = 22, Car = suzuki2, PartID = 7, Part = part7}, };
            part8.CarParts = new List<CarPart>() { new CarPart { CarID = 3, Car = seat1, PartID = 8, Part = part8 }, new CarPart { CarID = 7, Car = lamborghini1, PartID = 8, Part = part8 }, new CarPart { CarID = 9, Car = nissan1, PartID = 8, Part = part8 }, new CarPart { CarID = 12, Car = volkswagen3, PartID = 8, Part = part8 }, new CarPart { CarID = 13, Car = volkswagen4, PartID = 8, Part = part8 }, new CarPart { CarID = 15, Car = audi2, PartID = 8, Part = part8 }, new CarPart { CarID = 20, Car = nissan2, PartID = 8, Part = part8 }, new CarPart { CarID = 22, Car = suzuki2, PartID = 8, Part = part8 } };
            part9.CarParts = new List<CarPart>() { new CarPart { CarID = 4, Car = audi1, PartID = 9, Part = part9 }, new CarPart { CarID = 5, Car = skoda1, PartID = 9, Part = part9 }, new CarPart { CarID = 9, Car = nissan1, PartID = 9, Part = part9 }, new CarPart { CarID = 21, Car = toyota2, PartID = 9, Part = part9 } };
            part10.CarParts = new List<CarPart>() { new CarPart { CarID = 1, Car = volkswagen1, PartID = 10, Part = part10 }, new CarPart { CarID = 3, Car = seat1, PartID = 10, Part = part10 }, new CarPart { CarID = 10, Car = toyota1, PartID = 10, Part = part10 }, new CarPart { CarID = 11, Car = suzuki1, PartID = 10, Part = part10 }, new CarPart { CarID = 14, Car = seat2, PartID = 10, Part = part10 } };
            //autót márkához hozzárendelni//////////////////////////////////////////////////////////////////////////////////////////////////
            volkswagen.Cars = new List<Car>() { volkswagen1, volkswagen2, volkswagen3, volkswagen4 };
            seat.Cars = new List<Car>() { seat1, seat2 };
            audi.Cars = new List<Car>() { audi1, audi2 };
            skoda.Cars = new List<Car>() { skoda1, skoda2 };
            porsche.Cars = new List<Car>() { porsche1, porsche2 };
            lamborghini.Cars = new List<Car>() { lamborghini1, lamborghini2 };
            tesla.Cars = new List<Car>() { tesla1, tesla2 };
            nissan.Cars = new List<Car>() { nissan1, nissan2 };
            toyota.Cars = new List<Car>() { toyota1, toyota2 };
            suzuki.Cars = new List<Car>() { suzuki1, suzuki2 };
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var mockCarRepo = new Mock<ICarRepo>();
            var mockbrandRepo = new Mock<IBrandRepo>();

            var brands = new List<Brand>() { volkswagen, seat, audi, skoda, porsche, lamborghini, tesla, nissan, toyota, suzuki };

            var cars = new List<Car>() { volkswagen1, volkswagen2, volkswagen3, volkswagen4, seat1, seat2, audi1, audi2, skoda1, skoda2, porsche1, porsche2, lamborghini1, lamborghini2, tesla1, tesla2, nissan1, nissan2, toyota1, toyota2, suzuki1, suzuki2 };

            //mocked crud methods
            mockCarRepo.Setup(x => x.Update(It.IsAny<Car>())).Callback<Car>(car =>
              {
                  Car toupdate = cars.Find(toupdate => toupdate.ID == car.ID);
                  toupdate.Cylinder_number = car.Cylinder_number;
                  toupdate.Cylinder_capacity = car.Cylinder_capacity;
                  toupdate.CarParts = car.CarParts;
                  toupdate.BrandID = car.BrandID;
                  toupdate.Brand = car.Brand;
                  toupdate.Model = car.Model;
                  toupdate.Production_year = car.Production_year;
                  toupdate = car;
  
              });
            mockCarRepo.Setup(x => x.Create(It.IsAny<Car>())).Callback<Car>(car => cars.Add(car));//OK
            mockCarRepo.Setup(x => x.ReadAll()).Returns(cars.AsQueryable());//OK
            mockCarRepo.Setup(x => x.Read(It.IsAny<int>())).Returns((int i) => cars.Where(x => x.ID == i).Single());//OK
            mockCarRepo.Setup(x => x.Delete(It.IsAny<int>())).Callback<int>(i =>
              {
                  Car todelete=cars.Find(car => car.ID == i);
                  cars.Remove(todelete);
              });
            
            mockbrandRepo.Setup(x => x.ReadAll()).Returns(brands.AsQueryable());//OK
            mockbrandRepo.Setup(x => x.Read(It.IsAny<int>())).Returns((int i) => brands.Where(x => x.ID == i).Single());//OK
            mockbrandRepo.Setup(x => x.Create(It.IsAny<Brand>())).Callback<Brand>(brand => brands.Add(brand));
            mockbrandRepo.Setup(x => x.Update(It.IsAny<Brand>())).Callback<Brand>(brand =>
            {
                Brand toupdate = brands.Find(toupdate => toupdate.ID == brand.ID);
                toupdate.Cars = brand.Cars;
                toupdate.Name = brand.Name;
                toupdate = brand;
            });
            mockbrandRepo.Setup(x => x.Delete(It.IsAny<int>())).Callback<int>(i =>
            {
                Brand todelete = brands.Find(brand => brand.ID == i);
                brands.Remove(todelete);
            });

            cl = new CarLogic(mockCarRepo.Object);
            bl = new BrandLogic(mockbrandRepo.Object);
            ;
        }
        [Test]
        public void Top2CarsWithTheMostCompatibleParts()
        {
            var results = cl.Top3CarsWithTheMostCompatibleParts().ToArray();
            string result = "";
            for (int i = 0; i < results.Length-1; i++)
            {
                result += results[i].Value[0].Value.ToUpper() + " " + results[i].Value[1].Value.ToUpper();
                if (i!=results.Length-2)
                {
                    result += ", ";
                }
            }
            string expected = "SEAT LEON, VOLKSWAGEN TOURAN";

            Assert.That(result, Is.EqualTo(expected));
        }//linq1
        [Test]
        public void AvgCylinderCapBrands()
        {
            var results = cl.AvgCylinderCapBrands().ToArray();
            Dictionary<string, double> result = new Dictionary<string, double>();
            for (int i = 0; i < results.Length; i++)
            {
                result.Add(results[i].Value.Key, results[i].Value.Value.Value);
            }
            Assert.That(result["Volkswagen"]==1.9 && result["SEAT"]==1.8 && result["Audi"]==3.5 && result["Skoda"]==1.6 && result["Porsche"]==1.9 && result["Lamborghini"]==5.2 && result["Tesla"]==0 && result["Nissan"]==3 && result["Toyota"]==2.3 && result["Suzuki"]==1.2)
            ;
            
        }//linq2 OK
        [Test]
        public void BremboUserBrands()
        {
            var result = bl.BremboUserBrands().ToList();
            List<string> names = new List<string>();
            for (int i = 0; i < result.Count; i++)
            {
                names.Add(result[i].Value);
            }
            Assert.That(names.Contains("Volkswagen") && names.Contains("Tesla") && names.Contains("Porsche"));
            ;
        }//linq3 OK
        [Test]
        public void BrandsWithElectricCars()
        {
            var result = bl.BrandsWithElectricCars().ToList();
            List<string> names = new List<string>();
            for (int i = 0; i < result.Count; i++)
            {
                names.Add(result[i].Value);
            }
            Assert.That(names.Contains("Tesla") && names.Contains("Porsche"));
            ;
        }//linq4 OK
        [Test]
        public void BrandWithTheMost4CylinderCar()
        {
            Assert.That(bl.BrandWithTheMost4CylinderCar().ToList()[0].Value == "Volkswagen");
        }//linq5 OK
        [TestCase("TestBrand", -2.0, 3)]
        [TestCase("", 2.0, 3)]
        [TestCase("TestBrand", 2.0, -3)]
        public void CarCreateExeptionTest(string modelname, double cap, int cyl)
        {
            Brand testbrand = new Brand { ID = 99, Name = "TestBrand" };
            Car testcar = new Car() { ID = 29, BrandID = 99, Cylinder_capacity = cap, Cylinder_number = cyl, Model = modelname, Production_year = 1999, Brand = testbrand, CarParts = null };
            testbrand.Cars.Add(testcar);

            Assert.Throws(typeof(ArgumentException), () => cl.Create(testcar));

        }//OK
        [Test]
        public void CarCreateTest()
        {
            Brand testbrand = new Brand { ID = 99, Name = "TestBrand" };
            Car testcar = new Car() { ID = 29, BrandID = 99, Cylinder_capacity = 3.0, Cylinder_number = 8, Model = "TestCar", Production_year = 1999, Brand = testbrand, CarParts = null };
            testbrand.Cars.Add(testcar);

            cl.Create(testcar);
            Assert.That(cl.Read(testcar.ID) == testcar);
        }//függ a readtől
        [TestCase(-1)]
        [TestCase(99)]
        public void CarReadExeptionTest(int id)
        {

            Assert.Throws(typeof(ArgumentException), () => cl.Read(id));
        }//OK
        [Test]
        public void CarReadTest()
        {
            Brand volkswagen = new Brand() { ID = 1, Name = "Volkswagen" };
            Car volkswagen3 = new Car() { ID = 12, BrandID = volkswagen.ID, Cylinder_capacity = 1.9, Cylinder_number = 4, Model = "Touran", Production_year = 2006, Brand = volkswagen };
            Assert.That(volkswagen3, Is.EqualTo(cl.Read(12)));
        }//OK
        [Test]
        public void CarUpdateTest()//függ a readtől
        {
            Brand testbrand = new Brand { ID = 29, Name = "TestBrand" };
            Car testcar = new Car() { ID = 1, BrandID = 99, Cylinder_capacity = 3.0, Cylinder_number = 8, Model = "TestCar", Production_year = 1999, Brand = testbrand, CarParts = null };
            testbrand.Cars.Add(testcar);
            cl.Update(testcar);
            Assert.That(cl.Read(testcar.ID), Is.EqualTo(testcar));
            ;
        }
        [Test]
        public void CarDeleteTest()//függ a readtől
        {
            cl.Delete(1);
            Assert.Throws(typeof(ArgumentException), ()=> cl.Read(1));
            ;
        }

        [TestCase("", 88)]
        [TestCase("TestBrand", -1)]
        public void BrandCreateExeptionTest(string brandname, int id)
        {
            Brand testbrand = new Brand { ID = id, Name = brandname };

            Assert.Throws(typeof(ArgumentException), () => bl.Create(testbrand));

        }//OK
        [Test]
        public void BrandCreateTest()
        {
            Brand testbrand = new Brand { ID = 99, Name = "TestBrand" };
            bl.Create(testbrand);
            Assert.That(bl.Read(testbrand.ID) == testbrand);
        }//függ a readtől
        [TestCase(-1)]
        [TestCase(99)]
        public void BrandReadExeptionTest(int id)
        {

            Assert.Throws(typeof(ArgumentException), () => bl.Read(id));
        }//OK
        [Test]
        public void BrandReadTest()
        {
            Brand volkswagen = new Brand() { ID = 1, Name = "Volkswagen" };
            Assert.That(volkswagen, Is.EqualTo(bl.Read(1)));
        }//OK
        [Test]
        public void BrandUpdateTest()//függ a readtől
        {
            Brand testbrand = new Brand { ID = 1, Name = "TestBrand" };
            bl.Update(testbrand);
            Assert.That(bl.Read(testbrand.ID), Is.EqualTo(testbrand));
        }
        [Test]
        public void BrandDeleteTest()//függ a readtől
        {
            bl.Delete(1);
            Assert.Throws(typeof(ArgumentException), () => bl.Read(1));
            ;
        }



    }
}
