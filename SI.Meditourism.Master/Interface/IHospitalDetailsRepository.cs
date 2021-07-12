using System;
using System.Collections.Generic;
using SI.Meditourism.Master.Model;

namespace SI.Meditourism.Master.Interface
{
    public interface IHospitalDetailsRepository : IDisposable
    {
        List<HospitalDetails> GetAllRecorod();
        HospitalDetailsPage GetRecordsPage(int iPageNo, int iPageSize);
        HospitalDetails GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(HospitalDetails objHospitalDetails);
        bool DeleteRecord(int iId);
    }
}
