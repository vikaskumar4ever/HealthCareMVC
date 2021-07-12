using System;
using log4net;
using System.Collections.Generic;
using SI.Meditourism.CustomerInfo.DAL;
using SI.Meditourism.CustomerInfo.Model;
using SI.Meditourism.CustomerInfo.Interface;

namespace SI.Meditourism.CustomerInfo.BAL
{
    public class Customer_BAL : ICustomerRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Customer_BAL));

        public CustomerPage GetRecordsPage(int iPageNo, int iPageSize)
        {
            CustomerPage objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (Customer_DAL objDAL = new Customer_DAL())
                    {
                        objReturn = objDAL.GetRecordsPage(iPageNo, iPageSize);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }

        public List<Customer> GetAllRecorod()
        {
            List<Customer> objReturn = null;
            try
            {
                using (Customer_DAL objDAL = new Customer_DAL())
                {
                    objReturn = objDAL.GetAllRecorod();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public bool ChangePassword(string OldPassword, string NewPassword)
        {
            bool objReturn = false;
            try
            {
                //if (iId > 0)
                {
                    using (Customer_DAL objDAL = new Customer_DAL())
                    {
                        objReturn = objDAL.ChangePassword(OldPassword, NewPassword);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }
        public Customer GetRecorodById(Guid iId)
        {
            Customer objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (Customer_DAL objDAL = new Customer_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }


        public Customer GetRecorodByEmailAndPhone(string Email, string PhoneNo)
        {
            Customer objReturn = null;
            try
            {
                //if (iId > 0)
                {
                    using (Customer_DAL objDAL = new Customer_DAL())
                    {
                        objReturn = objDAL.GetRecorodByEmailAndPhone(Email, PhoneNo);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodByEmailAndPhone Error: ", ex); }
            return objReturn;
        }
        public List<Customer> GetCustomerlist(string name)
        {
            List<Customer> objReturn = new List<Customer>();
            try
            {
                //if (iId > 0)
                {
                    using (Customer_DAL objDAL = new Customer_DAL())
                    {
                        objReturn = objDAL.GetCustomerlist(name);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }
        public Customer ValidateUser(CustomerLogin value)
        {
            Customer objReturn = new Customer();
            using (Customer_DAL objDAL = new Customer_DAL())
            {
                objReturn = objDAL.ValidateUser(value);
            }
            return objReturn;
        }
        public bool ValidateEmailIdIsExist(string EmailId)
        {
            bool objReturn = false;
            using (Customer_DAL objDAL = new Customer_DAL())
            {
                objReturn = objDAL.ValidateEmailIdIsExist(EmailId);
            }
            return objReturn;
        }
        public Guid? InsertUpdateRecord(Customer objCustomer)
        {
            Guid? objReturn = null;
            try
            {
                using (Customer_DAL objDAL = new Customer_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objCustomer);
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
                    using (Customer_DAL objDAL = new Customer_DAL())
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
