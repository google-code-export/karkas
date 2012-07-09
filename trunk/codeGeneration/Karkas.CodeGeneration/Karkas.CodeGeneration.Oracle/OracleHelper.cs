using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Oracle
{
    public class OracleHelper : IDatabaseHelper
    {
        private const string SQL_FOR_DATABASE_NAME = "Select name from v$database";
        private const string SQL_FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM DUAL
UNION
select username from dba_users
ORDER BY TABLE_SCHEMA";
        private const string SQL_FOR_TABLE_LIST = @"
SELECT OWNER AS TABLE_SCHEMA, OWNER || '.' || TABLE_NAME  AS FULL_TABLE_NAME  FROM  ALL_TABLES T
WHERE  
(:TABLE_SCHEMA IS NULL) OR (OWNER = :TABLE_SCHEMA)

ORDER BY FULL_TABLE_NAME
";

        public string getDatabaseName(AdoTemplate template)
        {
            return (string)template.TekDegerGetir(SQL_FOR_DATABASE_NAME);

        }

        public DataTable getTableListFromSchema(AdoTemplate template, string schemaName)
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle(":TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }


        public DataTable getSchemaList(AdoTemplate template)
        {
            return template.DataTableOlustur(SQL_FOR_SCHEMA_LIST);
        }


        public void CodeGenerateAllTables(string pConnectionString, string pDatabaseName, string pProjectNamespace, string pProjectFolder, bool dboSemaTablolariniAtla, bool sysTablolariniAtla)
        {
            throw new NotImplementedException();
        }

        public void CodeGenerateOneTable(string pConnectionString, string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder)
        {
            throw new NotImplementedException();
        }
    }
}
