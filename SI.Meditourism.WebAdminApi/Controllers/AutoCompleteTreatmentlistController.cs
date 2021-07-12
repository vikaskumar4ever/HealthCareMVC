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
    public class AutoCompleteTreatmentlistController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get(string  term)
        {
            List<Treatmentlist> _objReturn = new List<Treatmentlist>();
            List<string> Result;
            using (Service_BAL _objBAL = new Service_BAL())
            {
                _objReturn = _objBAL.GetTreatmentlistautocompt(term);
            }
            Result = _objReturn.Select(x => x.ServiceName).ToList();
            return Json(Result);
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
