using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.MyGenerationTest
{
    using System;
    using MbUnit.Framework;
    using Karkas.MyGenerationHelper;

    [TestFixture]
    public class VariableNameCheckerTest
    {
        NameChecker nameChecker;

        [SetUp]
        public void Init()
        {
            nameChecker = new NameChecker();
        }

        [Test]
        public void VariableHasNonStandardCharsInTheMiddleTest()
        {
            string variableName = "a-/#1b";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("aDashSlashSharp1b", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableHasNumericCharsAtTheBeginningAndInTheMiddleTest()
        {
            string variableName = "12B2a";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("d12B2a", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableHasNonStandardCharsAtTheBeginningTest()
        {
            string variableName = "-/#ba";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("dashSlashSharpBa", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableHasNonStandardCharsAtTheBeginningAndInTheMiddleTest()
        {
            string variableName = "-/#b-/a";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("dashSlashSharpBDashSlashA", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableHasNumericCharsAtTheBeginningTest()
        {
            string variableName = "1-2days";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("d1Dash2days", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableHasNumericCharsAtTheBeginningAndInTheMiddleTestAndNonStandardChars()
        {
            string variableName = "01to-2#Days";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("d01toDash2SharpDays", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableHasNumericCharsAtTheBeginningWithPlusTest()
        {
            string variableName = "12+Days";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("d12PlusDays", variableNameNew, StringComparison.InvariantCulture));
        }
    }
}
