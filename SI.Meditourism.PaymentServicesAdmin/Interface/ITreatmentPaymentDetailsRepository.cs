using SI.Meditourism.PaymentServicesAdmin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.PaymentServicesAdmin.Interface
{
    public interface ITreatmentPaymentDetailsRepository : IDisposable
    {
        List<TreatmentPaymentDetails> GetAllRecorod();
        TreatmentPaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize, Guid? ServiceId, Guid? CustomerId);
        TreatmentPagelst GetRecorodById(Guid? iId);
        Guid? InsertUpdateRecord(TreatmentPaymentDetails objTreatmentPaymentDetails);
        bool DeleteRecord(int iId);
    }
}
