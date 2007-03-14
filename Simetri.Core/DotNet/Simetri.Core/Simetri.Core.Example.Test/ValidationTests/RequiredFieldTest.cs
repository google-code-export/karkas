using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Example.TypeLibrary;
using NUnit.Framework;

namespace Simetri.Core.Example.Test.ValidationTests
{
    [TestFixture]
    public class RequiredFieldTest
    {
        [Test]
        public void TestBosString()
        {
            Kisi deneme = new Kisi();
            deneme.Adi = "";
            deneme.Validate();
            Assert.IsFalse(deneme.Validator.IsValid);
        }

        [Test]
        public void TestDogruluk()
        {
            Kisi deneme = new Kisi();
            deneme.Adi = "Atilla";
            deneme.Yasi = 30;
            deneme.Validate();
            Assert.IsTrue(deneme.Validator.IsValid);
        }

        [Test]
        public void TestIkisiniBirden()
        {
            Kisi a = new Kisi();
            a.Adi = null;
            a.Yasi = null;
            a.Validate();
            Assert.AreEqual(a.Validator.ErrorList.Count, 3);
        }


        [Test]
        public void TestNullableType()
        {
            Kisi a = new Kisi();
            a.Adi = "Atilla";
            a.Yasi = null;
            a.Validate();
            Assert.IsFalse(a.Validator.IsValid);
        }
    }
}
