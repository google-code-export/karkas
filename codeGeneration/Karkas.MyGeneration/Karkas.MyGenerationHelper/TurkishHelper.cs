using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.MyGenerationHelper
{
    public class TurkishHelper
    {
        Dictionary<string, string> liste = new Dictionary<string, string>();
        public TurkishHelper()
        {
            liste.Add("Adi", "Adý");
            liste.Add("Tur", "Tür");
            liste.Add("Kisi", "Kiþi");
            liste.Add("Ogrenim", "Öðrenim");
            liste.Add("Bolum", "Bolüm");
            liste.Add("Giris", "Giriþ");
            string a = @"
            Aciklama";
                
        }

        public string ReplaceTurkishChars(string str)
        {
            str = str.Replace('ð', 'g');
            str = str.Replace('Ð', 'G');

            str = str.Replace('ü', 'u');
            str = str.Replace('Ü', 'U');

            str = str.Replace('þ', 's');
            str = str.Replace('Þ', 'S');

            str = str.Replace('ý', 'i');
            str = str.Replace('Ý', 'I');

            str = str.Replace('ö', 'o');
            str = str.Replace('Ö', 'O');

            str = str.Replace('ç', 'c');
            str = str.Replace('Ç', 'C');

            return str;
        }




        /// <summary>
        /// Ingilizce harfleri ile yazýlmýþ bir kelimeyi türkçe harflere çevirir.
        /// </summary>
        /// <param name="cevirilecekKelime"></param>
        /// <returns></returns>
        public string TurkceyeCevir(string cevirilecekKelime)
        {
            if (liste.ContainsKey(cevirilecekKelime))
            {
                return liste[cevirilecekKelime];
            }
            else
            {
                foreach (string s in liste.Keys)
                {
                    Regex reg = new Regex(s, RegexOptions.IgnoreCase);
                    Match m = reg.Match(cevirilecekKelime);
                    if (m.Success)
                    {
                        return cevirilecekKelime.Replace(m.Value, liste[s].ToLower());
                    }
                }

                return cevirilecekKelime;
            }

        }
    }
}
