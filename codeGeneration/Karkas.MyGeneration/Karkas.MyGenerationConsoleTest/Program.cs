using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper;
using Karkas.MyGenerationHelper.Generators;
using System.Configuration;
using MyMeta;
using Karkas.MyGenerationTest;
using Karkas.Core.DataUtil;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        const string ConnectionString = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        public static void Main(string[] args)
        {
            SmoHelper helper = new SmoHelper();
            string insert = helper.GetSysdiagramsInserts(ConnectionString);


            AdoTemplate template = new AdoTemplate();

            template.SorguHariciKomutCalistir(insert);
            Console.WriteLine(insert);


            //Utils uti = new Utils();
            //string[] schemalar = uti.GetSchemaList("KARKAS_ORNEK", ConnectionString);
            //foreach (var item in schemalar)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}

