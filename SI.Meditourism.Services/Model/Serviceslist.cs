using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.Services.Model
{
    public class Serviceslist
    {
        public int Id { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? ParentId { get; set; }
        public String ServiceName { get; set; }
        public String Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
