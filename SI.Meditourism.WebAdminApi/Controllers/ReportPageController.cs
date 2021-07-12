using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SI.Meditourism.Reports.BAL;
using SI.Meditourism.Reports.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class ReportPageController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{PageNo}/{PageSize}")]
        public ReportPage Get(int PageNo, string PageSize)
        {
            int iPageSize = Convert.ToInt32(PageSize);
            ReportPage objReturn = new ReportPage();
            using (Report_BAL objBAL = new Report_BAL())
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
