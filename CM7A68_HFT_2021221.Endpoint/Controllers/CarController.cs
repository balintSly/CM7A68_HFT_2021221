using CM7A68_HFT_2021221.Logic;
using CM7A68_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM7A68_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic carLogic;
        public CarController(ICarLogic carLogic)
        {
            this.carLogic = carLogic;
        }
        
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return carLogic.ReadAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return carLogic.Read(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            carLogic.Create(value);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Put([FromBody] Car value)
        {
            carLogic.Update(value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            carLogic.Delete(id);
        }
    }
}
