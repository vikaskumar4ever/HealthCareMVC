using System;
using System.Collections.Generic;
using SI.Meditourism.Services.Model;

namespace SI.Meditourism.Services.Interface
{
    public interface IServiceRepository : IDisposable
    {
        List<Service> GetAllRecorod();
        ServicePage GetRecordsPage(int iPageNo, int iPageSize, Guid? ServiceId);
        Service GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(Service objService);
        bool DeleteRecord(int iId);
    }
}
