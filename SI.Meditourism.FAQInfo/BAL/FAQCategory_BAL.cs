using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.FAQInfo.DAL;
using SI.Meditourism.FAQInfo.Model;
using SI.Meditourism.FAQInfo.Interface;

namespace SI.Meditourism.FAQInfo.BAL
{
    public class FAQCategory_BAL : IFAQCategoryRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(FAQCategory_BAL));

        public FAQCategoryPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            FAQCategoryPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (FAQCategory_DAL objDAL = new FAQCategory_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<FAQCategory> GetAllRecorod()
        {
            List<FAQCategory> objReturn = null;
            try
            {
                using (FAQCategory_DAL objDAL = new FAQCategory_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public FAQCategory GetRecorodById(Guid iId)
        {
            FAQCategory objReturn = null;
            try
            {
               // if (iId > 0)
                {
                    using (FAQCategory_DAL objDAL = new FAQCategory_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(FAQCategory objFAQCategory)
        {
            Guid? objReturn = null;
            try
            {
                using (FAQCategory_DAL objDAL = new FAQCategory_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objFAQCategory);
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
                    using (FAQCategory_DAL objDAL = new FAQCategory_DAL())
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
