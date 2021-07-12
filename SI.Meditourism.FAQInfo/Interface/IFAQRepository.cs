using System;
using System.Collections.Generic;
using SI.Meditourism.FAQInfo.Model;

namespace SI.Meditourism.FAQInfo.Interface
{
    public interface IFAQRepository : IDisposable
    {
        List<FAQ> GetAllRecorod();
        FAQPage GetRecordsPage(int iPageNo, int iPageSize);
        FAQ GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(FAQ objFAQ);
        bool DeleteRecord(int iId);
    }
}
