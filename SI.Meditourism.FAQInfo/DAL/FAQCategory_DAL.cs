using System;
using Dapper;
using log4net;
using System.Linq;
using System.Data.SqlClient;
using SI.Meditourism.Connection;
using System.Collections.Generic;
using SI.Meditourism.FAQInfo.Model;
using SI.Meditourism.FAQInfo.Interface;

namespace SI.Meditourism.FAQInfo.DAL
{
    public class FAQCategory_DAL : IFAQCategoryRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(FAQCategory_DAL));

        public List<FAQCategory> GetAllRecorod()
        {
            List<FAQCategory> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<FAQCategory>("udp_FAQCategory_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public FAQCategoryPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            FAQCategoryPage objReturn = new FAQCategoryPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.FAQCategorys = db.Query<FAQCategory>("udp_FAQCategory_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public FAQCategory GetRecorodById(Guid iId)
        {
            FAQCategory objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<FAQCategory>("udp_FAQCategory_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_FAQCategory_ups", param: objFAQCategory, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_FAQCategory_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
