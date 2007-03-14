using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Simetri.Core.Validation.ForPonos
{
    public class RequiredFieldValidator : BaseValidator
    {
        public RequiredFieldValidator(object pUzerindeCalisilacakNesne,string pPropertyName) : base(pUzerindeCalisilacakNesne,pPropertyName)
        {
        }


        public override bool Perform(object instance, object fieldValue)
        {
            return fieldValue != null && fieldValue.ToString().Length != 0;
        }

        protected override string BuildErrorMessage()
        {
            return String.Format("{0} Gereklidir.", Property.Name);
        }



    }
}
