using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.ChatingService.Model
{
    public class AdminCustomerChat
    {
        public int Id { get; set; }


        public Guid? AdminCustomerChatId { get; set; }


        public Guid? AdminId { get; set; }


        public Guid? CustomerId { get; set; }


        public string Message { get; set; }


        public bool? IsAdmin { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
