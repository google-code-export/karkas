using System;
using System.Collections.Generic;
using System.Text;
using Zeus;

namespace Karkas.MyGenerationHelper.Generators
{
    public abstract class BaseGenerator
    {
        public void BaslangicSusluParentezVeTabArtir(IZeusOutput output)
        {
            output.autoTabLn("{");
            output.incTab();
        }
        public void BitisSusluParentezVeTabAzalt(IZeusOutput output)
        {
            output.decTab();
            output.autoTabLn("}");
        }
        public void BaslangicSusluParentez(IZeusOutput output)
        {
            output.autoTabLn("{");
            output.incTab();
        }
        public void BitisSusluParentez(IZeusOutput output)
        {
            output.decTab();
            output.autoTabLn("}");
        }


    }
}
