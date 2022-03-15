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
    public class PartController : ControllerBase
    {
        IPartLogic partLogic;
        IHubContext<SiganlRHub> hub;
        public PartController(IPartLogic partLogic, IHubContext<SiganlRHub> hub)
        {
            this.partLogic = partLogic;
            this.hub = hub;
        }
        
        // GET: api/<PartController>
        [HttpGet]
        public IEnumerable<Part> Get()
        {
            var parts = partLogic.ReadAll();
            return parts;
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
            hub.Clients.All.SendAsync("PartCreated", value);
        }

        // PUT api/<PartController>/5
        [HttpPut]
        public void Put([FromBody] Part value)
        {
            partLogic.Update(value);
            hub.Clients.All.SendAsync("PartUpdated", value);
        }

        // DELETE api/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value=partLogic.Read(id);
            partLogic.Delete(id);
            hub.Clients.All.SendAsync("PartDeleted", value);
        }
    }
}
