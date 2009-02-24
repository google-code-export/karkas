using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper;
using Karkas.MyGenerationHelper.Generators;
using System.Configuration;
using MyMeta;
using Karkas.MyGenerationTest;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {


            Utils uti = new Utils();
            string[] schemalar = uti.GetSchemaList("KARKAS_ORNEK", "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True");
            foreach (var item in schemalar)
            {
                Console.WriteLine(item);
            }
        }
    }
}

