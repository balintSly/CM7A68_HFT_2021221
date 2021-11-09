using CM7A68_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM7A68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        ICarLogic carLogic;
        IBrandLogic brandLogic;
        public NonCrudController(ICarLogic carLogic, IBrandLogic brandLogic)
        {
            this.brandLogic = brandLogic;
            this.carLogic = carLogic;
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> BremboUserBrands()
        {
            return brandLogic.BremboUserBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> BrandsWithElectricCars()
        {
            return brandLogic.BrandsWithElectricCars();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> BrandWithTheMost4CylinderCar()
        {
            return brandLogic.BrandWithTheMost4CylinderCar();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, List<KeyValuePair<string, string>>>> Top3CarsWithTheMostCompatibleParts()
        {
            return carLogic.Top3CarsWithTheMostCompatibleParts();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>> AvgCylinderCapBrands()
        {
            return carLogic.AvgCylinderCapBrands();
        }
    }
}
