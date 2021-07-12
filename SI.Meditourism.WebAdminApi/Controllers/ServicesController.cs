using System;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SI.Meditourism.Services.BAL;
using SI.Meditourism.Services.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Service> Get()
        {
            List<Service> objReturn = new List<Service>();
            using (Service_BAL objBal = new Service_BAL())
            {
                objReturn = objBal.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Service Get(Guid id)
        {
            Service objReturn = new Service();
            using (Service_BAL objBal = new Service_BAL())
            {
                objReturn = objBal.GetRecorodById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]Service value)
        {
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.ServiceId = Guid.NewGuid();
                value.CreationDate = DateTime.Now;
            }
            value.UpdatedDate = DateTime.Now;
            value.IsDeleted = false;
            using (Service_BAL objBAL = new Service_BAL())
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
            using (Service_BAL objBAL = new Service_BAL())
            {
                objReturn.Status = objBAL.DeleteRecord(id);
            }
            return objReturn;
        }
    }
}
