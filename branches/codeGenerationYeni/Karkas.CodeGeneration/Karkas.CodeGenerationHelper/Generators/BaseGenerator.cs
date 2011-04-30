using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.Generators
{
    public abstract class BaseGenerator
    {
        public void BaslangicSusluParentezVeTabArtir(IOutput output)
        {
            output.autoTabLn("{");
            output.incTab();
        }
        public void BitisSusluParentezVeTabAzalt(IOutput output)
        {
            output.decTab();
            output.autoTabLn("}");
        }
        public void BaslangicSusluParentez(IOutput output)
        {
            output.autoTabLn("{");
            output.incTab();
        }
        public void BitisSusluParentez(IOutput output)
        {
            output.decTab();
            output.autoTabLn("}");
        }


    }
}

