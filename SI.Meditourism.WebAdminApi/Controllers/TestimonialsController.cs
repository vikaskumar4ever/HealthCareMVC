using System;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Master.BAL;
using System.Collections.Generic;
using SI.Meditourism.Master.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class TestimonialsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Testimonials> Get()
        {
            List<Testimonials> objReturn = new List<Testimonials>();
            using (Testimonials_BAL objBAL = new Testimonials_BAL())
            {
                objReturn = objBAL.GetAllRecorod();
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Testimonials Get(Guid id)
        {
            Testimonials objReturn = new Testimonials();
            using (Testimonials_BAL objBAL = new Testimonials_BAL())
            {
                objReturn = objBAL.GetRecorodById(id);
            }
            return objReturn;
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]Testimonials value)
        {
            DateTimeFormatToIST _ObjDateTimeFormatToIST = new DateTimeFormatToIST();
            DefaultResult objReturn = new DefaultResult();
            if (value.Id == 0)
            {
                value.IsDeleted = false;
                value.CreationDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                value.TestimonialsId = Guid.NewGuid();
            }
            value.UpdatedDate = _ObjDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
            using (Testimonials_BAL objBAL = new Testimonials_BAL())
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
            using (Testimonials_BAL objBAL = new Testimonials_BAL())
            {
                objReturn.Data = objBAL.DeleteRecord(id).ToString();
            }
            return objReturn;
        }
    }
}
