using System;
using System.Collections.Generic;
using SI.Meditourism.Reports.Model;

namespace SI.Meditourism.Reports.Interface
{
    public interface IReportRepository : IDisposable
    {
        List<Report> GetAllRecorod();
        ReportPage GetRecordsPage(int iPageNo, int iPageSize);
        List<Reportlist> GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(Report objReport);
        bool DeleteRecord(int iId);
    }
}
