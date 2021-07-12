using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.Reports.Model
{
    public class Report
    {
        public int Id { get; set; }


        public Guid ReportId { get; set; }


        public Guid? CustomerId { get; set; }


        public string Name { get; set; }


        public string FileNameByCode { get; set; }


        public string FileType { get; set; }


        public string FileName { get; set; }


        public string FileSize { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }


    }
}
