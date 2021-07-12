using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.Services.Model
{
    public class GetServicedetail
    {
        public Service GetService { get; set; }
        public List<Serviceslist> GetServiceslists { get; set; }
    }
}
