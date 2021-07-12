using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Models.Customer
{
    public class Customer
    {
        public int Id { get; set; }


        public Guid? CustomerId { get; set; }


        public string Name { get; set; }


        public string Email { get; set; }


        public string PhoneNo { get; set; }


        public string AlternateNo { get; set; }


        public string Address { get; set; }

        public string Country { get; set; }

        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool? IsPaymentCompleted { get; set; }

        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}