using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.Reports.DAL;
using SI.Meditourism.Reports.Model;
using SI.Meditourism.Reports.Interface;

namespace SI.Meditourism.Reports.BAL
{
    public class Report_BAL : IReportRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Report_BAL));

        public ReportPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            ReportPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (Report_DAL objDAL = new Report_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

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
            { log.Error("GetAllRecorod Error: ", ex); }
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
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(Report objReport)
        {
            Guid? objReturn = null;
            try
            {
                using (Report_DAL objDAL = new Report_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objReport);
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
                    using (Report_DAL objDAL = new Report_DAL())
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
