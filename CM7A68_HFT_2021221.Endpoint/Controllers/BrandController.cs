using CM7A68_HFT_2021221.Endpoint.Services;
using CM7A68_HFT_2021221.Logic;
using CM7A68_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SiganlRHub> hub;
        public BrandController(IBrandLogic brandLogic, IHubContext<SiganlRHub> hub)
        {
            this.brandLogic = brandLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("BrandCreated", value);
            hub.Clients.All.SendAsync("CarUpdated", null);
            hub.Clients.All.SendAsync("PartUpdated", null);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            brandLogic.Update(value);
            hub.Clients.All.SendAsync("BrandUpdated", value);
             hub.Clients.All.SendAsync("CarUpdated", null);
            hub.Clients.All.SendAsync("PartUpdated", null);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted=brandLogic.Read(id);         
            brandLogic.Delete(id);
            hub.Clients.All.SendAsync("BrandDeleted", deleted);
             hub.Clients.All.SendAsync("CarUpdated", null);
            hub.Clients.All.SendAsync("PartUpdated", null);
        }
    }
}
