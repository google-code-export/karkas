using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGeneration.SqlServer.Implementations;
using Karkas.Core.DataUtil;
using Karkas.CodeGenerationHelper;
using System.Data;

namespace Karkas.CodeGeneration.SqlServer
{
    public class SqlServerHelper : IDatabaseHelper
    {

        private const string SQL__FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT DISTINCT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
";



        private const string SQL_FOR_TABLE_LIST = @"
SELECT TABLE_SCHEMA,TABLE_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
AND
TABLE_TYPE = 'BASE TABLE'
ORDER BY FULL_TABLE_NAME
";

        private const string SQL_FOR_DATABASE_NAME = @"
SELECT DISTINCT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES
";

        public string getDatabaseName(AdoTemplate template)
        {
            return (string)template.TekDegerGetir(SQL_FOR_DATABASE_NAME);
        }

        public DataTable getTableListFromSchema(AdoTemplate template,string schemaName)
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        public DataTable getSchemaList(AdoTemplate template)
        {
            return template.DataTableOlustur(SQL__FOR_SCHEMA_LIST);
        }




        public void CodeGenerateAllTables(AdoTemplate template,string pConnectionString, string pDatabaseName, string pProjectNamespace
            , string pProjectFolder
            ,bool dboSemaTablolariniAtla
            ,bool sysTablolariniAtla)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator();
            DalGenerator dalGen = new DalGenerator();
            BsGenerator bsGen = new BsGenerator();
            IOutput output = new SqlServerOutput();
            DatabaseSqlServer database = new DatabaseSqlServer(pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            List<ITable> tableListesi = database.Tables;

            foreach (ITable table in tableListesi)
            {
                if (dboSemaTablolariniAtla && table.Schema == "dbo")
                {
                    continue;
                }
                if (sysTablolariniAtla && (table.Name.StartsWith("sys") || table.Name == "dtproperties"))
                {
                    continue;
                }
                typeGen.Render(output, table);
                dalGen.Render(output, table);
                bsGen.Render(output, table);
            }
        }

        public void CodeGenerateOneTable(AdoTemplate template, string pConnectionString, string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator();
            DalGenerator dalGen = new DalGenerator();
            BsGenerator bsGen = new BsGenerator();
            IOutput output = new SqlServerOutput();
            DatabaseSqlServer database = new DatabaseSqlServer(pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            ITable table = database.getTable(pTableName, pSchemaName);

            typeGen.Render(output, table);
            dalGen.Render(output, table);
            bsGen.Render(output, table);
        }




    }
}
