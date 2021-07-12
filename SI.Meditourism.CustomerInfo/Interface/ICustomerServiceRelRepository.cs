using System;
using System.Collections.Generic;
using SI.Meditourism.CustomerInfo.Model;

namespace SI.Meditourism.CustomerInfo.Interface
{
    public interface ICustomerServiceRelRepository : IDisposable
    {
        List<CustomerServiceRel> GetAllRecorod();
        CustomerServiceRelPage GetRecordsPage(int iPageNo, int iPageSize);
        CustomerServiceRel GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(CustomerServiceRel objCustomerServiceRel);
        bool DeleteRecord(int iId);
    }
}
