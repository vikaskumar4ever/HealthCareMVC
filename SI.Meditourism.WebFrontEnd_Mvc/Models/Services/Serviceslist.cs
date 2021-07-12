using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI.Meditourism.WebFrontEnd_Mvc.Models.Services
{
    public class Serviceslist
    {
        public int Id { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? ParentId { get; set; }
        public String ServiceName { get; set; }
        public String Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}