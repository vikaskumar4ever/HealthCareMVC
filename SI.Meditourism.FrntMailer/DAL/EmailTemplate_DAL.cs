using Dapper;
using log4net;
using SI.Meditourism.FrntMailer.Interface;
using SI.Meditourism.FrntMailer.Model;
using SI.Meditourism.ConnectionFrnt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.FrntMailer.DAL
{
    public class EmailTemplate_DAL : IEmailTemplateRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EmailTemplate_DAL));


        public EmailTemplate GetRecorodById(Guid iId)
        {
            EmailTemplate objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<EmailTemplate>("udp_EmailTemplate_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                using (SqlConnection db = new SqlDBConnectFrnt().GetConnection())
                {
                    objReturn = db.Query<int>("udp_EmailTemplate_ups", param: objEmailTemplate, commandType: System.Data.CommandType.StoredProcedure).Single();
                }
            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
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
