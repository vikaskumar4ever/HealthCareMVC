using System;
using System.Collections.Generic;
using SI.Meditourism.FAQInfo.Model;

namespace SI.Meditourism.FAQInfo.Interface
{
    public interface IFAQCategoryRepository : IDisposable
    {
        List<FAQCategory> GetAllRecorod();
        FAQCategoryPage GetRecordsPage(int iPageNo, int iPageSize);
        FAQCategory GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(FAQCategory objFAQCategory);
        bool DeleteRecord(int iId);
    }
}
