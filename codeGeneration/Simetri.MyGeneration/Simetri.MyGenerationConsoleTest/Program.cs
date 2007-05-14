using System;
using System.Collections.Generic;
using System.Text;
using Simetri.MyGenerationHelper;

namespace Simetri.MyGenerationConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SimetriXmlParser parser = new SimetriXmlParser();
            Console.WriteLine(parser.ProjeDizininiAlSchemaIle(null, "DENEME"));
            Console.WriteLine(parser.ProjeDizininiAlSchemaIle(null, "ORTAK"));

        }
    }
}
