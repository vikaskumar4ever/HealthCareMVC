using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.PaymentServicesAdmin.Model;
using SI.Meditourism.PaymentServicesAdmin.BAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class TreatmentPaymentDetailsPagelstController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{PageNo}/{PageSize}/{ServiceId}/{CustomerId}")]
        public TreatmentPaymentDetailsPage Get(int PageNo, string PageSize, Guid? ServiceId, Guid? CustomerId)
        {
            TreatmentPaymentDetailsPage _objReturn = new TreatmentPaymentDetailsPage();
            int iPageSize = Convert.ToInt32(PageSize);
            using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
            {
                _objReturn = _objBAL.GetRecordsPage(PageNo, iPageSize, ServiceId, CustomerId);
            }
            return _objReturn;
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
