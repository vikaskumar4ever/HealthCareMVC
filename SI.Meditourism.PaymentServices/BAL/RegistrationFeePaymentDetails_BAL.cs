using log4net;
using SI.Meditourism.PaymentServices.DAL;
using SI.Meditourism.PaymentServices.Interface;
using SI.Meditourism.PaymentServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.PaymentServices.BAL
{
    public class RegistrationFeePaymentDetails_BAL : IRegistrationFeePaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RegistrationFeePaymentDetails_BAL));

        public RegistrationFeePaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            RegistrationFeePaymentDetailsPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public RegistrationFee RegistrationFeeDetails()
        {
            RegistrationFee objReturn = new RegistrationFee();
            try
            {
                using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                {
                    objReturn = objDAL.RegistrationFeeDetails();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public bool ChkCustomerIdExistInRegistationPayment(Guid? CustomerId)
        {
            bool objReturn = false;
            try
            {
                using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                {
                    objReturn = objDAL.ChkCustomerIdExistInRegistationPyament(CustomerId);
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public bool ChkCustomerIdExistOrNot(Guid? CustomerId)
        {
            bool objReturn = false;
            try
            {
                using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                {
                    objReturn = objDAL.ChkCustomerIdExistOrNot(CustomerId);
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public Customer GetCustomerDetails(Guid? CustomerId)
        {
            Customer objReturn = null;
            try
            {
                using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                {
                    objReturn = objDAL.GetCustomerDetails(CustomerId);
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public List<RegistrationFeePaymentDetails> GetAllRecorod()
        {
            List<RegistrationFeePaymentDetails> objReturn = null;
            try
            {
                using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public RegistrationFeePaymentDetails GetRecorodById(int iId)
        {
            RegistrationFeePaymentDetails objReturn = null;
            try
            {
                if (iId > 0)
                {
                    using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(RegistrationFeePaymentDetails objRegistrationFeePaymentDetails, string Amount, string Currency, string Tax, string Description)
        {
            Guid? objReturn = null;
            try
            {
                objRegistrationFeePaymentDetails.Amount = Amount;
                objRegistrationFeePaymentDetails.Currency = Currency;
                objRegistrationFeePaymentDetails.Tax = Tax;
                objRegistrationFeePaymentDetails.Description = Description;
                using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objRegistrationFeePaymentDetails);
                }
            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
            return objReturn;
        }

        public bool DeleteRecord(int iId)
        {
            bool objReturn = false;
            try
            {
                if (iId > 0)
                {
                    using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                    {
                        objReturn = objDAL.DeleteRecord(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("DeleteRecord Error: ", ex); }
            return objReturn;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
