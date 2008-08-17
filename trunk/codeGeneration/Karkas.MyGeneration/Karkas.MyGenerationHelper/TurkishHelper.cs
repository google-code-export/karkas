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
            liste.Add("Adi", "Ad�");
            liste.Add("Tur", "T�r");
            liste.Add("Kisi", "Ki�i");
            liste.Add("Ogrenim", "��renim");
            liste.Add("Bolum", "Bol�m");
            liste.Add("Giris", "Giri�");
            string a = @"
            Aciklama";
                
        }

        public string ReplaceTurkishChars(string str)
        {
            str = str.Replace('�', 'g');
            str = str.Replace('�', 'G');

            str = str.Replace('�', 'u');
            str = str.Replace('�', 'U');

            str = str.Replace('�', 's');
            str = str.Replace('�', 'S');

            str = str.Replace('�', 'i');
            str = str.Replace('�', 'I');

            str = str.Replace('�', 'o');
            str = str.Replace('�', 'O');

            str = str.Replace('�', 'c');
            str = str.Replace('�', 'C');

            return str;
        }




        /// <summary>
        /// Ingilizce harfleri ile yaz�lm�� bir kelimeyi t�rk�e harflere �evirir.
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
