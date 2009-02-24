using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Karkas.MyGenerationHelper
{
    public class SmoHelper
    {

        public string GetTableDescription(string pDatabaseName, string pSchemaName, string pTableName, string connectionString)
        {
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(connectionString);
            Server server = new Server(new ServerConnection(new SqlConnection(connectionString)));
            Database db = server.Databases[pDatabaseName];
            Table t = db.Tables[pTableName, pSchemaName];
            ScriptingOptions baseOptions = new ScriptingOptions();
            baseOptions.NoCollation = true;
            baseOptions.SchemaQualify = true;
            baseOptions.DriDefaults = true;
            baseOptions.IncludeHeaders = false;
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
                sb.Append("GO --ExecuteThisSql" + Environment.NewLine);
            }
            return sb.ToString();
        }
        public string GetTableRelationDescriptions(string pDatabaseName, string pSchemaName, string pTableName, string connectionString)
        {
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(connectionString);
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
            baseOptions.IncludeHeaders = false;
            baseOptions.IncludeIfNotExists = true;

            baseOptions.SchemaQualifyForeignKeysReferences = true;


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
                    sb.Append("GO --ExecuteThisSql" + Environment.NewLine);
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();



        }


        string[] ignoredSchemas = {"db_accessadmin"
                                    ,"db_backupoperator"
                                    ,"db_datareader"
                                    ,"db_datawriter"
                                    ,"db_ddladmin"
                                    ,"db_denydatareader"
                                    ,"db_denydatawriter"
                                    ,"db_owner"
                                    ,"db_securityadmin"
                                    ,"dbo"
                                    ,"guest"
                                    ,"INFORMATION_SCHEMA"
                                    ,"sys"
                                    };

        internal string[] GetSchemaList(string pDatabaseName, string pConnectionString)
        {
            pConnectionString = ConnectionHelper.RemoveProviderFromConnectionString(pConnectionString);
            Server server = new Server(new ServerConnection(new SqlConnection(pConnectionString)));
            Database db = server.Databases[pDatabaseName];

            List<string> schemaList = new List<string>();
            foreach (Schema item in db.Schemas)
            {
                var list = from str in ignoredSchemas
                           where str == item.Name
                               select str;
                if (list.ToArray().Length > 0)
                {
                    continue;
                }
                schemaList.Add(item.Name);
            }
            return schemaList.ToArray();

        }
    }
}

