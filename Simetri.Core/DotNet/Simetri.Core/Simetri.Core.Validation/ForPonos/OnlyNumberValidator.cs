using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Simetri.Core.Validation.ForPonos
{
    public class OnlyNumberValidator : RegExValidator
    {
        private const string REGEX_ONLY_NUMBER = "^[0-9]*$";
        public OnlyNumberValidator(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_NUMBER, RegexOptions.None)
        {

        }


        protected override string BuildErrorMessage()
        {
            return string.Format("{0} sadace sayý girilmelidir", this.Property.Name);
        }

    }
}
