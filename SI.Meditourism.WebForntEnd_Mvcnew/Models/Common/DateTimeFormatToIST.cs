using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Models.Common
{
    public class DateTimeFormatToIST
    {
        public DateTime ConvertDatetoIST(DateTime dateTime)
        {
            DateTime objdateTime;
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            objdateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, tz);
            return objdateTime;
        }
    }
}