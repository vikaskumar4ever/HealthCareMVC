using System;
using log4net;
using Microsoft.AspNetCore.Http;

namespace SI.Meditourism.Common
{
    public class Helper: IDisposable
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Helper));

        public void Dispose()
        {

        }

        public String GetUserIP(ConnectionInfo connection)
        {
            return connection.RemoteIpAddress.ToString();
        }
    }
}
