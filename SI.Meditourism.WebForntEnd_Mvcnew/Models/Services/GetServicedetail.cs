using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Models.Services
{
    public class GetServicedetail
    {
        public Service GetService { get; set; }
        public List<Serviceslist> GetServiceslists { get; set; }
    }
}