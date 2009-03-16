using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper;
using Karkas.MyGenerationHelper.Generators;
using System.Configuration;
using MyMeta;
using Karkas.MyGenerationTest;
using Karkas.Core.DataUtil;
using Karkas.MyGenerationHelper.SmoHelpers;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        const string ConnectionString = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
        const string insertConnString = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=DAMAK_TADI;Data Source=BASAR-PC\SQLEXPRESS2";
        const string insertTableName = "GENEL";
        const string insertSchemaName = "PERSONEL";
        const string insertDBName = "DAMAK_TADI";

        public static void Main(string[] args)
        {
            //SmoHelper helper = new SmoHelper();
            //string insert = helper.GetSysdiagramsInserts(ConnectionString);

            //AdoTemplate template = new AdoTemplate();

            //template.SorguHariciKomutCalistir(insert);
            //Console.WriteLine(insert);

            InsertScriptHelper iHelper = new InsertScriptHelper();
            iHelper.GetRowsToBeInserted(insertDBName, insertSchemaName, insertTableName, insertConnString);

            //Utils uti = new Utils();
            //string[] schemalar = uti.GetSchemaList("KARKAS_ORNEK", ConnectionString);
            //foreach (var item in schemalar)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}

