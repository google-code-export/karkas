using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.Validation.ForPonos;
using System.Text.RegularExpressions;

namespace Simetri.Core.Example.Test.ValidationTests
{
    [TestFixture]
    public class RegExTests
    {

        [Test]
        public void yaziTest()
        {
            Kisi k = new Kisi();
            k.Validator.ValidatorList.Clear();
            k.Validator.ValidatorList.Add(new RegExValidator(k, "Adi", "^[a-zA-ZüðiþçöýÜÐÝÞÇÖI]*$", RegexOptions.None));

            k.Adi = "1";
            Assert.IsFalse(k.Validate());

            
            k.Adi = "//dsd1";
            Assert.IsFalse(k.Validate());


            k.Adi = "Aaa";
            Assert.IsTrue(k.Validate());
        }
    }
}
