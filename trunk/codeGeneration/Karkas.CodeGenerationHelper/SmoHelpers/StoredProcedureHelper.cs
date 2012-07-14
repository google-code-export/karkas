using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace Karkas.CodeGenerationHelper.SmoHelpers
{
    internal class StoredProcedureHelper
    {
        public static List<string> GetUserStoredProcedures(string pDatabaseName, string connectionString)
        {
            List<string> spList = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));
            //server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");

            Database database = server.Databases[pDatabaseName];

            foreach (StoredProcedure sp in database.StoredProcedures)
            {
                if (sp.Schema != "sys")
                {
                    spList.Add(sp.Schema + "." + sp.Name);
                }
            }

            return spList;
        }

        public static List<string> GetUserStoredProcedures(string pDatabaseName, string pSchemaName, string connectionString)
        {
            List<string> spList = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));

            Database database = server.Databases[pDatabaseName];

            foreach (StoredProcedure sp in database.StoredProcedures)
            {
                if (sp.Schema == pSchemaName)
                {
                    spList.Add(sp.Schema + "." + sp.Name);
                }
            }

            return spList;
        }

        public static string GetStoredProcedureDescription(string pDatabaseName, string pSchemaName, string pStoredProcedureName, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));
            Database database = server.Databases[pDatabaseName];

            StoredProcedure sp = database.StoredProcedures[pStoredProcedureName, pSchemaName];

            StringBuilder script = new StringBuilder();
            foreach (string line in sp.Script())
            {
                script.Append(line);
            }

            return script.ToString();
        }
    }
}

