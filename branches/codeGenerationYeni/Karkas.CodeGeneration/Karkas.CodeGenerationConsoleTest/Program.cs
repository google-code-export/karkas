using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGenerationHelper.Generators;
using System.Configuration;
using Karkas.MyGenerationTest;
using Karkas.Core.DataUtil;
using Karkas.CodeGenerationHelper.SmoHelpers;
using Karkas.CodeGeneration.SqlServer;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGeneration.SqlServer.Implementations;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";

        public static void Main(string[] args)
        {
            ConnectionSingleton.Instance.ConnectionString = ConnectionString;

            codeGenerateAllTables("KARKAS_ORNEK", "Karkas.Ornek", "D:\\projects\\karkasTrunk\\Karkas.Ornek");
            //codeGenerateOneTable("ORNEK_TABLO","ORNEKLER","KARKAS_ORNEK", "Karkas.Ornek", "D:\\projects\\karkasTrunk\\Karkas.Ornek");
        }

        private static void codeGenerateAllTables(string pDatabaseName, string pProjectNamespace, string pProjectFolder)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator();
            DalGenerator dalGen = new DalGenerator();
            BsGenerator bsGen = new BsGenerator();
            IOutput output = new SqlServerOutput();
            DatabaseSqlServer database = new DatabaseSqlServer(ConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            List<ITable> tableListesi = database.Tables;

            foreach (ITable table in tableListesi)
            {
                typeGen.Render(output, table);
                dalGen.Render(output, table);
                bsGen.Render(output, table);
            }
        }

        private static void codeGenerateOneTable(string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator();
            DalGenerator dalGen = new DalGenerator();
            BsGenerator bsGen = new BsGenerator();
            IOutput output = new SqlServerOutput();
            DatabaseSqlServer database = new DatabaseSqlServer(ConnectionString, pDatabaseName, pProjectNamespace, pProjectFolder);

            ITable table = database.getTable(pTableName, pSchemaName);

            typeGen.Render(output, table);
            dalGen.Render(output, table);
            bsGen.Render(output, table);
        }

        private static void schemaListesiEkranaYaz()
        {
            Utils uti = new Utils();
            string[] schemalar = uti.GetSchemaList("KARKAS_ORNEK", ConnectionString);
            foreach (var item in schemalar)
            {
                Console.WriteLine(item);
            }
        }
    }
}

