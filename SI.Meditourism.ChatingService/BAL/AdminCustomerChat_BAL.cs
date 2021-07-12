using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.ChatingService.Interface;
using SI.Meditourism.ChatingService.Model;
using SI.Meditourism.ChatingService.DAL;

namespace SI.Meditourism.ChatingService.BAL
{
    public class AdminCustomerChat_BAL : IAdminCustomerChatRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AdminCustomerChat_BAL));

        public AdminCustomerChatPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            AdminCustomerChatPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (AdminCustomerChat_DAL objDAL = new AdminCustomerChat_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<GetChatMessagelist> GetAllRecorod(Guid? CustomerId)
        {
            List<GetChatMessagelist> objReturn = null;
            try
            {
                using (AdminCustomerChat_DAL objDAL = new AdminCustomerChat_DAL())
                {
                    objReturn = objDAL.GetAllRecorod(CustomerId);
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public AdminCustomerChat GetRecorodById(Guid iId)
        {
            AdminCustomerChat objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (AdminCustomerChat_DAL objDAL = new AdminCustomerChat_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(AdminCustomerChat objAdminCustomerChat)
        {
            Guid? objReturn = null;
            try
            {
                using (AdminCustomerChat_DAL objDAL = new AdminCustomerChat_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objAdminCustomerChat);
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
                    using (AdminCustomerChat_DAL objDAL = new AdminCustomerChat_DAL())
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
