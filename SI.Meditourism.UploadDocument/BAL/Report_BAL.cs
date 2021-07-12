using System;
using System.Collections.Generic;
using SI.Meditourism.UploadDocument.DAL;
using SI.Meditourism.UploadDocument.Model;
using SI.Meditourism.UploadDocument.Interface;

namespace SI.Meditourism.UploadDocument.BAL
{
    public class Report_BAL : IReportRepository
    {
        
        public List<Report> GetAllRecorod()
        {
            List<Report> objReturn = null;
            try
            {
                using (Report_DAL objDAL = new Report_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            {  }
            return objReturn;
        }

        public List<Reportlist> GetRecorodById(Guid iId)
        {
            List<Reportlist> objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (Report_DAL objDAL = new Report_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            {  }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Report objReport)
        {
            Guid objReturn = Guid.Empty;
            try
            {
                using (Report_DAL objDAL = new Report_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objReport);
                }
            }
            catch (Exception ex)
            {  }
            return objReturn;
        }

        public bool DeleteRecord(int iId)
        {
            bool objReturn = false;
            try
            {
                if (iId > 0)
                {
                    using (Report_DAL objDAL = new Report_DAL())
                    {
                        objReturn = objDAL.DeleteRecord(iId);
                    }
                }
            }
            catch (Exception ex)
            {  }
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
