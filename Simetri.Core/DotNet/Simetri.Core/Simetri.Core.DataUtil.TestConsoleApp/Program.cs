using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Dal.Ortak;
using Simetri.Core.TypeLibrary.Ortak;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fotograf f = new Fotograf();
            f.Id = Guid.NewGuid();
            f.KisiKey = new Guid("88eea455-a134-46c1-8df0-7d3592192576");
            f.FotografVerisi = new byte[] { 100, 200, 120 };

            FotografDal fDal = new FotografDal();
            fDal.Ekle(f);

        }
    }
}
