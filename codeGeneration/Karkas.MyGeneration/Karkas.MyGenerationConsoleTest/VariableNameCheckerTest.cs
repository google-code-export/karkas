using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.MyGenerationTest
{
    using System;
    using NUnit.Framework;
    using Karkas.MyGenerationHelper;

    [TestFixture]
    public class VariableNameCheckerTest
    {
        NameChecker nameChecker = new NameChecker();

        [SetUp]
        public void Init()
        {
            nameChecker = new NameChecker();
        }

        [Test]
        public void VariablePascalCaseCalisiyorMu()
        {
            string variableName = "BASIT_TABLO";
            string variableNameNew = nameChecker.SetPascalCase(variableName);
            string variableNameExpected = "BasitTablo";
            Assert.AreEqual(variableNameNew, variableNameExpected);
        }
        [Test]
        public void VariableCamelCaseCalisiyorMu()
        {
            string variableName = "BASIT_TABLO";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            string variableNameExpected = "basitTablo";
            Assert.AreEqual(variableNameNew, variableNameExpected);
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

        [Test]
        public void VariableConsistsOfReservedWordRefTest()
        {
            string variableName = "ref";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("refReservedWord", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableContainsReservedWordRefTest()
        {            
            string variableName = "refreeName";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("refreeName", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableContainsReservedWordRefInDifferentCasesTest()
        {
            string variableName = "rEf";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("rEf", variableNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void VariableContainsReservedWordRefUpperCaseInitialLetterTest()
        {
            string variableName = "Ref";
            string variableNameNew = nameChecker.SetCamelCase(variableName);
            Assert.IsTrue(String.Equals("refReservedWord", variableNameNew, StringComparison.InvariantCulture));
        }
        [Test]
        public void DegiskenBuyukKucukHarfSorunu1()
        {
            string variableName = "MUH_ANALITIK_HAKEDIS_UID";
            string variableNameNew = nameChecker.SetPascalCase(variableName);
            Assert.IsTrue(String.Equals("MuhAnalitikHakedisUid", variableNameNew, StringComparison.InvariantCulture));

            variableName = "USP_MUH_ANALITIK_HAKEDIS_UID";
            variableNameNew = nameChecker.SetPascalCase(variableName);
            Assert.IsTrue(String.Equals("UspMuhAnalitikHakedisUid", variableNameNew, StringComparison.InvariantCulture));

            variableName = "SP_MUH_ANALITIK_HAKEDIS_UID";
            variableNameNew = nameChecker.SetPascalCase(variableName);
            Assert.IsTrue(String.Equals("SpMuhAnalitikHakedisUid", variableNameNew, StringComparison.InvariantCulture));


        }
        [Test]
        public void DegiskenBuyukKucukHarfSorunu2()
        {
            string variableName = "Usp_MUH_ANALITIK_HAKEDIS_UID";
            string variableNameNew = nameChecker.SetPascalCase(variableName);
            Assert.IsTrue(String.Equals("UspMuhAnalitikHakedisUid", variableNameNew, StringComparison.InvariantCulture));


            variableName = "usp_MUH_ANALITIK_HAKEDIS_UID";
            variableNameNew = nameChecker.SetPascalCase(variableName);
            Assert.IsTrue(String.Equals("UspMuhAnalitikHakedisUid", variableNameNew, StringComparison.InvariantCulture));

            variableName = "sp_MUH_ANALITIK_HAKEDIS_UID";
            variableNameNew = nameChecker.SetPascalCase(variableName);
            Assert.IsTrue(String.Equals("SpMuhAnalitikHakedisUid", variableNameNew, StringComparison.InvariantCulture));


        }

    }
}
