using System;
using System.Collections.Generic;
using System.Text;
using Simetri.MyGenerationHelper;

namespace Simetri.MyGenerationConsoleTest
{
    public class Program
    {
        static string connectionStringWithProvider = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=ITO;Data Source=ATILAPTOP\SQLEXPRESS";
        static string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ITO;Data Source=.\SQLEXPRESS";
        public static void Main(string[] args)
        {


            SimetriSmoHelper helper = new SimetriSmoHelper();
            Console.WriteLine(helper.GetTableDescription("ITO", "TT_INSAN_KAYNAKLARI", "YAYIN_KATEGORI",connectionStringWithProvider));
//            Console.WriteLine(helper.GetTableRelationDescriptions("ITO", "INSAN_KAYNAKLARI", "KISI_CALISTIGI_YERLER", ""));

        }
    }
}
