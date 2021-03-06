using log4net;
using SI.Meditourism.PaymentServicesAdmin.Interface;
using SI.Meditourism.PaymentServicesAdmin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SI.Meditourism.Connection;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace SI.Meditourism.PaymentServicesAdmin.DAL
{
    public class TreatmentPaymentDetails_DAL : ITreatmentPaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(TreatmentPaymentDetails_DAL));

        public List<TreatmentPaymentDetails> GetAllRecorod()
        {
            List<TreatmentPaymentDetails> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<TreatmentPaymentDetails>("udp_TreatmentPaymentDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public TreatmentPaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize, Guid? ServiceId, Guid? CustomerId)
        {
            TreatmentPaymentDetailsPage objReturn = new TreatmentPaymentDetailsPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@CustomerId", CustomerId);
                    param.Add("@ServiceId", ServiceId);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.TreatmentPaymentDetailss = db.Query<TreatmentPagelst>("udp_TreatmentPaymentDetails_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public TreatmentPagelst GetRecorodById(Guid? iId)
        {
            TreatmentPagelst objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<TreatmentPagelst>("udp_TreatmentPaymentDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public TreatmentpaymentdetailsbCustId GetTreatmentpaymentdetailsb(Guid? iId)
        {
            TreatmentpaymentdetailsbCustId objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@CustomerId", iId);
                    objReturn = db.Query<TreatmentpaymentdetailsbCustId>("udpGetTreatmentPaymentDetailsbyCustId", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(TreatmentPaymentDetails objTreatmentPaymentDetails)
        {
            Guid? objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid?>("udp_TreatmentPaymentDetails_ups", param: objTreatmentPaymentDetails, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_TreatmentPaymentDetails_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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

