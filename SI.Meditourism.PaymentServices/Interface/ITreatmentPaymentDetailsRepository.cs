using SI.Meditourism.PaymentServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.PaymentServices.Interface
{
    public interface ITreatmentPaymentDetailsRepository : IDisposable
    {
        List<TreatmentPaymentDetails> GetAllRecorod();
        TreatmentPaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize);
        TreatmentPagelst GetRecorodById(Guid iId);
        //int InsertUpdateRecord(TreatmentPaymentDetails objTreatmentPaymentDetails);
        bool DeleteRecord(int iId);
    }
}
