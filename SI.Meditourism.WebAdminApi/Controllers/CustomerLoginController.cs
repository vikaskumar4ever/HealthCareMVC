using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.CustomerInfo.BAL;
using SI.Meditourism.CustomerInfo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerLoginController : Controller
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
        [HttpGet("{Email}/{PhoneNo}")]
        public Customer GetRecorodByEmailAndPhone(string Email, string PhoneNo)
        {
            Customer objReturn = new Customer();
            using (Customer_BAL objBAL = new Customer_BAL())
            {
                objReturn = objBAL.GetRecorodByEmailAndPhone(Email, PhoneNo);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public Customer Post(string Username, string Password)
        {
            Customer _objCustomer = new Customer();
            CustomerLogin _objCustomerLogin = new CustomerLogin();
            using (Customer_BAL _objBAL = new Customer_BAL())
            {
                _objCustomerLogin.Email = Username;
                _objCustomerLogin.Password = Password;
                _objCustomer = _objBAL.ValidateUser(_objCustomerLogin);
            }
            return _objCustomer;
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
