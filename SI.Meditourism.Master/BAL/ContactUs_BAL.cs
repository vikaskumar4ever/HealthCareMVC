using System;
using log4net;
using SI.Meditourism.Master.DAL;
using System.Collections.Generic;
using SI.Meditourism.Master.Model;
using SI.Meditourism.Master.Interface;
using SI.Meditourism.Services.Model;

namespace SI.Meditourism.Master.BAL
{
    public class ContactUs_BAL : IContactUsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(ContactUs_BAL));

        public ContactUsPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            ContactUsPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (ContactUs_DAL objDAL = new ContactUs_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<ContactUs> GetAllRecorod()
        {
            List<ContactUs> objReturn = null;
            try
            {
                using (ContactUs_DAL objDAL = new ContactUs_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public ContactUsDetails GetRecorodById(Guid iId)
        {
            ContactUsDetails objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (ContactUs_DAL objDAL = new ContactUs_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }
        public DashboardCount GetDashboardCount()
        {
            DashboardCount objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (ContactUs_DAL objDAL = new ContactUs_DAL())
                    {
                        objReturn = objDAL.GetDashboardCount();
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(ContactUs objContactUs)
        {
            Guid? objReturn = null;
            try
            {
                using (ContactUs_DAL objDAL = new ContactUs_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objContactUs);
                }
            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
            return objReturn;
        }
        public Service GetQuotation(ContactUs objContactUs)
        {
            Service objReturn = null;
            try
            {
                using (ContactUs_DAL objDAL = new ContactUs_DAL())
                {
                    objReturn = objDAL.GetQuotation(objContactUs);
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
                    using (ContactUs_DAL objDAL = new ContactUs_DAL())
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
