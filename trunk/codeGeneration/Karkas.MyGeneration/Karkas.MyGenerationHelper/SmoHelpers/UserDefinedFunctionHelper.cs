using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace Karkas.MyGenerationHelper.SmoHelpers
{
    internal class UserDefinedFunctionHelper
    {
        public static List<string> GetUserFunctions(string pDatabaseName, string connectionString) 
        {
            List<string> fnList = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));
            //server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");

            Database database = server.Databases[pDatabaseName];

            foreach (UserDefinedFunction uf in database.UserDefinedFunctions)
            {
                if (uf.Schema != "sys")
                {
                    fnList.Add(uf.Schema + "." + uf.Name);
                }
            }

            return fnList;
        }

        public static List<string> GetUserFunctions(string pDatabaseName, string pSchemaName, string connectionString)
        {
            List<string> fnList = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));
            //server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");

            Database database = server.Databases[pDatabaseName];

            foreach (UserDefinedFunction uf in database.UserDefinedFunctions)
            {
                if (uf.Schema == pSchemaName)
                {
                    fnList.Add(uf.Schema + "." + uf.Name);
                }
            }

            return fnList;
        }

        public static string GetFunctionDescription(string pDatabaseName, string pSchemaName, string pFunctionName, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));
            Database database = server.Databases[pDatabaseName];

            UserDefinedFunction fn = database.UserDefinedFunctions[pFunctionName, pSchemaName];

            StringBuilder script = new StringBuilder();
            foreach (string line in fn.Script())
            {
                script.Append(line);
            }

            return script.ToString();
        }
    }
}
