using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.CustomerInfo.DAL;
using SI.Meditourism.CustomerInfo.Model;
using SI.Meditourism.CustomerInfo.Interface;

namespace SI.Meditourism.CustomerInfo.BAL
{
    public class CustomerServiceRel_BAL : ICustomerServiceRelRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(CustomerServiceRel_BAL));

        public CustomerServiceRelPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            CustomerServiceRelPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (CustomerServiceRel_DAL objDAL = new CustomerServiceRel_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<CustomerServiceRel> GetAllRecorod()
        {
            List<CustomerServiceRel> objReturn = null;
            try
            {
                using (CustomerServiceRel_DAL objDAL = new CustomerServiceRel_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public CustomerServiceRel GetRecorodById(Guid iId)
        {
            CustomerServiceRel objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (CustomerServiceRel_DAL objDAL = new CustomerServiceRel_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(CustomerServiceRel objCustomerServiceRel)
        {
            Guid? objReturn = null;
            try
            {
                using (CustomerServiceRel_DAL objDAL = new CustomerServiceRel_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objCustomerServiceRel);
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
                    using (CustomerServiceRel_DAL objDAL = new CustomerServiceRel_DAL())
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
