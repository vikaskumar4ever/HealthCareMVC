using System;
using Dapper;
using log4net;
using System.Linq;
using System.Data.SqlClient;
using SI.Meditourism.Connection;
using System.Collections.Generic;
using SI.Meditourism.Services.Model;
using SI.Meditourism.Services.Interface;

namespace SI.Meditourism.Services.DAL
{
    public class Service_DAL : IServiceRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Service_DAL));

        public List<Service> GetAllRecorod()
        {
            List<Service> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Service>("udp_Service_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public List<Treatmentlist> GetTreatmentlistautocompt(string term)
        {
            List<Treatmentlist> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@terms", term);
                    objReturn = db.Query<Treatmentlist>("udp_GetTreatmentlistAutoComp", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public Serviceslist GetTreatmentDetailsByName(string term)
        {
            Serviceslist objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@terms", term);
                    objReturn = db.Query<Serviceslist>("udp_GetTreatmentDetailsByName", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public List<ServicesPathlist> GetServicepathlists()
        {
            List<ServicesPathlist> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<ServicesPathlist>("udp_GetServicePathlist", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public List<ServicesPathlist> GetServicelistfrntEnd()
        {
            List<ServicesPathlist> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<ServicesPathlist>("udp_GetServicelistfrntEnd", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public List<Serviceslist> GetServicelists()
        {
            List<Serviceslist> objReturn = new List<Serviceslist>();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Serviceslist>("udp_GetServicelist", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public ServicePage GetRecordsPage(int iPageNo, int iPageSize, Guid? ServiceId)
        {
            ServicePage objReturn = new ServicePage();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@serviceId", ServiceId);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.Services = db.Query<Service>("udp_Service_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public Service GetRecorodById(Guid iId)
        {
            Service objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<Service>("udp_Service_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public Guid? InsertUpdateRecord(Service objService)
        {
            Guid? objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_Service_ups", param: objService, commandType: System.Data.CommandType.StoredProcedure).Single();
                }
            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
            return objReturn;
        }
        public List<Service> GetFilterServices(string Name)
        {
            List<Service> objServicesName = new List<Service>();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    objServicesName = db.Query<Service>("udp_FilterServicesByName", param: param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("Services Error: ", ex); }
            return objServicesName;
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
                    db.Query("udp_Service_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn = true;
                }
            }
            catch (Exception ex)
            { log.Error("DeleteRecord Error: ", ex); }
            return objReturn;
        }
        public GetServicedetail GetTreatMentDetails(int iId)
        {
            GetServicedetail objReturn = new GetServicedetail();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    var data = db.QueryMultiple("udp_GetTreatmentdetails", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn.GetService = data.Read<Service>().SingleOrDefault();
                    objReturn.GetServiceslists = data.Read<Serviceslist>().ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
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
