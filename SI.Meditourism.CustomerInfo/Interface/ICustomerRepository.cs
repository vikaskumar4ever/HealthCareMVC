using System;
using System.Collections.Generic;
using SI.Meditourism.CustomerInfo.Model;

namespace SI.Meditourism.CustomerInfo.Interface
{
    public interface ICustomerRepository : IDisposable
    {
        List<Customer> GetAllRecorod();
        CustomerPage GetRecordsPage(int iPageNo, int iPageSize);
        Customer GetRecorodById(Guid iId);
        Guid? InsertUpdateRecord(Customer objCustomer);
        bool DeleteRecord(int iId);
    }
}
