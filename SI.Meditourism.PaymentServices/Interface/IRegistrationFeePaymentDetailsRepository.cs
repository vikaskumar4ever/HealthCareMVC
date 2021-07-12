using SI.Meditourism.PaymentServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.PaymentServices.Interface
{
    public interface IRegistrationFeePaymentDetailsRepository : IDisposable
    {
        List<RegistrationFeePaymentDetails> GetAllRecorod();
        RegistrationFeePaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize);
        RegistrationFeePaymentDetails GetRecorodById(int iId);
        //Guid? InsertUpdateRecord(RegistrationFeePaymentDetails objRegistrationFeePaymentDetails);
        bool DeleteRecord(int iId);
    }
}
