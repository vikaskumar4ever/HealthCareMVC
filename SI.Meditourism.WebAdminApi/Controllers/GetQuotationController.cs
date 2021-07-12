using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Master.BAL;
using SI.Meditourism.Master.Model;
using SI.Meditourism.Services.Model;
using SI.Meditourism.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class GetQuotationController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public Service Post(string Name, string MobileNo, string EmailId, string Message, string Country, Guid ServiceId)
        {
            Service _objServices = new Service();
            ContactUs collection = new ContactUs();
            DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
            using (ContactUs_BAL objBAL = new ContactUs_BAL())
            {
                collection.ContactUsId = Guid.NewGuid();
                collection.Name = Name;
                collection.MobileNo = MobileNo;
                collection.EmailId = EmailId;
                collection.Message = Message;
                collection.Country = Country;
                collection.ServiceId = ServiceId;
                collection.IsActive = true;
                collection.IsDeleted = false;
                collection.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                collection.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                _objServices = objBAL.GetQuotation(collection);
            }
            return _objServices;
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
