using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SI.Meditourism.Services.BAL;
using SI.Meditourism.Services.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class FilterServicesByNameController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{Name}")]
        public List<Service> Get(string Name)
        {
            List<Service> objServicesName = new List<Service>();
            using (Service_BAL objBal = new Service_BAL())
            {
                objServicesName = objBal.GetFilterServices(Name);
            }
            return objServicesName;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
