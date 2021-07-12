using System;
using System.Collections.Generic;
using log4net;
using SI.Meditourism.PaymentServicesAdmin.Interface;
using SI.Meditourism.PaymentServicesAdmin.Model;
using System.Data.SqlClient;
using SI.Meditourism.Connection;
using System.Text;
using Dapper;
using System.Linq;

namespace SI.Meditourism.PaymentServicesAdmin.DAL
{
    public class RegistrationFeePaymentDetails_DAL : IRegistrationFeePaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RegistrationFeePaymentDetails_DAL));

        public List<RegistrationFeePaymentDetails> GetAllRecorod()
        {
            List<RegistrationFeePaymentDetails> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<RegistrationFeePaymentDetails>("udp_RegistrationFeePaymentDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
      

        public RegistrationFeePaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize, Guid? CustomerId)
        {
            RegistrationFeePaymentDetailsPage objReturn = new RegistrationFeePaymentDetailsPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@CustomerId", CustomerId);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.RegistrationFeePaymentDetailss = db.Query<RegistrationFeePaymentdetailslst>("udp_RegistrationFeePaymentDetails_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public RegistrationFeePaymentdetailslst GetRecorodById(Guid? iId)
        {
            RegistrationFeePaymentdetailslst objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<RegistrationFeePaymentdetailslst>("udp_RegistrationFeePaymentDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(RegistrationFeePaymentDetails objRegistrationFeePaymentDetails)
        {
            Guid? objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_RegistrationFeePaymentDetails_ups", param: objRegistrationFeePaymentDetails, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_RegistrationFeePaymentDetails_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
