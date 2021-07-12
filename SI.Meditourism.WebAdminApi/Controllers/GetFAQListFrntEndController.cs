using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.FAQInfo.BAL;
using SI.Meditourism.FAQInfo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class GetFAQListFrntEndController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public FAQlistFrntEnd Get()
        {
            FAQlistFrntEnd _objFAQlistFrntEnd = new FAQlistFrntEnd();
            List<FAQList> _objfaqlist = new List<FAQList>();
            using (FAQ_BAL _objBAL = new FAQ_BAL())
            {
                _objFAQlistFrntEnd = _objBAL.GetFAQListFrntEnd();
               
            }
            return _objFAQlistFrntEnd;
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
