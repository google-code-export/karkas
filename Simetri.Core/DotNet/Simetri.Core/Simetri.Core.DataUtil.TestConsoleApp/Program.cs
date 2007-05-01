using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Example.Dal;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.Example.Dal.Ortak;
using Simetri.Core.Example.TypeLibrary.Ortak;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            KisiDal dal = new KisiDal();
            try
            {
                Kisi k = new Kisi();
                k.KisiKey = Guid.NewGuid();
                k.Adi = "Pýnar";
                k.Soyadi = "Ün";
                dal.Ekle(k);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //List<Kisi> liste = dal.SorguCalistir();
            //foreach (Kisi p in liste)
            //{
            //    Console.Write("Adi " + p.Adi);
            //    Console.WriteLine(" Soyadi " + p.Soyadi);
            //}

        }
    }
}
