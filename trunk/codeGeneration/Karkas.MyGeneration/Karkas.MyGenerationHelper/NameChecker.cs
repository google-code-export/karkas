using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper
{
    public class NameChecker : INameChecker
    {
        private Dictionary<char, string> nonStandardChars = new Dictionary<char, string>();
        private CaseHelper caseHelper = new CaseHelper();

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
            string araSonuc =  cleanNonStandardChars(name);
            return caseHelper.SetPascalCase(araSonuc);
            
        }

        public string SetCamelCase(string name)
        {
            string araSonuc = cleanNonStandardChars(name);
            return caseHelper.SetCamelCase(araSonuc);
        }

        private string cleanNonStandardChars(string name)
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

            addInitialLetterForNumericInitialLetteredVariables(cleanName);

            return cleanName.ToString();
        }

        /// <summary>
        /// Add initial letter if it starts with number.
        /// </summary>
        /// <param name="cleanName">Cleaned name from non standard chars.</param>
        /// <param name="isPascalCase">PascalCase or camelCase</param>
        private void addInitialLetterForNumericInitialLetteredVariables(StringBuilder cleanName)
        {
            if (Char.IsNumber(cleanName[0]))
            {
                cleanName.Insert(0, "D_");
            }
        }



        private class CaseHelper
        {
            public string SetCamelCase(string name)
            {
                string text = "";
                bool flag = false;
                bool flag2 = true;
                bool flag3 = true;
                foreach (char ch in name)
                {
                    if (char.IsLower(ch))
                    {
                        flag3 = false;
                        break;
                    }
                }
                foreach (char ch2 in name)
                {
                    switch (ch2)
                    {
                        case ' ':
                            if (!flag2)
                            {
                                flag = true;
                            }
                            break;

                        case '.':
                            if (!flag2)
                            {
                                flag = true;
                            }
                            break;

                        case '_':
                            if (!flag2)
                            {
                                flag = true;
                            }
                            break;

                        default:
                            if (flag)
                            {
                                text = text + ch2.ToString().ToUpperInvariant();
                                flag = false;
                            }
                            else if (flag2)
                            {
                                text = text + ch2.ToString().ToLowerInvariant();
                                flag2 = false;
                            }
                            else if (flag3)
                            {
                                text = text + ch2.ToString().ToLowerInvariant();
                            }
                            else
                            {
                                text = text + ch2.ToString();
                            }
                            break;
                    }
                }
                return text;
            }

            public const char degisicekChar = '_';
            private string kotuKarakterlerdenAyir(string name)
            {
                name = name.Replace('-', degisicekChar);
                name = name.Replace('(', degisicekChar);
                name = name.Replace(')', degisicekChar);
                name = name.Replace('/', degisicekChar);
                return name;
            }

            public string SetPascalCase(string name)
            {
                name = kotuKarakterlerdenAyir(name);
                string text = "";
                bool flag = true;
                bool flag2 = true;
                foreach (char ch in name)
                {
                    if (char.IsLower(ch))
                    {
                        flag2 = false;
                        break;
                    }
                }
                foreach (char ch2 in name)
                {
                    switch (ch2)
                    {
                        case ' ':
                            flag = true;
                            break;

                        case '.':
                            flag = true;
                            break;

                        case '_':
                            flag = true;
                            break;

                        default:
                            if (flag)
                            {
                                text = text + ch2.ToString().ToUpperInvariant();
                                flag = false;
                            }
                            else if (flag2)
                            {
                                text = text + ch2.ToString().ToLowerInvariant();
                            }
                            else
                            {
                                text = text + ch2.ToString();
                            }
                            break;
                    }
                }
                return text;
            }


        }
    }
}
