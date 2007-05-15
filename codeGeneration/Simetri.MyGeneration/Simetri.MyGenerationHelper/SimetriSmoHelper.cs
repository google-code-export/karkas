using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace Simetri.MyGenerationHelper
{
    public class SimetriSmoHelper
    {

        public string GetTableDescription(string pDatabaseName, string pSchemaName, string pTableName, string connectionString)
        {
            int count = connectionString.IndexOf(';');
            connectionString = connectionString.Remove(0,count);
            Server server = new Server(new ServerConnection(new SqlConnection(connectionString)));
            Database db = server.Databases[pDatabaseName];
            Table t = db.Tables[pTableName, pSchemaName];
            ScriptingOptions baseOptions = new ScriptingOptions();
            baseOptions.NoCollation = true;
            baseOptions.SchemaQualify = true;
            baseOptions.DriDefaults = true;
            baseOptions.IncludeHeaders = true;
            baseOptions.DriPrimaryKey = true;

//            baseOptions.DriAll = true;

            //baseOptions.Indexes = true;
            //baseOptions.DriAllKeys = true;
            //baseOptions.SchemaQualifyForeignKeysReferences = true;

            

            baseOptions.EnforceScriptingOptions = true;

            StringCollection yaziDizisi = t.Script(baseOptions);
            return StringOlustur(yaziDizisi);
        }

        private static string StringOlustur(StringCollection yaziDizisi)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in yaziDizisi)
            {
                sb.Append(s);
                sb.Append(Environment.NewLine);
                sb.Append("GO" + Environment.NewLine);
            }
            return sb.ToString();
        }
        public string GetTableRelationDescriptions(string pDatabaseName, string pSchemaName, string pTableName, string connectionString)
        {
            int count = connectionString.IndexOf(';');
            connectionString = connectionString.Remove(0, count);
            Server server = new Server(new ServerConnection(new SqlConnection(connectionString)));
            Database db = server.Databases[pDatabaseName];
            Table t = db.Tables[pTableName, pSchemaName];
            ScriptingOptions baseOptions = new ScriptingOptions();
            baseOptions.NoCollation = true;
            baseOptions.SchemaQualify = true;
            baseOptions.DriDefaults = true;
            baseOptions.IncludeHeaders = true;
            baseOptions.DriPrimaryKey = true;

            baseOptions.DriAll = true;


            baseOptions.EnforceScriptingOptions = true;

            StringCollection yaziDizisi = t.Script(baseOptions);
            StringBuilder sb = new StringBuilder();
            bool startAdding = false;
            foreach (String s in yaziDizisi)
            {
                if (s.Contains("ALTER TABLE"))
                {
                    startAdding = true;
                }
                if (startAdding)
                {
                    sb.Append(s);
                    sb.Append(Environment.NewLine);
                    sb.Append("GO");
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();



        }


    }
}
