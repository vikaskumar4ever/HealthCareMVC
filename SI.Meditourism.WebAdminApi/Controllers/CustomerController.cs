using System;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SI.Meditourism.CustomerInfo.BAL;
using SI.Meditourism.CustomerInfo.Model;
using SI.Meditourism.Encryption256AES;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            List<Customer> objReturn = new List<Customer>();
            using (Customer_BAL objBal = new Customer_BAL())
            {
                objReturn = objBal.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            Customer objReturn = new Customer();
            using (Customer_BAL objBal = new Customer_BAL())
            {
                objReturn = objBal.GetRecorodById(id);
                if (objReturn != null)
                {
                    objReturn.Password = Encryption256AES.EncryptionLibrary.DecryptText(objReturn.Password);
                }
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]Customer value)
        {
            DateTimeFormatToIST _ObjDateTimeFormatToIST = new DateTimeFormatToIST();
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.CustomerId = Guid.NewGuid();
                value.CreationDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                value.IsActive = false;
                value.IsPaymentCompleted = false;

                string Password = RandomString(9);
                var encryptedPassword = EncryptionLibrary.EncryptText(Password);
                value.Password = encryptedPassword;
            }
            else
            {
                var encryptedPassword = EncryptionLibrary.EncryptText(value.Password);
                value.Password = encryptedPassword;
            }
            value.UpdatedDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
            value.IsDeleted = false;
            using (Customer_BAL objBAL = new Customer_BAL())
            {
                objReturn.Data = objBAL.InsertUpdateRecord(value).ToString();
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
        public DefaultResult Delete(int id)
        {
            DefaultResult objReturn = new DefaultResult();
            using (Customer_BAL objBAL = new Customer_BAL())
            {
                objReturn.Status = objBAL.DeleteRecord(id);
            }
            return objReturn;
        }
    }
}
