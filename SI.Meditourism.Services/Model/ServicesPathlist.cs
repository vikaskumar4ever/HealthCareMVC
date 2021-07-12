using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.Services.Model
{
    public class ServicesPathlist
    {
        public int Id { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? ParentId { get; set; }
        public String SFullPath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
