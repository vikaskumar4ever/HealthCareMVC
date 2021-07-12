using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Master.Model;
using SI.Meditourism.Master.BAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class GetHospitalDetailsFrntEndController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<HospitalDetails> Get()
        {
            List<HospitalDetails> objhospitalDetails = new List<HospitalDetails>();
            using (HospitalDetails_BAL _objBAL = new HospitalDetails_BAL())
            {
                objhospitalDetails = _objBAL.GetAllHospitalDetailsFrntEnd();
            }
            return objhospitalDetails;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
