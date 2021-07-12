using System;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.FAQInfo.BAL;
using System.Collections.Generic;
using SI.Meditourism.FAQInfo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<FAQ> Get()
        {
            List<FAQ> objReturn = new List<FAQ>();
            using (FAQ_BAL objBAL = new FAQ_BAL())
            {
                objReturn = objBAL.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public FAQ Get(Guid id)
        {
            FAQ objReturn = new FAQ();
            using (FAQ_BAL objBAL = new FAQ_BAL())
            {
                objReturn = objBAL.GetRecorodById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]FAQ value)
        {
            DateTimeFormatToIST _ObjDateTimeFormatToIST = new DateTimeFormatToIST();
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.IsDeleted = false;
                value.CreatedDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                value.FaqId = Guid.NewGuid();
            }
            value.UpdatedDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
            using (FAQ_BAL objBAL = new FAQ_BAL())
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
            using (FAQ_BAL objBAL = new FAQ_BAL())
            {
                objReturn.Data = objBAL.DeleteRecord(id).ToString();
            }
            return objReturn;
        }
    }
}
