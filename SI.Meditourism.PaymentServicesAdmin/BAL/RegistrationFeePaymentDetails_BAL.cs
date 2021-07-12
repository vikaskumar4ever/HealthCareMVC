using log4net;
using SI.Meditourism.PaymentServicesAdmin.DAL;
using SI.Meditourism.PaymentServicesAdmin.Interface;
using SI.Meditourism.PaymentServicesAdmin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.PaymentServicesAdmin.BAL 
{
    public class RegistrationFeePaymentDetails_BAL : IRegistrationFeePaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RegistrationFeePaymentDetails_BAL));

        public RegistrationFeePaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize, Guid? CustomerId)
        {
            RegistrationFeePaymentDetailsPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize, CustomerId);
                    }
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

        public RegistrationFeePaymentdetailslst GetRecorodById(Guid? iId)
        {
            RegistrationFeePaymentdetailslst objReturn = null;
            try
            {
               
                    using (RegistrationFeePaymentDetails_DAL objDAL = new RegistrationFeePaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(RegistrationFeePaymentDetails objRegistrationFeePaymentDetails)
        {
            Guid? objReturn = null;
            try
            {
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

