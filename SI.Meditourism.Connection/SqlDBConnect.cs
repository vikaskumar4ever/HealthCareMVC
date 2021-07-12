using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SI.Meditourism.Connection
{
    public class SqlDBConnect: IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public SqlConnection GetConnection()
        {
              return new SqlConnection("Data Source=LENOVO-PC/SQLEXPRESS;Initial Catalog=MediTourism;");
            //return new SqlConnection("Data Source=sql7001.site4now.net;Initial Catalog=DB_A3CB41_mt1;User Id=DB_A3CB41_mt1_admin;Password=ShreW89@67D;");
            //return new SqlConnection("Data Source=sql5036.site4now.net;Initial Catalog=DB_A46B5A_mt;User Id=DB_A46B5A_mt_admin;Password=ShreW89@67D;");
        }
    }
}
