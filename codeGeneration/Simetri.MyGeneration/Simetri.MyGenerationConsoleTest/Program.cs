using System;
using System.Collections.Generic;
using System.Text;
using Simetri.MyGenerationHelper;
using Simetri.MyGenerationHelper.Generators;

namespace Simetri.MyGenerationConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //EnumHelper eh = new EnumHelper();
            //string enumSonuc = eh.GetEnumDescription("ITO", "TT_ORTAK", "SEHIR", connectionString);
            //Console.WriteLine(enumSonuc);
            DalGenerator dalGenerator = new DalGenerator();
            Zeus.ZeusOutput output = new Zeus.ZeusOutput();

            MyMeta.Sql.SqlTable table = new MyMeta.Sql.SqlTable();

            dalGenerator.Render(output, table);

        }
    }
}
