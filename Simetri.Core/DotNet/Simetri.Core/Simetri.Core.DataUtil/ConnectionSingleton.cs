using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Simetri.Core.DataUtil
{
    public class ConnectionSingleton
    {
        private string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NPetshop;Data Source=ATILAPTOP\SQLEXPRESS";

        public string ConnectionString
        {
            get { return connectionString; }
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

        }

    }
}
