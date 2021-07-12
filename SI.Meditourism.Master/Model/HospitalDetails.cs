using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.Master.Model
{
    public class HospitalDetails
    {
        public int Id { get; set; }


        public Guid HospitalDetailsId { get; set; }


        public string Content { get; set; }


        public string Image { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }


    }
}
