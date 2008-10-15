using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper
{
    public class NameChecker : INameChecker
    {
        private const string RESERVED_WORD_KEYWORD = "ReservedWord";
        private Dictionary<char, string> nonStandardChars = new Dictionary<char, string>();
        private List<string> reservedWordsForCSharp = new List<string>();
        private CaseHelper caseHelper = new CaseHelper();

        public NameChecker()
        {
            fillNonStandardChars();
            fillReservedWords();
        }

        /// <summary>
        /// Case sensitive reserved words and does not 
        /// contain contextual words such as var, select, set etc.
        /// (Updated: November 2007 MSDN)
        /// </summary>
        private void fillReservedWords()
        {
            #region reserved word list
            reservedWordsForCSharp.Add("abstract");
            reservedWordsForCSharp.Add("event");
            reservedWordsForCSharp.Add("new");
            reservedWordsForCSharp.Add("struct");
            reservedWordsForCSharp.Add("as");
            reservedWordsForCSharp.Add("explicit");
            reservedWordsForCSharp.Add("null");
            reservedWordsForCSharp.Add("switch");
            reservedWordsForCSharp.Add("base");
            reservedWordsForCSharp.Add("extern");
            reservedWordsForCSharp.Add("object");
            reservedWordsForCSharp.Add("this");
            reservedWordsForCSharp.Add("bool");
            reservedWordsForCSharp.Add("false");
            reservedWordsForCSharp.Add("operator");
            reservedWordsForCSharp.Add("throw");
            reservedWordsForCSharp.Add("break");
            reservedWordsForCSharp.Add("finally");
            reservedWordsForCSharp.Add("out");
            reservedWordsForCSharp.Add("true");
            reservedWordsForCSharp.Add("byte");
            reservedWordsForCSharp.Add("fixed");
            reservedWordsForCSharp.Add("override");
            reservedWordsForCSharp.Add("try");
            reservedWordsForCSharp.Add("case");
            reservedWordsForCSharp.Add("float");
            reservedWordsForCSharp.Add("params");
            reservedWordsForCSharp.Add("typeof");
            reservedWordsForCSharp.Add("catch");
            reservedWordsForCSharp.Add("for");
            reservedWordsForCSharp.Add("private");
            reservedWordsForCSharp.Add("uint");
            reservedWordsForCSharp.Add("char");
            reservedWordsForCSharp.Add("foreach");
            reservedWordsForCSharp.Add("protected");
            reservedWordsForCSharp.Add("ulong");
            reservedWordsForCSharp.Add("checked");
            reservedWordsForCSharp.Add("goto");
            reservedWordsForCSharp.Add("public");
            reservedWordsForCSharp.Add("unchecked");
            reservedWordsForCSharp.Add("class");
            reservedWordsForCSharp.Add("if");
            reservedWordsForCSharp.Add("readonly");
            reservedWordsForCSharp.Add("unsafe");
            reservedWordsForCSharp.Add("const");
            reservedWordsForCSharp.Add("implicit");
            reservedWordsForCSharp.Add("ref");
            reservedWordsForCSharp.Add("ushort");
            reservedWordsForCSharp.Add("continue");
            reservedWordsForCSharp.Add("in");
            reservedWordsForCSharp.Add("return");
            reservedWordsForCSharp.Add("using");
            reservedWordsForCSharp.Add("int");
            reservedWordsForCSharp.Add("sbyte");
            reservedWordsForCSharp.Add("virtual");
            reservedWordsForCSharp.Add("default");
            reservedWordsForCSharp.Add("interface");
            reservedWordsForCSharp.Add("sealed");
            reservedWordsForCSharp.Add("volatile");
            reservedWordsForCSharp.Add("delegate");
            reservedWordsForCSharp.Add("internal");
            reservedWordsForCSharp.Add("short");
            reservedWordsForCSharp.Add("void");
            reservedWordsForCSharp.Add("do");
            reservedWordsForCSharp.Add("is");
            reservedWordsForCSharp.Add("sizeof");
            reservedWordsForCSharp.Add("while");
            reservedWordsForCSharp.Add("double");
            reservedWordsForCSharp.Add("lock");
            reservedWordsForCSharp.Add("stackalloc");
            reservedWordsForCSharp.Add("else");
            reservedWordsForCSharp.Add("long");
            reservedWordsForCSharp.Add("static");
            reservedWordsForCSharp.Add("enum");
            reservedWordsForCSharp.Add("namespace");
            reservedWordsForCSharp.Add("string");
            #endregion
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
            return solveLanguageSpecificProblems(name, false);
        }

        public string SetCamelCase(string name)
        {
            return solveLanguageSpecificProblems(name, true);
        }

        private string solveLanguageSpecificProblems(string name, bool isCamelCase)
        {
            string result = cleanNonStandardChars(name);

            if (isCamelCase)
                result = caseHelper.SetCamelCase(result);
            else
                result = caseHelper.SetPascalCase(result);

            return solveReservedWordIssues(result);
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

        private string solveReservedWordIssues(string name)
        {
            return (reservedWordsForCSharp.Contains(name)) ? name + RESERVED_WORD_KEYWORD : name;
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
