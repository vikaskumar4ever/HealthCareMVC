using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.Services.DAL;
using SI.Meditourism.Services.Model;
using SI.Meditourism.Services.Interface;

namespace SI.Meditourism.Services.BAL
{
    public class Service_BAL : IServiceRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Service_BAL));

        public ServicePage GetRecordsPage(int iPageNo, int iPageSize, Guid? ServiceId)
        {
            ServicePage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (Service_DAL objDAL = new Service_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize, ServiceId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public List<ServicesPathlist> GetServicepathlists()
        {
            List<ServicesPathlist> objClientService = new List<ServicesPathlist>();
            try
            {
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objClientService = objDAL.GetServicepathlists();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objClientService;
        }
        public List<ServicesPathlist> GetServicelistfrntEnd()
        {
            List<ServicesPathlist> objClientService = new List<ServicesPathlist>();
            try
            {
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objClientService = objDAL.GetServicelistfrntEnd();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objClientService;
        }
        public List<Serviceslist> GetServicelists()
        {
            List<Serviceslist> objClientService = new List<Serviceslist>();
            try
            {
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objClientService = objDAL.GetServicelists();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objClientService;
        }
        public List<Service> GetAllRecorod()
        {
            List<Service> objReturn = null;
            try
            {
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
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
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objReturn = objDAL.GetTreatmentlistautocompt(term);
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
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objReturn = objDAL.GetTreatmentDetailsByName(term);
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public Service GetRecorodById(Guid iId)
        {
            Service objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (Service_DAL objDAL = new Service_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
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
                using (Service_DAL objDAL = new Service_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objService);
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
                //if (iId > 0)
                {
                    using (Service_DAL objDAL = new Service_DAL())
                    {
                        objServicesName = objDAL.GetFilterServices(Name);
                    }
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
                if (iId > 0)
                {
                    using (Service_DAL objDAL = new Service_DAL())
                    {
                        objReturn = objDAL.DeleteRecord(iId);
                    }
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
                    using (Service_DAL objDAL = new Service_DAL())
                    {
                        objReturn = objDAL.GetTreatMentDetails(iId);
                    }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
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
