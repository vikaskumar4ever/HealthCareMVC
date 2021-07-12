using SI.Meditourism.PaymentServicesAdmin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.PaymentServicesAdmin.Interface
{
    public interface IRegistrationFeePaymentDetailsRepository : IDisposable
    {
        List<RegistrationFeePaymentDetails> GetAllRecorod();
        RegistrationFeePaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize, Guid? CustomerId);
        RegistrationFeePaymentdetailslst GetRecorodById(Guid? iId);
        Guid? InsertUpdateRecord(RegistrationFeePaymentDetails objRegistrationFeePaymentDetails);
        bool DeleteRecord(int iId);
    }
}
