using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGeneration.SqlServer.Implementations;

namespace Karkas.CodeGeneration.SqlServer
{
    public class SqlServerHelper
    {
        public static void codeGenerateAllTables(string pConnectionString, string pDatabaseName, string pProjectNamespace, string pProjectFolder)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator();
            DalGenerator dalGen = new DalGenerator();
            BsGenerator bsGen = new BsGenerator();
            IOutput output = new SqlServerOutput();
            DatabaseSqlServer database = new DatabaseSqlServer(pConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            List<ITable> tableListesi = database.Tables;

            foreach (ITable table in tableListesi)
            {
                typeGen.Render(output, table);
                dalGen.Render(output, table);
                bsGen.Render(output, table);
            }
        }

        public static void codeGenerateOneTable(string pConnectionString, string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder)
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
