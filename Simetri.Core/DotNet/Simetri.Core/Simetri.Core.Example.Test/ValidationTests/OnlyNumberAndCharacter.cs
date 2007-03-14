using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simetri.Core.Example.TypeLibrary;

namespace Simetri.Core.Example.Test.ValidationTests
{
    /// <summary>
    /// Summary description for OnlyNumberAndCharacter
    /// </summary>
    [TestFixture]
    public class OnlyNumberAndCharacter
    {
        Kisi deneme;

        public OnlyNumberAndCharacter()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [SetUp]
        public void MyTestInitialize()
        {
            deneme = new Kisi();
            deneme.Adi = "Atilla";
            deneme.Soyadi = "Ozgur";
        }


        [Test]
        public void Test1()
        {
            //myRow.SadaceSayiVeHarf = "11111";
            //myRow.Validate();
            //Assert.IsFalse(myRow.HasErrors);
        }
        [Test]
        public void TestSadaceBuyukHarf()
        {
            //myRow.SadaceSayiVeHarf = "ABCDERF";
            //myRow.Validate();
            //Assert.IsFalse(myRow.HasErrors);
        }
        [Test]
        public void TestSadaceKucukHarf()
        {
            //myRow.SadaceSayiVeHarf = "abcdef";
            //myRow.Validate();
            //Assert.IsFalse(myRow.HasErrors);
        }
        [Test]
        public void TestSadaceNoktalamaIsaretleri()
        {
            //myRow.SadaceSayiVeHarf = "'[l;']/.";
            //myRow.Validate();
            //Assert.IsTrue(myRow.HasErrors);
        }
        [Test]
        public void TestSadaceTurkceKarakterler()
        {
            //myRow.SadaceSayiVeHarf = "üðiþçöýÜÐÝÞÇÖI";
            //myRow.Validate();
            //Assert.IsFalse(myRow.HasErrors);
        }
        [Test]
        public void TestSayiVeHarfGirimi()
        {
            //myRow.SadaceSayiVeHarf = "üðiþçöýÜÐÝÞÇÖI123436890";
            //myRow.Validate();
            //Assert.IsFalse(myRow.HasErrors);
        }
    }
}
