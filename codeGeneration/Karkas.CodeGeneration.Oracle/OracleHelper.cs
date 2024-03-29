﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGeneration.Oracle.Implementations;
using Karkas.CodeGeneration.Oracle.Generators;

namespace Karkas.CodeGeneration.Oracle
{
    public class OracleHelper : IDatabaseHelper
    {



        private const string SQL_FOR_DATABASE_NAME = "select sys_context('userenv','db_name') from dual";
        private const string SQL_FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM DUAL
UNION
select username from ALL_users
ORDER BY TABLE_SCHEMA";
        private const string SQL_FOR_TABLE_LIST = @"
SELECT OWNER AS TABLE_SCHEMA, TABLE_NAME,OWNER || '.' || TABLE_NAME  AS FULL_TABLE_NAME  FROM  ALL_TABLES T
WHERE  
(:TABLE_SCHEMA IS NULL) OR ( lower(OWNER) = lower(:TABLE_SCHEMA))

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




        public void CodeGenerateAllTables(
            AdoTemplate template
            , string pConnectionString
            , string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , bool dboSemaTablolariniAtla
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            )
        {
           
            
            string userName = getUserNameFromConnection(pConnectionString);

            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("TABLE_SCHEMA", DbType.String, userName);

            DataTable dtTables = template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            foreach (DataRow row in dtTables.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                string schemaName = row["TABLE_SCHEMA"].ToString();
                CodeGenerateOneTable(template, pConnectionString, tableName, schemaName, pDatabaseName, pProjectNamespace
                    , pProjectFolder
                    , listDatabaseAbbreviations
                    );
            }

        }

        private string getUserNameFromConnection(string pConnectionString)
        {
            string userName = null;
            string[] list = pConnectionString.Split(';');
            foreach (string item in list)
            {
                if (item.Contains("User ID"))
                {
                    userName = item.Replace("User ID", "");
                    userName = userName.Replace("=", "");
                    userName = userName.Trim();
                    break;
                }
            }
            return userName;
        }

        public void CodeGenerateOneTable(AdoTemplate template
            , string pConnectionString
            , string pTableName
            , string pSchemaName
            , string pDatabaseName
            , string pProjectNamespace
            , string pProjectFolder
            , List<DatabaseAbbreviations> listDatabaseAbbreviations
            )
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);
            IOutput output = new OracleOutput();
            DatabaseOracle database = new DatabaseOracle(template,pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            ITable table = database.getTable(pTableName, pSchemaName);


            typeGen.Render(output, table, listDatabaseAbbreviations);
            dalGen.Render(output, table, listDatabaseAbbreviations);
            bsGen.Render(output, table, listDatabaseAbbreviations);
        }


        public DalGenerator DalGenerator
        {
            get { return new OracleDalGenerator(this); }
        }


        public string getDefaultSchema(AdoTemplate template)
        {
            string connectionString = template.Connection.ConnectionString;
            return getUserNameFromConnection(connectionString);

        }


    }
}
