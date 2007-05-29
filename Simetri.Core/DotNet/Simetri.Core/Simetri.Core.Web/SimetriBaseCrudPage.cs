using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Web
{
    public abstract class SimetriBaseCrudPage : SimetriBasePage
    {

        public abstract object UiToBusiness();
        public abstract void BusinessToUi(object o);

        
    }
}
