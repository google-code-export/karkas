using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Simetri.Core.DataUtil
{
    public class ConnectionSingleton
    {

        private string connectionString = null;

        public string ConnectionString
        {
            get 
            {
                return connectionString; 
            }
            set { connectionString = value; }
        }


        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        private static ConnectionSingleton _instance = new ConnectionSingleton();

        public static ConnectionSingleton Instance
        {
            get { return ConnectionSingleton._instance; }
            set { ConnectionSingleton._instance = value; }
        }
        private ConnectionSingleton()
        {
            if (connectionString == null)
            {
                if (ConfigurationManager.ConnectionStrings["Main"].ConnectionString != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
                }
                else
                {
                    connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ITO_MTK;Data Source=LOCALHOST\SQLEXPRESS";
                }

            }
        }

    }
}
