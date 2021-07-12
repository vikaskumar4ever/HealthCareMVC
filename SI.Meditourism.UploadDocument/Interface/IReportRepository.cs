using System;
using System.Collections.Generic;
using SI.Meditourism.UploadDocument.Model;

namespace SI.Meditourism.UploadDocument.Interface
{
    public interface IReportRepository : IDisposable
    {
        List<Report> GetAllRecorod();
        List<Reportlist> GetRecorodById(Guid iId);
        Guid InsertUpdateRecord(Report objReport);
        bool DeleteRecord(int iId);
    }
}
