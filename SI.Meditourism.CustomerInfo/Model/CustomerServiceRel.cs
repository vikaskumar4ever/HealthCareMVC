using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.CustomerInfo.Model
{
    public class CustomerServiceRel
    {
        public int Id { get; set; }


        public Guid? ServiceId { get; set; }


        public Guid? CustomerId { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
