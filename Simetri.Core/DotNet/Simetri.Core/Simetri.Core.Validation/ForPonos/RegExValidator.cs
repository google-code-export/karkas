using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Simetri.Core.Validation.ForPonos
{
    public class RegExValidator : BaseValidator
    {
        private string regularExpression;
        private RegexOptions regExOptions;

        public RegExValidator(object pUzerindeCalisilacakNesne, string pPropertyName,
            string pRegularExpression,RegexOptions pRegExOptions) 
            : base(pUzerindeCalisilacakNesne,pPropertyName)
        {
            this.regExOptions = pRegExOptions;
            this.regularExpression = pRegularExpression;
        }
        public override bool Perform(object instance, object fieldValue)
        {
            if (instance == null)
            {
                return false;
            }
            return new Regex(regularExpression, regExOptions).IsMatch(fieldValue.ToString());
        }

        protected override string BuildErrorMessage()
        {
            return string.Format("{0} kabul edilen bir formatta de�ildir",this.Property.Name);
        }
    }
}
