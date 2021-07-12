using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Common;
using SI.Meditourism.ChatingService.Model;
using SI.Meditourism.ChatingService.BAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class SendCustomerMessagesController : Controller
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
        public void Post(string Message,string CustomerId)
        {
            if (Message != null && CustomerId != null)
            {
                DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
                AdminCustomerChat collection = new AdminCustomerChat();
                collection.AdminCustomerChatId = Guid.NewGuid();
                collection.IsAdmin = false;
                collection.IsActive = true;
                collection.IsDeleted = false;
                Guid Customer_Id = new Guid(CustomerId);
                collection.CreatedBy = Customer_Id;
                collection.UpdatedBy = Customer_Id;
                collection.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                collection.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                collection.CustomerId = Customer_Id;
                collection.Message = Message;
                using (AdminCustomerChat_BAL objBAL = new AdminCustomerChat_BAL())
                {
                    objBAL.InsertUpdateRecord(collection);
                }
            }
          
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
