using System;
using System.Collections.Generic;
using SI.Meditourism.Master.Model;
namespace SI.Meditourism.Master.Interface
{
    public interface IContactUsRepository : IDisposable
    {
        List<ContactUs> GetAllRecorod();
        ContactUsPage GetRecordsPage(int iPageNo, int iPageSize);
        ContactUsDetails GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(ContactUs objContactUs);
        bool DeleteRecord(int iId);
    }
}
