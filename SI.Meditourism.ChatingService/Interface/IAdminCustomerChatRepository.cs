using SI.Meditourism.ChatingService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.ChatingService.Interface
{
    public interface IAdminCustomerChatRepository : IDisposable
    {
        List<GetChatMessagelist> GetAllRecorod(Guid? CustomerId);
        AdminCustomerChatPage GetRecordsPage(int iPageNo, int iPageSize);
        AdminCustomerChat GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(AdminCustomerChat objAdminCustomerChat);
        bool DeleteRecord(int iId);
    }
}
