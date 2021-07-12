using System;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SI.Meditourism.Reports.BAL;
using SI.Meditourism.Reports.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Report> Get()
        {
            List<Report> objReturn = new List<Report>();
            using (Report_BAL objBal = new Report_BAL())
            {
                objReturn = objBal.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public List<Reportlist> Get(Guid id)
        {
            List<Reportlist> objReturn = new List<Reportlist>();
            using (Report_BAL objBal = new Report_BAL())
            {
                objReturn = objBal.GetRecorodById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]Report value)
        {
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.ReportId = Guid.NewGuid();
                value.CreationDate = DateTime.Now;
                value.CustomerId = value.CustomerId;
            }
            value.UpdatedDate = DateTime.Now;
            value.IsDeleted = false;
            using (Report_BAL objBAL = new Report_BAL())
            {
                objReturn.Data = objBAL.InsertUpdateRecord(value).ToString();
            }
            return objReturn;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public DefaultResult Delete(int id)
        {
            DefaultResult objReturn = new DefaultResult();
            using (Report_BAL objBAL = new Report_BAL())
            {
                objReturn.Status = objBAL.DeleteRecord(id);
            }
            return objReturn;
        }
    }
}
