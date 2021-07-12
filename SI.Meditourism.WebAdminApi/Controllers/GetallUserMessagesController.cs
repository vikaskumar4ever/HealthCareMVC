using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.ChatingService.Model;
using SI.Meditourism.ChatingService.BAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class GetallUserMessagesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{CustomerId}")]
        public JsonResult Get(Guid CustomerId)
        {
            if (CustomerId != null)
            {

                using (AdminCustomerChat_BAL _objbal = new AdminCustomerChat_BAL())
                {
                    List<GetChatMessagelist> _objadmincustomerchat = new List<GetChatMessagelist>();
                    _objadmincustomerchat = _objbal.GetAllRecorod(CustomerId);
                    Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    var result = Newtonsoft.Json.JsonConvert.SerializeObject(_objadmincustomerchat, jsonSerializerSettings);
                    return Json(result);
                }
            }
            else
            {
                Response.Redirect("http://meditourism.morepower.com");
                return Json("");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
