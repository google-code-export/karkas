using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Karkas.MyGenerationHelper;

namespace Karkas.MyGenerationTest
{
    [TestFixture]
    public class TurkishHelperTest
    {
        string hataMesaji = "Turkçe yardýmcý düzgün calýþmýyor";
        [Test]
        public void TestTurkceKarakterler()
        {
            TurkishHelper tHelper = new TurkishHelper();
            string ingilizce1 = "Adi";
            string turkce1 = "Adi";
            Assert.IsTrue(tHelper.ReplaceTurkishChars(ingilizce1) == turkce1,hataMesaji );
            Assert.IsTrue(tHelper.ReplaceTurkishChars("Þanlýurfa") == "Sanliurfa", hataMesaji);
            Assert.IsFalse(tHelper.ReplaceTurkishChars("Þanlýurfa") == "Þanlýurfa", hataMesaji);
        } 
    }
}
