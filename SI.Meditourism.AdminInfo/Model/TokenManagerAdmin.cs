using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.AdminInfo.Model
{
    public class TokenManagerAdmin
    {
        public int TokenID { get; set; }


        public string TokenKey { get; set; }


        public DateTime? IssuedOn { get; set; }


        public DateTime? ExpiresOn { get; set; }


        public DateTime? CreatedOn { get; set; }


        public Guid? AdminId { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
