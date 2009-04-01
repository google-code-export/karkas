﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.Core.Utility
{
    public static class KarkasStringExtensions
    {
        /// <summary>
        /// Static IsNullOrEmpty'nin extension method hali.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
            
        }


        /// <summary>
        /// String.Replace bir string icindeki gecen tum kelimeleri replace eder.
        /// Yani
        /// "Deneme Deneme".Replace("Den","123") = "123eme 123eme"
        /// ReplaceLastOccurance ile
        /// "Deneme Deneme".ReplaceLastOccurance("Den","123") = "Deneme 123eme"
        /// olur
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pOldValue"></param>
        /// <param name="pNewValue"></param>
        /// <returns></returns>
        public static string ReplaceLastOccurance(this string pValue, string pOldValue, string pNewValue)
        {
            int lastIndex = pValue.LastIndexOf(pOldValue, StringComparison.InvariantCultureIgnoreCase);
            string baslangic = pValue.Substring(0, lastIndex);
            string son = pValue.Substring(lastIndex + pOldValue.Length);
            return baslangic + pNewValue + son;
        }

        public static string StringToBase64Encode(this string str)
        {
            byte[] arr = StringToByteArray(str);
            return Convert.ToBase64String(arr);
        }
        public static string StringToBase64Decode(this string str)
        {
            byte[] arr = Convert.FromBase64String(str);
            return ByteArrayToString(arr);
        }
        public static string ByteArrayToString(this byte[] arr)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(arr);
        }
        public static byte[] StringToByteArray(this string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
}
