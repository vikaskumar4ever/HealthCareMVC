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
    public class ContactUsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ContactUs> Get()
        {
            List<ContactUs> objReturn = new List<ContactUs>();
            using (ContactUs_BAL objBal = new ContactUs_BAL())
            {
                objReturn = objBal.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ContactUsDetails Get(Guid id)
        {
            ContactUsDetails objReturn = new ContactUsDetails();
            using (ContactUs_BAL objBal = new ContactUs_BAL())
            {
                objReturn = objBal.GetRecorodById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]ContactUs value)
        {
            DateTimeFormatToIST _ObjDateTimeFormatToIST = new DateTimeFormatToIST();
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.ContactUsId = Guid.NewGuid();
                value.CreationDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
            }
            value.UpdatedDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
            value.IsDeleted = false;
            using (ContactUs_BAL objBAL = new ContactUs_BAL())
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
            DefaultResult objreturn = new DefaultResult();
            using (ContactUs_BAL _objBal = new ContactUs_BAL())
            {
                objreturn.Status =_objBal.DeleteRecord(id);
            }
            return objreturn;
        }
    }
}
