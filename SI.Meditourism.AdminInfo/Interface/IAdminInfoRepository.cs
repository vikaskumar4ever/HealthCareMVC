using System;
using System.Collections.Generic;
using SI.Meditourism.AdminInfo.Model;

namespace SI.Meditourism.AdminInfo.Interface
{
    public interface IAdminInfoRepository: IDisposable
    {
        List<Admin> GetAllRecorod();
        AdminInfoPage GetRecordsPage(int iPageNo, int iPageSize);
        Admin GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(Admin objAdminInfo);
        bool DeleteRecord(int iId);
    }
}
