using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Validation
{
    [Serializable]
    public class OnaylamaHatasi : Exception
    {
        public OnaylamaHatasi(string pMessage)
        {

        }
        public OnaylamaHatasi(Object pErrorObject) : this(pErrorObject.ToString())
        {
            
        }
    }
}
