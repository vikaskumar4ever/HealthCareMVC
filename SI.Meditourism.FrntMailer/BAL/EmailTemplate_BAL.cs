using log4net;
using SI.Meditourism.FrntMailer.DAL;
using SI.Meditourism.FrntMailer.Interface;
using SI.Meditourism.FrntMailer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.FrntMailer.BAL
{
    public class EmailTemplate_BAL : IEmailTemplateRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EmailTemplate_BAL));

        public EmailTemplate GetRecorodById(Guid iId)
        {
            EmailTemplate objReturn = null;
            try
            {
                //  if (iId > 0)
                {
                    using (EmailTemplate_DAL objDAL = new EmailTemplate_DAL())
                    {
                        objReturn = objDAL.GetRecorodById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public int InsertUpdateRecord(EmailTemplate objEmailTemplate)
        {
            int objReturn = 0;
            try
            {
                using (EmailTemplate_DAL objDAL = new EmailTemplate_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objEmailTemplate);
                }
            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
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
