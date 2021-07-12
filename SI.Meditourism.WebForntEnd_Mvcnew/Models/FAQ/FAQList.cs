using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.WebForntEnd_Mvcnew.Models.FAQ
{
    public class FAQList
    {
        public int Id { get; set; }


        public Guid? FaqId { get; set; }


        public string FaqCategoryId { get; set; }

        public string FaqCategoryName { get; set; }

        public string Question { get; set; }


        public string Answer { get; set; }


        public DateTime? CreatedDate { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public bool? IsDeleted { get; set; }


        public bool? IsActive { get; set; }
    }
}
