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
            SimetriSmoHelper helper = new SimetriSmoHelper();
//            Console.WriteLine(helper.GetTableDescription("ITO_MTK", "INSAN_KAYNAKLARI", "KISI_CALISTIGI_YERLER"));
            Console.WriteLine(helper.GetTableRelationDescriptions("ITO_MTK", "INSAN_KAYNAKLARI", "KISI_CALISTIGI_YERLER", ""));

        }
    }
}
