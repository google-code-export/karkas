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
            KisiDal dal = new KisiDal();
            Guid kisiID;
            Kisi k = new Kisi();
            k.Id = Guid.NewGuid();
            k.Adi = "Pýnar";
            k.Soyadi = "Ün";
            dal.Ekle(k);


            Kisi k2 = dal.SorgulaIDIle(k.Id);
            Console.WriteLine(k2.Adi);

        }
    }
}
