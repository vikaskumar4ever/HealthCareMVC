using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.PaymentServicesAdmin.Model
{
    public class RegistrationFeePaymentDetails
    {
        public int Id { get; set; }
        
        public Guid? PaymentId { get; set; }
        
        public string PAYId { get; set; }
        
        public Guid? CustomerId { get; set; }
        
        public string State { get; set; }
        
        public string Intent { get; set; }
        
        public string Paymentmethod { get; set; }
        
        public string Payer_email { get; set; }
        
        public string Payer_firstname { get; set; }
        
        public string Payer_payerId { get; set; }
        
        public string Description { get; set; }
        
        public string Currency { get; set; }
        
        public string Amount { get; set; }
        
        public string Tax { get; set; }

        public string failedName { get; set; }
        public string failedMessage { get; set; }
        public string failedIssue { get; set; }
        public string CreationDate { get; set; }
        
        public Guid? CreatedBy { get; set; }
        
        public string UpdatedDate { get; set; }
        
        public Guid? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
