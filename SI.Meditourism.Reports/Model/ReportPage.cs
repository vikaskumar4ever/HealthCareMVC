using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.Reports.Model
{
    public class ReportPage
    {
        public List<Report> Reports { get; set; }
        public int TotalRecords { get; set; }
    }
}
