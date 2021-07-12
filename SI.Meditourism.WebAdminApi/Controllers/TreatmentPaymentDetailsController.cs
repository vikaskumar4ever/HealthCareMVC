using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Common;
using SI.Meditourism.PaymentServicesAdmin.BAL;
using SI.Meditourism.PaymentServicesAdmin.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class TreatmentPaymentDetailsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public TreatmentPagelst Get(Guid? id)
        {
            TreatmentPagelst _TreatmentPaymentDetails = new TreatmentPagelst();
            using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
            {
                _TreatmentPaymentDetails = _objBAL.GetRecorodById(id);
            }
            return _TreatmentPaymentDetails;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]TreatmentPaymentDetails value)
        {
            DefaultResult _objReturn = new DefaultResult();
            DateTimeFormatToIST _dateTimeFormatToIST = new DateTimeFormatToIST();
            if (value.Id == 0)
            {
                value.PaymentId = Guid.NewGuid();
                value.CreationDate = Convert.ToString(_dateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow));
            }
            value.IsDeleted = false;
            using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
            {
                _objReturn.Data = _objBAL.InsertUpdateRecord(value).ToString();
            }
            return _objReturn;
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
            DefaultResult _objReturn = new DefaultResult();
            using (TreatmentPaymentDetails_BAL _objBAL = new TreatmentPaymentDetails_BAL())
            {
                _objReturn.Status = _objBAL.DeleteRecord(id);
            }
            return _objReturn;
        }
    }
}
