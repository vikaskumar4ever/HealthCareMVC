using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.CustomerInfo.Model;
using SI.Meditourism.CustomerInfo.BAL;
using SI.Meditourism.Common;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class RegistationCustomerController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{EmailId}")]
        public bool Get(string EmailId)
        {
            bool _objreturn = false;
            if (EmailId != null)
            {
                using (Customer_BAL _objBAL = new Customer_BAL())
                {
                    _objreturn = _objBAL.ValidateEmailIdIsExist(EmailId);
                }
            }
            return _objreturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post(string Name,string PhoneNo,string EmailId, string Country, Guid CustomerId)
        {
            DateTimeFormatToIST _objdateTimeFormatToIST = new DateTimeFormatToIST();
            DefaultResult objReturn = new DefaultResult();
            Customer collection = new Customer();
            collection.CustomerId = CustomerId;
            collection.IsDeleted = false;
            collection.IsActive = false;
            collection.Name = Name;
            collection.PhoneNo = PhoneNo;
            collection.Email = EmailId;
            collection.Country = Country;
            string Password = RandomString(9);
            string hashPassword = Encryption256AES.EncryptionLibrary.EncryptText(Password);
            collection.Password = hashPassword;
            collection.CreationDate = _objdateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
            collection.UpdatedDate = _objdateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);

            using (Customer_BAL _objBAL = new Customer_BAL())
            {
                objReturn.Data = _objBAL.InsertUpdateRecord(collection).ToString();
            }
            return objReturn;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
