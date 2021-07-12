using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.FAQInfo.Model
{
    public class FAQPage
    {
        public List<FAQList> FAQs { get; set; }
        public int TotalRecords { get; set; }
    }
}
