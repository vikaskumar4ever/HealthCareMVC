using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SI.Meditourism.Master.Model
{
    public class ContactUs
    {
        public int Id { get; set; }
        public Guid? ContactUsId { get; set; }
        [Required (ErrorMessage = "FullName is Required")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string AltMobile { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Message { get; set; }
        public string HostIp { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Country { get; set; }
        public Guid? ServiceId { get; set; }

    }
}
