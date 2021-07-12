using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.AdminInfo.DAL;
using SI.Meditourism.AdminInfo.Model;
using SI.Meditourism.AdminInfo.Interface;

namespace SI.Meditourism.AdminInfo.BAL
{
    public class AdminInfo_BAL : IAdminInfoRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AdminInfo_BAL));
        public bool CheckOldpwd(ChangePassword value)
        {
            bool objReturn = false;
            using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
            {
                objReturn = objDAL.CheckOldpwd(value);
            }
            return objReturn;
        }

        public Admin ValidateUser(Admin objAdmin)
        {
            Admin objReturn = null;
            try
            {
                using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
                {
                    objReturn = objDAL.ValidateUser(objAdmin);
                }
            }
            catch (Exception ex)
            { log.Error("Admin ValidateUser Error: ", ex); }
            return objReturn;
        }

        public AdminInfoPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            AdminInfoPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<Admin> GetAllRecorod()
        {
            List<Admin> objReturn = null;
            try
            {
                using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }

        public Admin GetRecorodById(Guid iId)
        {
            Admin objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
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
                using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objAdminInfo);
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
                    using (AdminInfo_DAL objDAL = new AdminInfo_DAL())
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
