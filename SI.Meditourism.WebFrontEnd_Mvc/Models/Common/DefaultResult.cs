using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI.Meditourism.WebFrontEnd_Mvc.Models.Common
{
    public class DefaultResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Reason { get; set; }
        public string Data { get; set; }
        public int UserId { get; set; }
    }
}