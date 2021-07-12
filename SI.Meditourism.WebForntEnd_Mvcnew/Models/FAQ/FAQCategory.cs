using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Models.FAQ
{
    public class FAQCategory
    {
        public int Id { get; set; }


        public Guid FaqCategoryId { get; set; }


        public string FaqCategoryName { get; set; }


        public int? DisplayOrder { get; set; }


        public DateTime? CreatedDate { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsDeleted { get; set; }


        public bool? IsActive { get; set; }

    }
}
