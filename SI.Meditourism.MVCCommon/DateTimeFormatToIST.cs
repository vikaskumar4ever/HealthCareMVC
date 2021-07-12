using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.MVCCommon
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
