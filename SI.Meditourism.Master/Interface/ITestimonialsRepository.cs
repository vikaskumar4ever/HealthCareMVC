using System;
using System.Collections.Generic;
using SI.Meditourism.Master.Model;

namespace SI.Meditourism.Master.Interface
{
    public interface ITestimonialsRepository : IDisposable
    {
        List<Testimonials> GetAllRecorod();
        TestimonialsPage GetRecordsPage(int iPageNo, int iPageSize);
        Testimonials GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(Testimonials objTestimonials);
        bool DeleteRecord(int iId);
    }
}
