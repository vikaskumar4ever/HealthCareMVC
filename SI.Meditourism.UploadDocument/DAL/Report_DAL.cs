using System;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using SI.Meditourism.Connection_Mvc;
using System.Collections.Generic;
using SI.Meditourism.UploadDocument.Model;
using SI.Meditourism.UploadDocument.Interface;

namespace SI.Meditourism.UploadDocument.DAL
{
    public class Report_DAL : IReportRepository
    {

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
            { }
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
            {  }
            return objReturn;
        }

        public Guid InsertUpdateRecord(Report objReport)
        {
            Guid objReturn = Guid.Empty;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_Report_ups", param: objReport, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    db.Query("udp_Report_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn = true;
                }
            }
            catch (Exception ex)
            {  }
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
