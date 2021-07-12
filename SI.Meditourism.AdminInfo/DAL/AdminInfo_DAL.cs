using System;
using Dapper;
using log4net;
using System.Linq;
using System.Data.SqlClient;
using SI.Meditourism.Connection;
using System.Collections.Generic;
using SI.Meditourism.AdminInfo.Model;
using SI.Meditourism.AdminInfo.Interface;

namespace SI.Meditourism.AdminInfo.DAL
{
    public class AdminInfo_DAL : IAdminInfoRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AdminInfo_DAL));

        public bool CheckOldpwd(ChangePassword value)
        {
            bool objReturn = false;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@EmailId ", value.email);
                    param.Add("@oldpassword", value.oldPassword);
                    param.Add("@newpassword", value.passwordHash);
                    objReturn = db.Query<bool>("udp_Checkoldpwd", param: param, commandType: System.Data.CommandType.StoredProcedure).Single();

                }

            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
            return objReturn;
        }

        public Admin ValidateUser(Admin objAdmin)
        {
            Admin objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@EmailId", objAdmin.EmailId);
                    param.Add("@PasswordHash", objAdmin.PasswordHash);
                    objReturn = db.Query<Admin>("udp_Admin_validateUser", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("AdminValidateUser Error: ", ex); }
            return objReturn;
        }

        public List<Admin> GetAllRecorod()
        {
            List<Admin> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Admin>("udp_AdminInfo_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public AdminInfoPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            AdminInfoPage objReturn = new AdminInfoPage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.AdminInfos = db.Query<Admin>("udp_AdminInfo_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public Admin GetRecorodById(Guid iId)
        {
            Admin objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<Admin>("udp_AdminInfo_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(Admin objAdminInfo)
        {
            Guid? objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_AdminInfo_ups", param: objAdminInfo, commandType: System.Data.CommandType.StoredProcedure).Single();
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
                    db.Query("udp_AdminInfo_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
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
