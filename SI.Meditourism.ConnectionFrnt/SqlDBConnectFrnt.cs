using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Meditourism.ConnectionFrnt
{
    public class SqlDBConnectFrnt : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public SqlConnection GetConnection()
        {
            //return new SqlConnection("Data Source=SHREWDDC;Initial Catalog=MediTourism;User Id=mt1;Password=Shre@56#EW67D;");
            //  return new SqlConnection("Data Source=sql7001.site4now.net;Initial Catalog=DB_A3CB41_mt1;User Id=DB_A3CB41_mt1_admin;Password=ShreW89@67D;");
             return new SqlConnection("Data Source=sql5036.site4now.net;Initial Catalog=DB_A46B5A_mt;User Id=DB_A46B5A_mt_admin;Password=ShreW89@67D;");
        }
    }
}
