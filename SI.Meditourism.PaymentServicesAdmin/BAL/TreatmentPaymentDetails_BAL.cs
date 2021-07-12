using log4net;
using SI.Meditourism.PaymentServicesAdmin.DAL;
using SI.Meditourism.PaymentServicesAdmin.Interface;
using SI.Meditourism.PaymentServicesAdmin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SI.Meditourism.PaymentServicesAdmin.BAL
{
    public class TreatmentPaymentDetails_BAL : ITreatmentPaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(TreatmentPaymentDetails_BAL));

        public TreatmentPaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize, Guid? ServiceId, Guid? CustomerId)
        {
            TreatmentPaymentDetailsPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize, ServiceId, CustomerId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<TreatmentPaymentDetails> GetAllRecorod()
        {
            List<TreatmentPaymentDetails> objReturn = null;
            try
            {
                using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public TreatmentPagelst GetRecorodById(Guid? iId)
        {
            TreatmentPagelst objReturn = null;
            try
            {
                    using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }
        public TreatmentpaymentdetailsbCustId GetTreatmentpaymentdetailsb(Guid? iId)
        {
            TreatmentpaymentdetailsbCustId objReturn = new TreatmentpaymentdetailsbCustId();
            try
            {
                using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                {
                    objReturn = objDAL.GetTreatmentpaymentdetailsb(iId);
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(TreatmentPaymentDetails objTreatmentPaymentDetails)
        {
            Guid? objReturn = null;
            try
            {
                using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objTreatmentPaymentDetails);
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
                    using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
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
