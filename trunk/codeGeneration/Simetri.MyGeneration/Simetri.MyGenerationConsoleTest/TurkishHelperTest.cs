using System;
using System.Collections.Generic;
using System.Text;

using MbUnit.Framework;
using Simetri.MyGenerationHelper;

namespace Simetri.MyGenerationTest
{
    [TestFixture]
    [Author("Atilla �zg�r", "aozgur@simetri.com")]
    public class TurkishHelperTest
    {
        string hataMesaji = "Turce yard�mc� duzgun cal��m�yor";
        [Test]
        public void TestTurkceKarakterler()
        {
            TurkishHelper tHelper = new TurkishHelper();
            string ingilizce1 = "Adi";
            string turkce1 = "Adi";
            Assert.IsTrue(tHelper.ReplaceTurkishChars(ingilizce1) == turkce1,hataMesaji );
            Assert.IsTrue(tHelper.ReplaceTurkishChars("�anl�urfa") == "Sanliurfa", hataMesaji);
            Assert.IsFalse(tHelper.ReplaceTurkishChars("�anl�urfa") == "�anl�urfa", hataMesaji);
        } 
    }
}
