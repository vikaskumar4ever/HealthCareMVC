using System;
using Dapper;
using log4net;
using System.Linq;
using System.Data.SqlClient;
using SI.Meditourism.Connection;
using System.Collections.Generic;
using SI.Meditourism.Reports.Model;
using SI.Meditourism.Reports.Interface;

namespace SI.Meditourism.Reports.DAL
{
    public class Report_DAL : IReportRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Report_DAL));

        public List<Report> GetAllRecorod()
        {
            List<Report> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Report>("udp_Report_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public ReportPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            ReportPage objReturn = new ReportPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.Reports = db.Query<Report>("udp_Report_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public List<Reportlist> GetRecorodById(Guid CustomerId)
        {
            List<Reportlist> objReturn = new List<Reportlist>();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@CustomerId", CustomerId);
                    objReturn = db.Query<Reportlist>("udp_Report_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_Report_ups", param: objReport, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    db.Query("udp_Report_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn = true;
                }
            }
            catch (Exception ex)
            { log.Error("DeleteRecord Error: ", ex); }
            return objReturn;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

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
