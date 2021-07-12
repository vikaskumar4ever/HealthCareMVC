using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.AdminInfo.Model
{
    public class Admin
    {
        public int Id { get; set; }


        public Guid AdminId { get; set; }


        public string EmailId { get; set; }


        public string Username { get; set; }


        public string PasswordHash { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }


    }
}
