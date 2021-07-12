using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.PaymentServices.Model
{
    public class TreatmentPagelst
    {
        public int Id { get; set; }


        public Guid? PaymentId { get; set; }


        public string PAYId { get; set; }
        public string CustomerName { get; set; }

        public Guid? CustomerId { get; set; }

        public string ServiceName { get; set; }
        public Guid? ServiceId { get; set; }


        public string State { get; set; }


        public string Intent { get; set; }


        public string Paymentmethod { get; set; }


        public string Payer_email { get; set; }


        public string Payer_firstname { get; set; }


        public string Payer_payerId { get; set; }


        public string Description { get; set; }


        public string Currency { get; set; }


        public string Price { get; set; }


        public string TreatmentCharge { get; set; }


        public string VisaCharge { get; set; }


        public string Accommodation { get; set; }


        public string Tax { get; set; }


        public string Amount { get; set; }


        public string failedErrorName { get; set; }


        public string failedMessage { get; set; }


        public string failedIssue { get; set; }


        public string CreationDate { get; set; }


        public Guid? CreatedBy { get; set; }


        public string UpdatedDate { get; set; }


        public Guid? UpdatedBy { get; set; }


        public bool? IsActive { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
