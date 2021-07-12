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
    public class TreatmentPaymentDetails_BAL : ITreatmentPaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(TreatmentPaymentDetails_BAL));

        public TreatmentPaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            TreatmentPaymentDetailsPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
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

        public TreatmentPagelst GetRecorodById(Guid iId)
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
      
        public List<TreatmentPagelst> GetTreatmentPaymentDetaillist(Guid iId)
        {
            List<TreatmentPagelst> objReturn = null;
            try
            {

                using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                {
                    objReturn = objDAL.GetTreatmentPaymentDetaillist(iId);
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }
        public bool IsPaymentRequestExist(Guid? iId)
        {
            bool objReturn = false;
            try
            {
                    using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                    {
                        objReturn = objDAL.IsPaymentRequestExist(iId);
                    }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }
        public TreatmentPagelst GetTreatmentDetailsById(Guid? iId)
        {
            TreatmentPagelst objReturn = null;
            try
            {
                using (TreatmentPaymentDetails_DAL objDAL = new TreatmentPaymentDetails_DAL())
                {
                    objReturn = objDAL.GetTreatmentDetailsById(iId);
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public int InsertUpdateRecord(TreatmentPaymentDetails objTreatmentPaymentDetails, string TotalAmount, string currency, string tax, string description)
        {
            int objReturn = 0;
            try
            {
                objTreatmentPaymentDetails.Amount = TotalAmount;
                objTreatmentPaymentDetails.Currency = currency;
                objTreatmentPaymentDetails.Tax = tax;
                objTreatmentPaymentDetails.Description = description;
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
