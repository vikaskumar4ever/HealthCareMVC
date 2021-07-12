using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SI.Meditourism.Reports.Model;
using SI.Meditourism.Reports.DAL;
using SI.Meditourism.Common;
using SI.Meditourism.Reports.BAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SI.Meditourism.WebAdminApi.Controllers
{
    [Route("api/[controller]")]
    public class UploadReportDocumentController : Controller
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
        public void Post(Guid? CustomerId, string ContentType,string FullFileName,string FileSize, string FileName)
        {
            DateTimeFormatToIST _objDateTimeFormatToIST = new DateTimeFormatToIST();
            using (Report_BAL _objBAL = new Report_BAL())
            {
                Report _objReport = new Report();
                _objReport.ReportId = Guid.NewGuid();
                _objReport.CustomerId = CustomerId;
                _objReport.FileType = ContentType;
                _objReport.FileName = FullFileName;
                _objReport.FileSize = FileSize;
                _objReport.CreationDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                _objReport.UpdatedDate = _objDateTimeFormatToIST.ConvertDatetoIST(DateTime.UtcNow);
                _objReport.UpdatedBy = CustomerId;
                _objReport.CreatedBy = CustomerId;
                _objReport.IsActive = true;
                _objReport.IsDeleted = false;
                _objReport.Name = FileName;
                _objBAL.InsertUpdateRecord(_objReport);
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
