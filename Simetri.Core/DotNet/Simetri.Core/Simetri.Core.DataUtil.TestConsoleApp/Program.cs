using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Example.Dal;
using Simetri.Core.Example.TypeLibrary;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            KisiDal dal = new KisiDal();
            try
            {
                dal.Ekle();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            List<Kisi> liste = dal.hepsiniGetir();
            foreach (Kisi p in liste)
            {
                Console.Write("Adi " + p.Adi);
                Console.WriteLine(" Soyadi " + p.Soyadi);
            }

        }
    }
}
