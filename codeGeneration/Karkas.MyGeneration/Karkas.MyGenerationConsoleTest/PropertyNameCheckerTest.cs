using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.MyGenerationTest
{
    using System;
    using NUnit.Framework;
    using Karkas.MyGenerationHelper.Interfaces;
    using Karkas.MyGenerationHelper;

    [TestFixture]
    public class PropertyNameCheckerTest
    {
        INameChecker nameChecker = new NameChecker();

        [SetUp]
        public void Init()
        {
            nameChecker = new NameChecker();
        }

        [Test]
        public void PropertyHasNonStandardCharsInTheMiddleTest()
        {
            string propertyName = "a-/#1b";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("AdashSlashSharp1b", propertyNameNew, StringComparison.InvariantCulture)); 
        }
        
        [Test]
        public void PropertyHasNonStandardCharsLeftAndRightParanthesisDotAndSpaceInTheMiddleTest()
        {
            string propertyName = "(1.3) ip";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("LeftPar1Dot3RightParSpaceIp", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNonStandardCharsAtTheBeginningTest()
        {
            string propertyName = "-/#ba";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("DashSlashSharpBa", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNonStandardCharsAtTheBeginningAndInTheMiddleTest()
        {
            string propertyName = "-/#b-/a";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("DashSlashSharpBdashSlashA", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNumericCharsAtTheBeginningTest()
        {
            string propertyName = "1-2#days";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("D1Dash2SharpDays", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNumericCharsAtTheBeginningAndInTheMiddleTest()
        {
            string propertyName = "01to-2days";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("D01toDash2days", propertyNameNew, StringComparison.InvariantCulture));
        }
    }
}
