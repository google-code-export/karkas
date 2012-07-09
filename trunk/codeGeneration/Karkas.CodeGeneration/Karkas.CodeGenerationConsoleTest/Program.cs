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
        public const string _ConnectionString = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";

        public static void Main(string[] args)
        {
            ConnectionSingleton.Instance.ConnectionString = _ConnectionString;

            IDatabaseHelper helper = new SqlServerHelper();

            helper.codeGenerateAllTables(_ConnectionString, "KARKAS_ORNEK", "Karkas.Ornek", "D:\\projects\\karkasTrunk\\Karkas.Ornek", true, true);
            helper.codeGenerateOneTable(_ConnectionString, "ORNEK_TABLO", "ORNEKLER", "KARKAS_ORNEK", "Karkas.Ornek", "D:\\projects\\karkasTrunk\\Karkas.Ornek");
        }


        private static void schemaListesiEkranaYaz()
        {
            Utils uti = new Utils();
            string[] schemalar = uti.GetSchemaList("KARKAS_ORNEK", _ConnectionString);
            foreach (var item in schemalar)
            {
                Console.WriteLine(item);
            }
        }
    }
}

