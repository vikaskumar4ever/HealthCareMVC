using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Services.Model;
using SI.Meditourism.Services.BAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class GetTreatMentDetailsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            GetServicedetail objReturn = new GetServicedetail();
            using (Service_BAL objBAL = new Service_BAL())
            {
                objReturn = objBAL.GetTreatMentDetails(id);
            }
            Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new  Newtonsoft.Json.JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(objReturn, jsonSerializerSettings);

            return Json(result);
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
