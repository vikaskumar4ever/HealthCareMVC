using Dapper;
using log4net;
using SI.Meditourism.PaymentServices.Interface;
using SI.Meditourism.PaymentServices.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SI.Meditourism.ConnectionFrnt;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.PaymentServices.DAL
{
    public class RegistrationFeePaymentDetails_DAL : IRegistrationFeePaymentDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RegistrationFeePaymentDetails_DAL));

        public List<RegistrationFeePaymentDetails> GetAllRecorod()
        {
            List<RegistrationFeePaymentDetails> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    objReturn = db.Query<RegistrationFeePaymentDetails>("udp_RegistrationFeePaymentDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public RegistrationFee RegistrationFeeDetails()
        {
            RegistrationFee objReturn = new RegistrationFee();
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    objReturn = db.Query<RegistrationFee>("GET_RegFeeDetails", commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public bool ChkCustomerIdExistInRegistationPyament(Guid? CustomerId)
        {
            RegistrationFeePaymentDetails _RegistrationFeePaymentDetails = new RegistrationFeePaymentDetails();
            bool objReturn = false;
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@CustomerId", CustomerId);
                    _RegistrationFeePaymentDetails = db.Query<RegistrationFeePaymentDetails>("udp_GetCustomerIdExistOrNot", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                    if (_RegistrationFeePaymentDetails != null)
                    {
                        objReturn = true;
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public bool ChkCustomerIdExistOrNot(Guid? CustomerId)
        {
            bool objReturn = false;
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@CustomerId", CustomerId);
                    objReturn = db.Query<bool>("udp_ChkCustomerIdExistOrNotInCustomertbl", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public Customer GetCustomerDetails(Guid? CustomerId)
        {
            Customer objReturn = new Customer();
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@CustomerId", CustomerId);
                    objReturn = db.Query<Customer>("GetCustomerDetailsById", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public RegistrationFeePaymentDetailsPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            RegistrationFeePaymentDetailsPage objReturn = new RegistrationFeePaymentDetailsPage();
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.RegistrationFeePaymentDetailss = db.Query<RegistrationFeePaymentDetails>("udp_RegistrationFeePaymentDetails_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public RegistrationFeePaymentDetails GetRecorodById(int iId)
        {
            RegistrationFeePaymentDetails objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<RegistrationFeePaymentDetails>("udp_RegistrationFeePaymentDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
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
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
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
