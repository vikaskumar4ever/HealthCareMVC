using System;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SI.Meditourism.CustomerInfo.BAL;
using SI.Meditourism.CustomerInfo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerServiceRelController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CustomerServiceRel> Get()
        {
            List<CustomerServiceRel> objReturn = new List<CustomerServiceRel>();
            using (CustomerServiceRel_BAL objBal = new CustomerServiceRel_BAL())
            {
                objReturn = objBal.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public CustomerServiceRel Get(Guid id)
        {
            CustomerServiceRel objReturn = new CustomerServiceRel();
            using (CustomerServiceRel_BAL objBal = new CustomerServiceRel_BAL())
            {
                objReturn = objBal.GetRecorodById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]CustomerServiceRel value)
        {

            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.CustomerId = Guid.NewGuid();
                value.CreationDate = DateTime.Now;
            }
            value.UpdatedDate = DateTime.Now;
            value.IsDeleted = false;
            using (CustomerServiceRel_BAL objBAL = new CustomerServiceRel_BAL())
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
            using (CustomerServiceRel_BAL objBAL = new CustomerServiceRel_BAL())
            {
                objReturn.Status = objBAL.DeleteRecord(id);
            }
            return objReturn;
        }
    }
}
