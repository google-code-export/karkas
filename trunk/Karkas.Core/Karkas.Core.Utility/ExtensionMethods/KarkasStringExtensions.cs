﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Karkas.Extensions
{
    public static class KarkasStringExtensions
    {

        public static string getSha1Hash(string pValueToBedHashed)
        {

            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] inputBytes = sha.ComputeHash(pValueToBedHashed.StringToByteArray());
            byte[] outputBytes = new byte[inputBytes.Length];
            ToBase64Transform base64Transform = new ToBase64Transform();
            base64Transform.TransformBlock(
                                inputBytes,
                                0,
                                inputBytes.Length,
                                outputBytes,
                                0);
            return ByteArrayToString(outputBytes);
        }


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



        public static bool GecerliEPostaMi(this string eMail)
        {
            return Regex.IsMatch(eMail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}

