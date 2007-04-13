using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Simetri.Core.Validation.ForPonos
{
    public class OnlyCharacterAndNumberValidator : RegExValidator
    {
        private const string REGEX_ONLY_CHARACTER_NUMBER = "^[a-zA-Z��i����������I0-9]*$";
        public OnlyCharacterAndNumberValidator(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, REGEX_ONLY_CHARACTER_NUMBER, RegexOptions.None)
        {

        }
        protected override string BuildErrorMessage()
        {
            return string.Format("{0} sadace harf ve say� girilmelidir", this.Property.Name);
        }

    
    }
}