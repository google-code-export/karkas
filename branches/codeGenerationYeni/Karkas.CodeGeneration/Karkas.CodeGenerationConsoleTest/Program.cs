using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGenerationHelper.Generators;
using System.Configuration;
using Karkas.MyGenerationTest;
using Karkas.Core.DataUtil;
using Karkas.CodeGenerationHelper.SmoHelpers;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        public const string insertConnString = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=KARKAS_ORNEK;Data Source=localhost";

        public static void Main(string[] args)
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

