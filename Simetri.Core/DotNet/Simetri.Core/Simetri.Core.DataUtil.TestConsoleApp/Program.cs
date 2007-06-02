using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary.Ortak;
using System.Data;
using Simetri.Core.Validation.ForPonos;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Kisi k = new Kisi();
            decimal a;
            if (decimal.TryParse("DENEME", out a))
            {
                k.TcKimlikNo = a;

            }
            else
            {
                k.Validator.SetError("TcKimlikNo", "Tc KimlikNo formatý yanlýþ");
            }

           




        }
    }
}
