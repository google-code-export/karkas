using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Simetri.Core.Validation.ForPonos
{
    [Serializable]
    public class OnlyTheseCharactersValidator : RegExValidator
    {
        private const string REGEX_ONLY_THESECHARACTERS = "^[{0}]*$";
        public OnlyTheseCharactersValidator(object pUzerindeCalisilacakNesne, string pPropertyName,char[] pCharList)
            : base(pUzerindeCalisilacakNesne, pPropertyName, getRegexString(pCharList)
            , RegexOptions.None)
        {

        }
        public OnlyTheseCharactersValidator(object pUzerindeCalisilacakNesne, string pPropertyName, char[] pCharList,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, getRegexString(pCharList)
            , RegexOptions.None,pErrorMessage)
        {

        }


        private static string getRegexString(char[] pCharlist)
        {
            StringBuilder sb = new StringBuilder(pCharlist.Length);
            foreach (char c in pCharlist)
            {
                sb.Append(c);
            }
            return string.Format(REGEX_ONLY_THESECHARACTERS, sb.ToString());
        }

    }
}