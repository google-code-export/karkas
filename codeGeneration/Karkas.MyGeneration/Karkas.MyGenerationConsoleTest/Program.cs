using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper;
using Karkas.MyGenerationHelper.Generators;
using System.Configuration;
using MyMeta;
using Karkas.MyGenerationTest;

namespace Karkas.MyGenerationConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VariableNameCheckerTest test = new VariableNameCheckerTest();
            test.DegiskenBuyukKucukHarfSorunu2();


            PropertyNameCheckerTest test2 = new PropertyNameCheckerTest();
            test2.PropertyHasNonStandardCharsAtTheBeginningTest();
            test2.PropertyHasNonStandardCharsAtTheBeginningAndInTheMiddleTest();
            test2.PropertyHasNonStandardCharsInTheMiddleTest();
            test2.PropertyHasNonStandardCharsLeftAndRightParanthesisDotAndSpaceInTheMiddleTest();
            test2.PropertyHasNumericCharsAtTheBeginningAndInTheMiddleTest();
            test2.PropertyHasNumericCharsAtTheBeginningTest();


        }
    }
}

