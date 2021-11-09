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
    public class BrandController : ControllerBase
    {
        IBrandLogic brandLogic;
        public BrandController(IBrandLogic brandLogic)
        {
            this.brandLogic = brandLogic;
        }
        
        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return brandLogic.ReadAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return brandLogic.Read(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            brandLogic.Create(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            brandLogic.Update(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            brandLogic.Delete(id);
        }
    }
}
