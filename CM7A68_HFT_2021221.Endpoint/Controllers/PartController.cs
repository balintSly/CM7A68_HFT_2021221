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
    public class PartController : ControllerBase
    {
        IPartLogic partLogic;
        public PartController(IPartLogic partLogic)
        {
            this.partLogic = partLogic;
        }
        
        // GET: api/<PartController>
        [HttpGet]
        public IEnumerable<Part> Get()
        {
            return partLogic.ReadAll();
        }

        // GET api/<PartController>/5
        [HttpGet("{id}")]
        public Part Get(int id)
        {
            return partLogic.Read(id);
        }

        // POST api/<PartController>
        [HttpPost]
        public void Post([FromBody] Part value)
        {
            partLogic.Create(value);
        }

        // PUT api/<PartController>/5
        [HttpPut]
        public void Put([FromBody] Part value)
        {
            partLogic.Update(value);
        }

        // DELETE api/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            partLogic.Delete(id);
        }
    }
}
