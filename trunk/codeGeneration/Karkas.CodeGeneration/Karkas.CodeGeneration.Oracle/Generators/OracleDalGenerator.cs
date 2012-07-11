using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.Oracle.Generators
{
    public class OracleDalGenerator : DalGenerator
    {


       public OracleDalGenerator(IDatabaseHelper databaseHelper): base(databaseHelper)
        {
        }

        protected override string parameterSymbol
        {
            get { return ":"; }
        }
    }
}
