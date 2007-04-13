using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Web.Utility
{
    public abstract class SimetriBaseCrudPage : SimetriBasePage
    {

        public abstract void UiToBusiness(Object o);
        public abstract void Business(Object o);
        
    }
}
