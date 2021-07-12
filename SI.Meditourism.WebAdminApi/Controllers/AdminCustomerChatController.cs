using System;
using System.Linq;
using SI.Meditourism.Common;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.ChatingService.BAL;
using System.Collections.Generic;
using SI.Meditourism.ChatingService.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class AdminCustomerChatController : Controller
    {
        // GET: api/<controller>
        [HttpGet("{CustomerId}")]
        public List<GetChatMessagelist> Get(Guid? CustomerId)
        {
            List<GetChatMessagelist> objReturn = new List<GetChatMessagelist>();
            using (AdminCustomerChat_BAL objBal = new AdminCustomerChat_BAL())
            {
                objReturn = objBal.GetAllRecorod(CustomerId);
            }
            return objReturn;
        }

        // GET api/<controller>/5
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public DefaultResult Post([FromBody]AdminCustomerChat value)
        {
            DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
            DefaultResult objRetrun = new DefaultResult();
            try
            {
                if (value.Id == 0)
                {
                    value.AdminCustomerChatId = Guid.NewGuid();
                    value.IsActive = true;
                    value.IsDeleted = false;
                    value.IsAdmin = true;
                    value.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                    value.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                    value.UpdatedBy = value.AdminId;
                    value.CreatedBy = value.AdminId;
                    using (AdminCustomerChat_BAL _objBAL = new AdminCustomerChat_BAL())
                    {
                        _objBAL.InsertUpdateRecord(value);
                    }
                }
            }
            catch (Exception ex)
            {

                objRetrun.Message = ex.Message;
            }
            return objRetrun;
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
