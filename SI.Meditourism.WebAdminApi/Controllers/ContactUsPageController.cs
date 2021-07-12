using System;
using System.Linq;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Master.BAL;
using System.Collections.Generic;
using SI.Meditourism.Master.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactUsPageController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{PageNo}/{PageSize}")]
        public ContactUsPage Get(int PageNo, string PageSize)
        {
            int iPageSize = Convert.ToInt32(PageSize);
            ContactUsPage objReturn = new ContactUsPage();
            using (ContactUs_BAL objBAL = new ContactUs_BAL())
            {
                objReturn = objBAL.GetRecordsPage(PageNo, iPageSize);
            }
            return objReturn;
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
