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
            reservedWordsForCSharp.Add("value");
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

        public string SetPascalCase(string degistirilecekString)
        {
            return solveLanguageSpecificProblems(degistirilecekString, false);
        }

        public string SetCamelCase(string degistirilecekString)
        {
            return solveLanguageSpecificProblems(degistirilecekString, true);
        }

        private string solveLanguageSpecificProblems(string degistirilecekString, bool isCamelCase)
        {
            string result = cleanNonStandardChars(degistirilecekString);



            if (isCamelCase)
                result = caseHelper.SetCamelCase(result);
            else
                result = caseHelper.SetPascalCase(result);

            return solveReservedWordIssues(result);
        }


        private string cleanNonStandardChars(string degistirilecekString)
        {
            bool isCapitalFlag = false;
            StringBuilder temizlenmisHali = new StringBuilder();
            foreach (char c in degistirilecekString)
            {
                if (nonStandardChars.ContainsKey(c))
                {   // Non standard char seen
                    temizlenmisHali.Append(nonStandardChars[c] + "_");
                    isCapitalFlag = true;
                }
                else
                {
                    if (isCapitalFlag)
                    {
                        temizlenmisHali.Append(Char.ToUpperInvariant(c));
                        isCapitalFlag = false;
                    }
                    else
                    {
                        temizlenmisHali.Append(c);
                    }
                }
            }

            addInitialLetterForNumericInitialLetteredVariables(temizlenmisHali);

            return temizlenmisHali.ToString();
        }

        private string solveReservedWordIssues(string degistirilecekString)
        {
            return (reservedWordsForCSharp.Contains(degistirilecekString)) ? degistirilecekString + RESERVED_WORD_KEYWORD : degistirilecekString;
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
            public string SetCamelCase(string degistirilecekString)
            {
                string text = SetPascalCase(degistirilecekString);
                char[] arr = text.ToCharArray();
                arr[0] = char.ToLowerInvariant(arr[0]);
                return new string(arr);
            }

            public const char degisicekChar = '_';
            private string kotuKarakterlerdenAyir(string degistirilecekString)
            {
                degistirilecekString = degistirilecekString.Replace('-', degisicekChar);
                degistirilecekString = degistirilecekString.Replace('(', degisicekChar);
                degistirilecekString = degistirilecekString.Replace(')', degisicekChar);
                degistirilecekString = degistirilecekString.Replace('/', degisicekChar);
                return degistirilecekString;
            }

            public string SetPascalCase(string degistirilecekString)
            {
                degistirilecekString = kotuKarakterlerdenAyir(degistirilecekString);
                degistirilecekString = kelimelereAyir(degistirilecekString);

                string text = "";
                bool kelimeAyrimi = true;
                bool SadaceBuyukHarfMi = true;
                foreach (char ch in degistirilecekString)
                {
                    if (char.IsLower(ch))
                    {
                        SadaceBuyukHarfMi = false;
                        break;
                    }
                }
                foreach (char ch in degistirilecekString)
                {
                    switch (ch)
                    {
                        case ' ':
                            kelimeAyrimi = true;
                            break;

                        case '.':
                            kelimeAyrimi = true;
                            break;

                        case '_':
                            kelimeAyrimi = true;
                            break;

                        default:
                            if (kelimeAyrimi)
                            {
                                text = text + ch.ToString().ToUpperInvariant();
                                kelimeAyrimi = false;
                            }
                            else if (SadaceBuyukHarfMi)
                            {
                                text = text + ch.ToString().ToLowerInvariant();
                            }
                            else
                            {
                                text = text + ch.ToString();
                            }
                            break;
                    }
                }
                return text;
            }

            private string kelimelereAyir(string degistirilecekString)
            {
                List<int> kelimelerinYerleri = new List<int>();

                for (int i = 0; i < degistirilecekString.Length; i++)
                {
                    if (degistirilecekString[i] == '_')
                    {
                        kelimelerinYerleri.Add(i);
                    }
                    if (char.IsNumber(degistirilecekString[i]))
                    {
                        kelimelerinYerleri.Add(i);
                    }
                    if ((i != 0) && (i != degistirilecekString.Length - 1) &&
                        (
                        char.IsUpper(degistirilecekString[i + 1])
                        &&
                        char.IsLower(degistirilecekString[i]))
                        )
                    {
                        kelimelerinYerleri.Add(i+1);
                    }
                }

                kelimelerinYerleri.Add(degistirilecekString.Length);
                int kesmeBaslangic = 0;
                List<String> parcalanmisKelimeler = new List<string>();
                for (int i = 0; i < kelimelerinYerleri.Count; i++)
                {
                    parcalanmisKelimeler.Add(degistirilecekString.Substring(kesmeBaslangic, kelimelerinYerleri[i] -kesmeBaslangic ));
                    kesmeBaslangic = kelimelerinYerleri[i];
                }

                string sonuc = "";

                foreach (string s in parcalanmisKelimeler)
                {
                    if (sonuc == "")
                    {
                        sonuc = s.ToUpperInvariant();
                    }
                    else
                    {
                        sonuc = sonuc + "_" + s.Replace("_", "").ToUpperInvariant();
                    }
                }

                return sonuc;

            }


        }
    }
}
