using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.CustomerInfo.Model
{
    public class CustomerPage
    {
        public List<Customer> Customers { get; set; }
        public int TotalRecords { get; set; }
    }
}
