using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper
{
    public class NameChecker : INameChecker
    {
        private Dictionary<char, string> nonStandardChars = new Dictionary<char, string>();

        public NameChecker()
        {
            fillNonStandardChars();
        }

        private void fillNonStandardChars()
        {
            nonStandardChars.Add(' ', "Space");
            nonStandardChars.Add('.', "Dot");
            nonStandardChars.Add('#', "Sharp");
            nonStandardChars.Add('-', "Dash");
            nonStandardChars.Add('+', "Plus");
            nonStandardChars.Add('/', "Slash");
            nonStandardChars.Add('(', "LeftPar");
            nonStandardChars.Add(')', "RightPar");
        }

        public string SetPascalCase(string name)
        {
            return cleanNonStandardChars(name, true);
        }

        public string SetCamelCase(string name)
        {
            return cleanNonStandardChars(name, false);
        }

        private string cleanNonStandardChars(string name, bool isPascalCase)
        {
            bool isCapitalFlag = false;
            StringBuilder cleanName = new StringBuilder();
            foreach (char c in name)
            {
                if (nonStandardChars.ContainsKey(c))
                {   // Non standard char seen
                    cleanName.Append(nonStandardChars[c]);
                    isCapitalFlag = true;
                }
                else
                {
                    if (isCapitalFlag)
                    {
                        cleanName.Append(Char.ToUpperInvariant(c));
                        isCapitalFlag = false;
                    }
                    else
                    {
                        cleanName.Append(c);
                    }
                }
            }

            lowerOrUpperInitialLetter(cleanName, isPascalCase);
            addInitialLetterForNumericInitialLetteredVariables(cleanName, isPascalCase);

            return cleanName.ToString();
        }

        /// <summary>
        /// Add initial letter if it starts with number.
        /// </summary>
        /// <param name="cleanName">Cleaned name from non standard chars.</param>
        /// <param name="isPascalCase">PascalCase or camelCase</param>
        private void addInitialLetterForNumericInitialLetteredVariables(StringBuilder cleanName, bool isPascalCase)
        {
            if (Char.IsNumber(cleanName[0]))
            {
                if (isPascalCase)
                    cleanName.Insert(0, 'D');
                else
                    cleanName.Insert(0, 'd');
            }
        }

        /// <summary>
        /// Lower the first letter of the variable for camelCase.
        /// </summary>
        private void lowerOrUpperInitialLetter(StringBuilder cleanName, bool isPascalCase)
        {
            if (!isPascalCase)
            {   // camelCase
                if (Char.IsUpper(cleanName[0]))
                    cleanName[0] = Char.ToLowerInvariant(cleanName[0]);
            }
            else
            {   // PascalCase
                if (Char.IsLower(cleanName[0]))
                    cleanName[0] = Char.ToUpperInvariant(cleanName[0]);
            }
        }
    }
}
