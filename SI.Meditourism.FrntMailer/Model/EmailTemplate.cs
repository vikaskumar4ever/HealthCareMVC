using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.FrntMailer.Model
{
    public class EmailTemplate
    {
        public int Id { get; set; }


        public Guid? TemplateId { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string TemplateContent { get; set; }


        public string HostIp { get; set; }


        public Guid? CreatedBy { get; set; }


        public DateTime? CreationDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
