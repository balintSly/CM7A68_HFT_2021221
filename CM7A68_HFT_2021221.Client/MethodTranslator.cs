using CM7A68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM7A68_HFT_2021221.Client
{
    class MethodTranslator
    {
        RestService restService ;
        public MethodTranslator()
        {
            this.restService = new RestService("http://localhost:50874");
        }
        //readalls//////////////////////////////////////////////
        public List<Brand> GetAllBrand()
        { 
        return restService.Get<Brand>("brand");
        }
        public List<Car> GetAllCar()
        {
            return restService.Get<Car>("car");
        }
        public List<Part> GetAllPart()
        {
            return restService.Get<Part>("part");
        }
        //reads////////////////////////////////////////////////
        public Brand GetBrand(int id)
        {
            return restService.Get<Brand>(id, "brand");
        }
        public Car GetCar(int id)
        {
            return restService.Get<Car>(id, "car");
        }
        public Part GetPart(int id)
        {
            return restService.Get<Part>(id, "part");
        }
        //creates//////////////////////////////////////////////
        public void CreateBrand(Brand brand)
        {
            restService.Post<Brand>(brand, "brand");//create
        }
        public void CreateCar(Car car)
        {
            restService.Post<Car>(car, "car");//create
        }
        public void CreatePart(Part part)
        {
            restService.Post<Part>(part, "part");//create
        }
        //updates//////////////////////////////////////////////
        public void UpdateBrand(Brand brand)
        {
            restService.Put<Brand>(brand, "brand");
        }
        public void UpdateCar(Car car)
        {
            restService.Put<Car>(car, "car");
        }
        public void UpdatePart(Part part)
        {
            restService.Put<Part>(part, "part");
        }
        //deletes//////////////////////////////////////////////
        public void DeleteBrand(int id)
        {
            restService.Delete(id, "brand");
        }
        public void DeleteCar(int id)
        {
            restService.Delete(id, "car");
        }
        public void DeletePart(int id)
        {
            restService.Delete(id, "part");
        }
        //queries//////////////////////////////////////////////
        public List<KeyValuePair<string, string>> BremboUserBrands()
        {
            return restService.Get<KeyValuePair<string, string>>("noncrud/brembouserbrands");
        }
        public List<KeyValuePair<string, string>> BrandsWithElectricCars()
        {
            return restService.Get<KeyValuePair<string, string>>("noncrud/brandswithelectriccars");
        }
        public List<KeyValuePair<string, string>> BrandWithTheMost4CylinderCar()
        {
            return restService.Get<KeyValuePair<string, string>>("noncrud/brandwiththemost4cylindercar");
        }
        public List<KeyValuePair<string, List<KeyValuePair<string, string>>>> Top3CarsWithTheMostCompatibleParts()
        {
            return restService.Get<KeyValuePair<string, List<KeyValuePair<string, string>>>>("noncrud/top3carswiththemostcompatibleparts");
        }
        public List<KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>> AvgCylinderCapBrands()
        {
            return restService.Get<KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>> > ("noncrud/avgcylindercapbrands");
        }

    }
}
