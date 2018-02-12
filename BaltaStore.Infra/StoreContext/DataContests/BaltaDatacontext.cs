using BaltaStore.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BaltaStore.Infra.StoreContext.DataContests
{
    public class BaltaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaltaDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
