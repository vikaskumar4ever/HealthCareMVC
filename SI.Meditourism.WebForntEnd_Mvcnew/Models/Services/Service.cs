using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Models.Services
{
    public class Service
    {
        public int Id { get; set; }


        public Guid ServiceId { get; set; }


        public string Name { get; set; }


        public Guid? ParentId { get; set; }


        public string Description { get; set; }


        public string Price { get; set; }


        public string TreatmentCharge { get; set; }


        public string Accommodation { get; set; }


        public string VisaCharge { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}