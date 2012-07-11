using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.OracleExample.Bs.Hr;
using Karkas.OracleExample.TypeLibrary.Hr;

namespace Karkas.OracleExample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            CountriesBs bs = new CountriesBs();
            List<Countries> liste = bs.SorgulaHepsiniGetir();
            foreach (var item in liste)
            {
                Console.WriteLine(item);
            }

        }
    }
}
