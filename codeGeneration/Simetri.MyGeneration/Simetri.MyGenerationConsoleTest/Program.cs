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

            TurkishHelper tHelper = new TurkishHelper();
            Console.WriteLine(tHelper.TurkceyeCevir("Adi"));
            Console.WriteLine(tHelper.TurkceyeCevir("Soyadi"));

            Console.WriteLine(tHelper.ReplaceTurkishChars("�anl�urfa"));


        }
    }
}
