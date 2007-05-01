using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.Validation.ForPonos;
using Simetri.Core.Validation;
using Simetri.Core.Example.TypeLibrary.Ortak;

namespace Simetri.Core.Example.Test.ValidationTests
{
    [TestFixture]
    public class CompareOperatorTest
    {
        [Test]
        public void buyuktur()
        {
            Kisi k = new Kisi();
            k.Validator.ValidatorList.Clear();
            k.Validator.ValidatorList.Add(new CompareValidator(k, "Yasi", 18, CompareOperator.GreaterThan));
            Assert.IsFalse(k.Validate());


            Assert.IsTrue(k.Validate());


        }
        [Test]
        public void buyukturVeEsittir()
        {
            Kisi k = new Kisi();
            k.Validator.ValidatorList.Clear();
            k.Validator.ValidatorList.Add(new CompareValidator(k, "Yasi", 18, CompareOperator.GreatThanEqual));
            Assert.IsFalse(k.Validate());



        }

    
    
    }
}
