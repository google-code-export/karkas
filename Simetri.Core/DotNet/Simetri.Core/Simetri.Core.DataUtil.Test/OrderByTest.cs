using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;
using Simetri.Core.Example.Dal.Ortak;
using Simetri.Core.TypeLibrary.Ortak;

namespace Simetri.Core.DataUtil.Test
{
    [TestFixture]
    public class OrderByTest
    {
        [Test]
        public void OrderByKisiTest()
        {
            KisiDal dal = new KisiDal();
            List<Kisi> liste = new List<Kisi>();
            //dal.SorguCalistir(liste, "Adi LIKE 'A%'", "Adi,Soyadi");
        }
    }
}
