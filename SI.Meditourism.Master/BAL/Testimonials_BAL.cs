using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.Master.DAL;
using SI.Meditourism.Master.Model;
using SI.Meditourism.Master.Interface;

namespace SI.Meditourism.Master.BAL
{
    public class Testimonials_BAL : ITestimonialsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Testimonials_BAL));

        public TestimonialsPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            TestimonialsPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (Testimonials_DAL objDAL = new Testimonials_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<Testimonials> GetAllRecorod()
        {
            List<Testimonials> objReturn = null;
            try
            {
                using (Testimonials_DAL objDAL = new Testimonials_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public Testimonials GetRecorodById(Guid iId)
        {
            Testimonials objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (Testimonials_DAL objDAL = new Testimonials_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(Testimonials objTestimonials)
        {
            Guid? objReturn = null;
            try
            {
                using (Testimonials_DAL objDAL = new Testimonials_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objTestimonials);
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
                    using (Testimonials_DAL objDAL = new Testimonials_DAL())
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
